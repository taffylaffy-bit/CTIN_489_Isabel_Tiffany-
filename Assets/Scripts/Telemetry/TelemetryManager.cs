using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Threading.Tasks;

public class TelemetryManager : MonoBehaviour
{
    public static TelemetryManager Instance;

    async void Awake()
    {
        Instance = this;

        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();

        Debug.Log("Telemetry Started");
    }

    public void TrackButton(string buttonName)
    {
        AnalyticsService.Instance.RecordEvent(new ButtonPressedEvent(buttonName));
    }

    public void TrackPlayerPosition(Vector3 pos)
    {
        AnalyticsService.Instance.RecordEvent(new PlayerPositionEvent(pos.x, pos.y));
    }
}