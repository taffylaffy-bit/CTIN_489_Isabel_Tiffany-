using UnityEngine;
using System.Collections;

public class PlayerTelemetry : MonoBehaviour
{
    public TelemetryFileLogger fileLogger;

    IEnumerator Start()
    {
        while (true)
        {
            Vector3 pos = transform.position;

            // Send data to analytics
            TelemetryManager.Instance.TrackPlayerPosition(pos);

            // Save data to file
            fileLogger.LogPosition(transform.position);

            yield return new WaitForSeconds(5f);
        }
    }
}