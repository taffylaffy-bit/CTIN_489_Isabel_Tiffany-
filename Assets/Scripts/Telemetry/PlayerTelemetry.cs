using UnityEngine;
using System.Collections;

public class PlayerTelemetry : MonoBehaviour
{
    IEnumerator Start()
    {
        while (true)
        {
            TelemetryManager.Instance.TrackPlayerPosition(transform.position);

            yield return new WaitForSeconds(0.2f); // logs 5 times per second
        }
    }
}