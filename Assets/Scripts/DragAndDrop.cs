using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    private Vector2 offset;
    private RectTransform rectTransform;
    private Canvas canvas;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out offset
        );
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPointerPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPointerPosition))
        {
            rectTransform.localPosition = localPointerPosition - offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Try FinalCookTrigger first
        FinalCookTrigger finalTrigger = FindObjectOfType<FinalCookTrigger>();
        if (finalTrigger != null)
        {
            finalTrigger.CheckOverlap(rectTransform, this.tag);
            return;
        }

        // Try original CookTrigger
        CookTrigger cookTrigger = FindObjectOfType<CookTrigger>();
        if (cookTrigger != null)
        {
            cookTrigger.CheckOverlap(rectTransform, this.tag);
            return;
        }

        Debug.LogWarning("No cook trigger found in this scene.");
    }
}
