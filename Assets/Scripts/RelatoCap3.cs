using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RelatoCap3 : MonoBehaviour
{
    [SerializeField] private Button panelTexto;
    [SerializeField] private TMP_Text textoRelato;
    [SerializeField] private Button panelFrankenstein;
    [SerializeField] private Button botonCrear;
    [SerializeField] private TMP_Text etiquetaCrear;
    [SerializeField] private GameObject frankenstina;
    [SerializeField] private GameObject controlesDeRopa;

    [TextArea(2, 6)] [SerializeField] private string[] introduccion;
    [TextArea(2, 6)] [SerializeField] private string[] reflexion;
    [TextArea(2, 6)] [SerializeField] private string[] cierre;

    private enum Etapa { Introduccion, Personalizacion, Creada, Reflexion, Imagen, Cierre }
    private Etapa etapa;
    private string[] pasaje;
    private int pagina;

    private void Awake()
    {
        panelTexto.onClick.AddListener(AvanzarTexto);
        panelFrankenstein.onClick.AddListener(CerrarImagen);
        botonCrear.onClick.AddListener(CrearODestruir);

        MostrarTaller(false);
        etiquetaCrear.text = "Crear";
        AbrirPasaje(Etapa.Introduccion, introduccion);
    }

    private void AbrirPasaje(Etapa nuevaEtapa, string[] paginas)
    {
        etapa = nuevaEtapa;
        pasaje = paginas;
        pagina = 0;
        panelFrankenstein.gameObject.SetActive(false);
        panelTexto.gameObject.SetActive(true);
        textoRelato.text = pasaje[pagina];
    }

    private void AvanzarTexto()
    {
        if (pagina + 1 < pasaje.Length)
        {
            textoRelato.text = pasaje[++pagina];
            return;
        }

        switch (etapa)
        {
            case Etapa.Introduccion:
                etapa = Etapa.Personalizacion;
                panelTexto.gameObject.SetActive(false);
                MostrarTaller(true);
                break;
            case Etapa.Reflexion:
                etapa = Etapa.Imagen;
                panelTexto.gameObject.SetActive(false);
                panelFrankenstein.gameObject.SetActive(true);
                break;
        }
    }

    private void CrearODestruir()
    {
        if (etapa == Etapa.Personalizacion)
        {
            etapa = Etapa.Creada;
            etiquetaCrear.text = "Destruir";
        }
        else if (etapa == Etapa.Creada)
        {
            MostrarTaller(false);
            AbrirPasaje(Etapa.Reflexion, reflexion);
        }
    }

    private void CerrarImagen()
    {
        if (etapa == Etapa.Imagen)
            AbrirPasaje(Etapa.Cierre, cierre);
    }

    private void MostrarTaller(bool visible)
    {
        frankenstina.SetActive(visible);
        controlesDeRopa.SetActive(visible);
        botonCrear.gameObject.SetActive(visible);
    }
}
