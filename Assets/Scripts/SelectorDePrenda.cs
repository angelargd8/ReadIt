using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
[DisallowMultipleComponent]
public class SelectorDePrenda : MonoBehaviour
{
    [System.Serializable]
    private struct AjusteDeDiseno
    {
        public Texture2D diseno;
        [Tooltip("Parte visible de la textura, en coordenadas UV (0 a 1).")]
        public Rect origen;
        [Tooltip("Posición y tamaño sobre el lienzo completo del cuerpo (0 a 1).")]
        public Rect destino;
    }

    [Tooltip("Arrastra aquí los PNG completos de esta categoría, en el orden de las flechas.")]
    [SerializeField] private Texture2D[] disenos = new Texture2D[0];
    [SerializeField] private AjusteDeDiseno[] ajustes = new AjusteDeDiseno[0];

    private RawImage capa;
    private Sprite spriteCuerpo;
    private Rect uvInicial;
    private int indice;

    private void Awake()
    {
        capa = GetComponent<RawImage>();
        capa.raycastTarget = false;
        uvInicial = capa.uvRect;

        Image cuerpo = GetComponentInParent<Image>();
        if (cuerpo != null) spriteCuerpo = cuerpo.sprite;

        MostrarDiseno();
    }

    private void AlinearConCuerpo(Rect destino)
    {
        // El sprite del cuerpo puede mostrar solo un recorte del lienzo original.
        Rect recorte = spriteCuerpo.rect;
        Vector2 lienzo = new Vector2(spriteCuerpo.texture.width, spriteCuerpo.texture.height);
        RectTransform rect = capa.rectTransform;
        rect.anchorMin = (Vector2.Scale(destino.min, lienzo) - recorte.min) / recorte.size;
        rect.anchorMax = (Vector2.Scale(destino.max, lienzo) - recorte.min) / recorte.size;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }

    public void Anterior()
    {
        Cambiar(-1);
    }

    public void Siguiente()
    {
        Cambiar(1);
    }

    private void Cambiar(int paso)
    {
        if (disenos.Length == 0) return;

        indice = (indice + paso + disenos.Length) % disenos.Length;
        MostrarDiseno();
    }

    private void MostrarDiseno()
    {
        capa.texture = disenos.Length > 0 ? disenos[indice] : null;
        capa.enabled = capa.texture != null;
        if (!capa.enabled || spriteCuerpo == null) return;

        Rect destino = new Rect(0f, 0f, 1f, 1f);
        capa.uvRect = uvInicial;
        foreach (var ajuste in ajustes)
        {
            if (ajuste.diseno != capa.texture) continue;
            capa.uvRect = ajuste.origen;
            destino = ajuste.destino;
            break;
        }
        AlinearConCuerpo(destino);
    }
}
