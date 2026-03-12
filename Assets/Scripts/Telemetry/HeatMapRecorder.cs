using UnityEngine;
using System.Collections.Generic;

public class HeatMapRecorder : MonoBehaviour
{
    public static List<Vector3> positions = new List<Vector3>();

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5f) // record every second
        {
            positions.Add(transform.position);
            timer = 0f;
        }
    }
}
