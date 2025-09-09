using UnityEngine;

public class Loot : MonoBehaviour
{
    public ITEMSO itemSO;
    public SpriteRenderer sr;
    public Animator anim;
    public GameObject enemy;
    public GameObject canvasToShow;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnValidate()
    {
        if (itemSO == null)
            return;

        sr.sprite = itemSO.icon;
        this.name = itemSO.itemName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.item);
            Destroy(gameObject);
            enemy.SetActive(true);
            if (canvasToShow != null)
                canvasToShow.SetActive(true); // activa el Canvas
        }
    }
}
