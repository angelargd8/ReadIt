using TMPro;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    [Header("Timeline")]
    [SerializeField]
    private TimelineSlot[] slots;

    [Header("UI")]
    [SerializeField]
    private TMP_Text feedbackText;

    public void CheckTimeline()
    {
        int errores = 0;

        foreach (TimelineSlot slot in slots)
        {
            // Slot vacío
            if (slot.transform.childCount == 0)
            {
                errores++;
                continue;
            }

            TimelineCard card =
                slot.transform
                    .GetChild(0)
                    .GetComponent<TimelineCard>();

            // Por seguridad
            if (card == null)
            {
                errores++;
                continue;
            }

            if (card.CorrectOrder != slot.SlotOrder)
            {
                errores++;
            }
        }

        if (errores == 0)
        {
            feedbackText.text =
                "Timeline complete! Mary's memories are back in order.";

            TimelineCompletado();
        }
        else
        {
            feedbackText.text =
                $"{errores} events are out of place.";
        }
    }

    private void TimelineCompletado()
    {
        Debug.Log("Timeline completado correctamente.");
    }
}