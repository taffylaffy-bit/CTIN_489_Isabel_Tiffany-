using UnityEngine;
using System.IO;
using System;

public class TelemetryFileLogger : MonoBehaviour
{
    string sessionFolder;
    string positionPath;
    string keyPressPath;
    string uiButtonPath;

    void Start()
    {
        // Create a unique session folder using date + time
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        sessionFolder = Path.Combine(Application.persistentDataPath, "Session_" + timestamp);

        Directory.CreateDirectory(sessionFolder);

        // File paths
        positionPath = Path.Combine(sessionFolder, "player_positions.csv");
        keyPressPath = Path.Combine(sessionFolder, "key_presses.csv");
        uiButtonPath = Path.Combine(sessionFolder, "ui_buttons.csv");

        // Create CSV headers
        File.WriteAllText(positionPath, "gameTime,realTime,x,y\n");
        File.WriteAllText(keyPressPath, "gameTime,realTime,key\n");
        File.WriteAllText(uiButtonPath, "gameTime,realTime,button\n");

        Debug.Log("Telemetry session folder: " + sessionFolder);
    }

    public void LogPosition(Vector3 pos)
    {
        string line = $"{Time.time},{DateTime.Now:HH:mm:ss},{pos.x},{pos.y}\n";
        File.AppendAllText(positionPath, line);
    }

    public void LogKeyPress(string keyName)
    {
        string line = $"{Time.time},{DateTime.Now:HH:mm:ss},{keyName}\n";
        File.AppendAllText(keyPressPath, line);
    }

    public void LogUIButton(string buttonName)
    {
        string line = $"{Time.time},{DateTime.Now:HH:mm:ss},{buttonName}\n";
        File.AppendAllText(uiButtonPath, line);
    }
}
