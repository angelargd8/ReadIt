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
        // Buscar una carta dentro del Slot
        TimelineCard card = slot.GetComponentInChildren<TimelineCard>();

        // SLOT VACÍO
        if (card == null)
        {
            errores++;

            Debug.Log(
                $"Slot {slot.SlotOrder}: VACÍO → ERROR"
            );

            continue;
        }

        // CARTA INCORRECTA
        if (card.CorrectOrder != slot.SlotOrder)
        {
            errores++;

            Debug.Log(
                $"Slot {slot.SlotOrder}: " +
                $"CorrectOrder = {card.CorrectOrder} → ERROR"
            );
        }
        else
        {
            Debug.Log(
                $"Slot {slot.SlotOrder}: " +
                $"CorrectOrder = {card.CorrectOrder} → CORRECTO"
            );
        }
    }

    Debug.Log($"TOTAL DE ERRORES: {errores}");

    // RESULTADO FINAL
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