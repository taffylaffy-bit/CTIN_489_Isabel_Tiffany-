using UnityEngine;
using System.IO;

public class TelemetryFileLogger : MonoBehaviour
{
    string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/player_positions.csv";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "time,x,y\n");
        }
    }

    public void LogPosition(Vector3 pos)
    {
        string line = Time.time + "," + pos.x + "," + pos.y + "\n";
        File.AppendAllText(filePath, line);
    }
}