using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject enemy;                // enemigo que debe morir
    private Enemy_Health enemyHealth;       // referencia al script de salud del enemigo
    public CanvasGroup canvasGroup;         // canvas del WinScreen
    public GameObject otherCanvas;          // canvas que quieres ocultar (HUD u otro)

    private AudioManager audioManager;
    private bool winScreenShown = false;   // controla que se muestre solo una vez

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // obtenemos referencia al script de salud del enemigo
        enemyHealth = enemy.GetComponent<Enemy_Health>();

        // obtenemos CanvasGroup del objeto donde está este script
        canvasGroup = GetComponent<CanvasGroup>();

        // hacemos invisible al inicio
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    void Update()
    {
        // mostrar WinScreen solo una vez
        if (!winScreenShown && enemyHealth != null && enemyHealth.currentHealth <= 0)
        {
            ShowWinScreen();
        }

        // reinicio con Enter si la pantalla está activa
        if (canvasGroup.alpha == 1f &&
            (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            Restart();
        }
    }

    public void ShowWinScreen()
    {
        if (winScreenShown) return; // protección extra
        winScreenShown = true;

        // reproducir sonido de victoria solo una vez
        if (audioManager != null && audioManager.victoria != null)
        {
            audioManager.PlaySFX(audioManager.victoria);
        }

        // cambiar música de fondo a un clip especial de victoria en bucle
        if (audioManager != null && audioManager.musicaMenu != null)
        {
            audioManager.CambiarMusicaFondo(audioManager.musicaMenu);
        }

        // mostrar canvas
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        // liberar mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // ocultar otro canvas si se asignó
        if (otherCanvas != null)
            otherCanvas.SetActive(false);
    }

    public void Restart()
    {
        Debug.Log("Enter presionado, reiniciando escena...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
