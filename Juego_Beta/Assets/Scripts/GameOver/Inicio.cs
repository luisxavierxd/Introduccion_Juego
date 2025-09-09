using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public CanvasGroup startCanvas;
    public GameObject player;
    public AudioManager audioManager;

    private bool gameStarted = false;

    // Variable estática para recordar si ya reiniciamos PlayerPrefs esta sesión
    private static bool prefsReiniciados = false;

    void Awake()
    {
        // Solo reiniciamos PlayerPrefs la primera vez que se ejecuta la escena en esta sesión
        if (!prefsReiniciados)
        {
            PlayerPrefs.DeleteKey("MenuMostrado");
            prefsReiniciados = true;
        }
    }

    void Start()
    {
        int menuMostrado = PlayerPrefs.GetInt("MenuMostrado", 0);

        if (menuMostrado == 0)
        {
            // Mostrar menú inicial
            startCanvas.alpha = 1f;
            startCanvas.interactable = true;
            startCanvas.blocksRaycasts = true;

            if (player != null)
                player.SetActive(false);

            if (audioManager != null && audioManager.musicaMenu != null)
                audioManager.CambiarMusicaFondo(audioManager.musicaMenu);
        }
        else
        {
            // Omitir menú
            startCanvas.alpha = 0f;
            startCanvas.interactable = false;
            startCanvas.blocksRaycasts = false;

            if (player != null)
                player.SetActive(true);

            if (audioManager != null && audioManager.background != null)
                audioManager.CambiarMusicaFondo(audioManager.background);

            gameStarted = true;
        }
    }

    void Update()
    {
        if (!gameStarted &&
            (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;

        PlayerPrefs.SetInt("MenuMostrado", 1);

        startCanvas.alpha = 0f;
        startCanvas.interactable = false;
        startCanvas.blocksRaycasts = false;

        if (player != null)
            player.SetActive(true);

        if (audioManager != null && audioManager.background != null)
            audioManager.CambiarMusicaFondo(audioManager.background);
    }
}
