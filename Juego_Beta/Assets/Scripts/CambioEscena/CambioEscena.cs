using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{

    public string sceneToLoad;
    public Animator fadeAnim;
    public float fadeTime = 0.5f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioManager.PlaySFX(audioManager.puerta);
            fadeAnim.Play("FadeFromWhite");
            StartCoroutine(DelayFade());
        }
    }

    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneToLoad);
    }

}
