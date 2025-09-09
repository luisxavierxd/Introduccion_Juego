using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject player;
    private PlayerHealth playerHealth;
    public CanvasGroup canvasGroup;
    public GameObject otherCanvas;

    AudioManager audioManager;
    private bool gameOverShown = false; // control para mostrar una sola vez

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        canvasGroup = GetComponent<CanvasGroup>();

        // hacemos invisible al inicio
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    void Update()
    {
        // mostramos GameOver solo una vez
        if (!gameOverShown && playerHealth.currentHealth <= 0)
        {
            ShowGameOver();
        }

        // reinicio con Enter si la pantalla está activa
        if (canvasGroup.alpha == 1f &&
            (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            Restart();
        }
    }

    public void ShowGameOver()
    {
        gameOverShown = true; // marcar como mostrado

        // reproducir sonido de muerte solo una vez
        audioManager.PlaySFX(audioManager.muerte);

        // cambiar música de fondo si quieres
        audioManager.CambiarMusicaFondo(audioManager.musicaMenu); // o un clip especial de game over

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (otherCanvas != null)
            otherCanvas.SetActive(false);
    }

    public void Restart()
    {
        Debug.Log("Enter presionado, reiniciando escena...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
