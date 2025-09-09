using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject enemy;                // arrastra aquí el enemigo que debe morir
    private Enemy_Health enemyHealth;       // referencia al script de salud del enemigo
    public CanvasGroup canvasGroup;         // canvas del WinScreen

    public GameObject otherCanvas;          // canvas que quieres ocultar (HUD u otro)

    AudioManager audioManager;
    private bool winScreenShown = false;   // controla que se muestre una sola vez

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
        // verificamos si la salud del enemigo es 0 o menos
        if (!winScreenShown && enemyHealth != null && enemyHealth.currentHealth <= 0)
        {
            ShowWinScreen();
        }

        // Solo permitir reinicio si la pantalla de victoria está activa
        if (canvasGroup.alpha == 1f &&
            (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            Restart();
        }
    }

    public void ShowWinScreen()
    {
        winScreenShown = true; // marcar como mostrado

        // reproducir sonido de victoria solo una vez
        audioManager.PlaySFX(audioManager.victoria);

        // cambiar música de fondo a un clip especial de victoria
        audioManager.CambiarMusicaFondo(audioManager.musicaMenu);

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        // liberar el mouse
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
