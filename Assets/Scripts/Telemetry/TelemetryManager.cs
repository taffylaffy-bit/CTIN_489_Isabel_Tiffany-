using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Threading.Tasks;
using System.Collections.Generic;

public class TelemetryManager : MonoBehaviour
{
    public static TelemetryManager Instance;

    TelemetryFileLogger fileLogger;

    async void Awake()
    {
        Instance = this;

        fileLogger = GetComponent<TelemetryFileLogger>();

        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();

        Debug.Log("Telemetry Started");
    }

    public void TrackButton(string buttonName)
    {
        // Send to Unity Analytics
        AnalyticsService.Instance.RecordEvent(new ButtonPressedEvent(buttonName));

        // Also save to CSV
        fileLogger.LogKeyPress(buttonName);
    }

    public void TrackPlayerPosition(Vector3 pos)
    {
        AnalyticsService.Instance.RecordEvent(new PlayerPositionEvent(pos.x, pos.y));

        fileLogger.LogPosition(pos);
    }

    public void TrackUIButton(string buttonName)
    {
        // Send to Unity Analytics (no parameters allowed)
        AnalyticsService.Instance.RecordEvent("ui_button_pressed_" + buttonName);

        // Save to CSV
        fileLogger.LogUIButton(buttonName);
    }
}