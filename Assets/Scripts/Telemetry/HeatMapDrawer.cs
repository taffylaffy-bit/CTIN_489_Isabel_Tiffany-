using UnityEngine;

public class HeatMapDrawer : MonoBehaviour
{
    public GameObject heatDot;

    void Start()
    {
        foreach (Vector3 pos in HeatMapRecorder.positions)
        {
            Instantiate(heatDot, pos, Quaternion.identity);
        }
    }
}
