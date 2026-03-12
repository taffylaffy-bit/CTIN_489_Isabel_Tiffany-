using UnityEngine;
using System.Collections;

public class PlayerTelemetry : MonoBehaviour
{
    IEnumerator Start()
    {
        while (true)
        {
            TelemetryManager.Instance.TrackPlayerPosition(transform.position);
            yield return new WaitForSeconds(5f);
        }
    }
}
