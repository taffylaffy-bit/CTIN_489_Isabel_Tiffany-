using UnityEngine;

public class ButtonClicked : MonoBehaviour
{
    public void OnClick()
    {
        TelemetryManager.Instance.TrackButton("PlayButton");
    }
}
