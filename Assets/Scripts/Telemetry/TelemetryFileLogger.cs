using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class TelemetryFileLogger : MonoBehaviour
{
    string sessionFolder;
    string levelFolder;

    string positionPath;
    string keyPressPath;
    string uiButtonPath;

    void Start()
    {
        // Create session folder
        string timestamp = DateTime.Now.ToString("yyyy-MM_dd_HH-mm-ss");
        sessionFolder = Path.Combine(Application.persistentDataPath, "Session_" + timestamp);
        Directory.CreateDirectory(sessionFolder);

        // Create per-level folder
        string levelName = SceneManager.GetActiveScene().name;
        levelFolder = Path.Combine(sessionFolder, levelName);
        Directory.CreateDirectory(levelFolder);

        // File paths inside the level folder
        positionPath = Path.Combine(levelFolder, "player_positions.csv");
        keyPressPath = Path.Combine(levelFolder, "key_presses.csv");
        uiButtonPath = Path.Combine(levelFolder, "ui_buttons.csv");

        // CSV headers
        File.WriteAllText(positionPath, "gameTime,realTime,x,y\n");
        File.WriteAllText(keyPressPath, "gameTime,realTime,key\n");
        File.WriteAllText(uiButtonPath, "gameTime,realTime,button\n");

        Debug.Log("Telemetry folder created: " + levelFolder);
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
