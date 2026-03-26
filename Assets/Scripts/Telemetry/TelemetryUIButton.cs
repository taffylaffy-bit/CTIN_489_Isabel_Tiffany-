using UnityEngine;
using UnityEngine.UI;

public class TelemetryUIButton : MonoBehaviour
{
    public string buttonName;

    void Start()
    {
        // Auto-fill name if not set
        if (string.IsNullOrEmpty(buttonName))
            buttonName = gameObject.name;

        // Hook into the UI Button
        GetComponent<Button>().onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        TelemetryManager.Instance.TrackUIButton(buttonName);
    }
}