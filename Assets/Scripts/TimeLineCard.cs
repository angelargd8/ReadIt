using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TimelineCard :
    MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    private RandomCardOrder randomCardOrder;
    [Header("Timeline")]
    [SerializeField]
    private int Order; // Orden en el GRID
    private int correctOrder; // Valor a asignar mediante la lista random
    private TextMeshProUGUI miTextoUI;
        private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        miTextoUI = GetComponentInChildren<TextMeshProUGUI>();
    }

void Start()
{
    randomCardOrder = Object.FindFirstObjectByType<RandomCardOrder>();
    correctOrder = randomCardOrder.numeros[Order];
    Debug.Log(
        "Order: " + Order +
        " | CorrectOrder: " + correctOrder +
        " | Texto: " + randomCardOrder.CardText[correctOrder]
    );

    string text = randomCardOrder.CardText[correctOrder];

    miTextoUI.text = text;
}


    public int CorrectOrder => correctOrder;

    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private Transform originalParent;
    private int originalSiblingIndex;



    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalSiblingIndex = transform.GetSiblingIndex();

        canvasGroup.blocksRaycasts = false;

        transform.SetParent(canvas.transform, true);
        transform.SetAsLastSibling();

        UpdatePosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdatePosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == canvas.transform)
        {
            transform.SetParent(originalParent, false);
            transform.SetSiblingIndex(originalSiblingIndex);
        }
    }

    private void UpdatePosition(PointerEventData eventData)
    {
        RectTransform canvasRect =
            canvas.transform as RectTransform;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPoint))
        {
            rectTransform.localPosition = localPoint;
        }
    }
    
}