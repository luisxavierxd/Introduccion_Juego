using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject enemy;                // arrastra aquí el enemigo que debe morir
    private Enemy_Health enemyHealth;       // referencia al script de salud del enemigo
    public CanvasGroup canvasGroup;         // canvas del WinScreen

    public GameObject otherCanvas;          // canvas que quieres ocultar (HUD u otro)

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
        if (enemyHealth != null && enemyHealth.currentHealth <= 0)
        {
            ShowWinScreen();
        }
    }

    public void ShowWinScreen()
    {
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
        Debug.Log("Botón de reinicio pulsado!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
