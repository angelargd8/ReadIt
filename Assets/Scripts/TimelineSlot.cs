using UnityEngine;
using UnityEngine.EventSystems;

public class TimelineSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private int slotOrder;

    public int SlotOrder => slotOrder;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        TimelineCard card =
            eventData.pointerDrag.GetComponent<TimelineCard>();

        if (card == null)
        {
            return;
        }

        if (transform.childCount > 0)
        {
            return;
        }

        card.transform.SetParent(transform, false);

        RectTransform cardRect =
            card.GetComponent<RectTransform>();

        cardRect.anchorMin = new Vector2(0.5f, 0.5f);
        cardRect.anchorMax = new Vector2(0.5f, 0.5f);
        cardRect.pivot = new Vector2(0.5f, 0.5f);

        cardRect.anchoredPosition = Vector2.zero;
    }
}