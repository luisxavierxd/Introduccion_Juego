using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Source------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Audio Clip------------")]
    public AudioClip background;  // Música normal
    public AudioClip casa;
    public AudioClip ataque;
    public AudioClip victoria;
    public AudioClip muerte;
    public AudioClip puerta;
    public AudioClip daño;
    public AudioClip item;
    public AudioClip batalla;     // Música de batalla

    private enum EstadoMusica { Normal, Batalla }
    private EstadoMusica estadoActual = EstadoMusica.Normal;

    void Start()
    {
        // Verifica si hay enemigos desde el inicio
        if (HayEnemigo())
        {
            estadoActual = EstadoMusica.Batalla;
            musicSource.clip = batalla;
        }
        else
        {
            estadoActual = EstadoMusica.Normal;
            musicSource.clip = background;
        }

        musicSource.loop = true;
        musicSource.Play();
    }

    void Update()
    {
        bool enemigoPresente = HayEnemigo();

        if (enemigoPresente && estadoActual != EstadoMusica.Batalla)
        {
            CambiarMusica(EstadoMusica.Batalla);
        }
        else if (!enemigoPresente && estadoActual != EstadoMusica.Normal)
        {
            CambiarMusica(EstadoMusica.Normal);
        }
    }

    bool HayEnemigo()
    {
        // Busca objetos con tag "Enemy"
        return GameObject.FindWithTag("Enemy") != null;
    }

    void CambiarMusica(EstadoMusica nuevoEstado)
    {
        estadoActual = nuevoEstado;

        switch (estadoActual)
        {
            case EstadoMusica.Normal:
                musicSource.clip = background;
                break;
            case EstadoMusica.Batalla:
                musicSource.clip = batalla;
                break;
        }

        musicSource.loop = true;
        musicSource.Play();
    }

    // Función opcional para reproducir efectos de sonido
    public void ReproducirSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
