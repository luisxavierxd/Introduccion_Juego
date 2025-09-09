using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject player;
    private PlayerHealth playerHealth;
    public CanvasGroup canvasGroup;

    public GameObject otherCanvas; 

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        canvasGroup = GetComponent<CanvasGroup>(); // debe estar en el mismo Canvas

        // hacemos invisible al inicio
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    public void GOSetup()
    {
        if (playerHealth.currentHealth <= 0)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            // liberar el mouse
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (otherCanvas != null)
                otherCanvas.SetActive(false);
        }
    }


    public void Restart()
    {
        Debug.Log("Botón pulsado!");
        SceneManager.LoadScene("SampleScene");
    }

}
