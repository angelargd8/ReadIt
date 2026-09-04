using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartaDialogo : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject panelTexto;
    [SerializeField] private TMP_Text textoUI;

    [Header("Textos de la carta")]
    [TextArea(3, 6)]
    [SerializeField] private string[] textos;

    [Header("Configuraci�n")]
    [SerializeField] private bool soloUnaVez = true;

    private int indiceActual;
    private bool dialogoActivo;
    private bool cartaLeida;

    private void Start()
    {
        if (panelTexto != null)
        {
            panelTexto.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (soloUnaVez && cartaLeida)
        {
            return;
        }

        AbrirDialogo();
    }

    private void AbrirDialogo()
    {
        if (textos == null || textos.Length == 0)
        {
            Debug.LogWarning("La carta no tiene textos configurados.");
            return;
        }

        indiceActual = 0;
        dialogoActivo = true;

        panelTexto.SetActive(true);

        MostrarTextoActual();
    }

    public void SiguienteTexto()
    {
        if (!dialogoActivo)
        {
            return;
        }

        indiceActual++;

        if (indiceActual >= textos.Length)
        {
            CerrarDialogo();
            return;
        }

        MostrarTextoActual();
    }

    private void MostrarTextoActual()
    {
        if (textoUI != null)
        {
            textoUI.text = textos[indiceActual];
        }
    }

    private void CerrarDialogo()
    {
        dialogoActivo = false;
        cartaLeida = true;

        panelTexto.SetActive(false);
        CambiarDeEscena();
    }

        void CambiarDeEscena()
    {
        // Puedes usar el nombre exacto de tu escena entre comillas
        SceneManager.LoadScene("Timeline");
    }
}