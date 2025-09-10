using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject player;
    private PlayerHealth playerHealth;
    public CanvasGroup canvasGroup;
    public GameObject otherCanvas;

    private AudioManager audioManager;
    private bool gameOverShown = false; // control para mostrar solo una vez

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        canvasGroup = GetComponent<CanvasGroup>();

        // Hacemos invisible al inicio
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    void Update()
    {
        // Mostrar GameOver solo una vez
        if (!gameOverShown && playerHealth.currentHealth <= 0)
        {
            ShowGameOver();
        }

        // Reinicio con Enter si la pantalla está activa
        if (canvasGroup.alpha == 1f &&
            (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            Restart();
        }
    }

    public void ShowGameOver()
    {
        if (gameOverShown) return; // protección extra

        gameOverShown = true;

        // Reproducir sonido de muerte una sola vez
        if (audioManager != null && audioManager.muerte != null)
        {
            audioManager.PlaySFX(audioManager.muerte);
        }

        // Cambiar música de fondo a Game Over en bucle
        if (audioManager != null && audioManager.musicaMenu != null)
        {
            audioManager.CambiarMusicaFondo(audioManager.musicaMenu);
        }

        // Mostrar canvas
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        // Liberar mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Ocultar otro canvas si se asignó
        if (otherCanvas != null)
            otherCanvas.SetActive(false);
    }

    public void Restart()
    {
        Debug.Log("Enter presionado, reiniciando escena...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
