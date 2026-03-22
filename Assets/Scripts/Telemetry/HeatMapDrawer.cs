using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class HeatMapRecorder : MonoBehaviour
{
    public static List<Vector3> positions = new List<Vector3>();
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            positions.Add(transform.position);
            timer = 0f;
        }
    }

    void OnApplicationQuit()
    {
        string path = Application.persistentDataPath + "/heatmap.csv";

        StreamWriter writer = new StreamWriter(path);

        writer.WriteLine("x,y");

        foreach (Vector3 pos in positions)
        {
            writer.WriteLine(pos.x + "," + pos.y);
        }

        writer.Close();

        Debug.Log("Heatmap saved to: " + path);
    }
}