using UnityEngine;

public class TelemetryKeyListener : MonoBehaviour
{
    void Update()
    {
        // Loop through all possible KeyCodes
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                // Send the key name to your telemetry manager
                TelemetryManager.Instance.TrackButton(key.ToString());
            }
        }
    }
}
