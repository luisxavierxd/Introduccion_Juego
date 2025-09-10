using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource; // Para música de fondo / batalla
    [SerializeField] private AudioSource SFXSource;   // Para sonidos cortos
    [SerializeField] private AudioSource stepsSource; // Para caminar en bucle

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip batalla;
    public AudioClip caminar;
    public AudioClip casa;
    public AudioClip ataque;
    public AudioClip victoria;
    public AudioClip muerte;
    public AudioClip puerta;
    public AudioClip daño;
    public AudioClip item;
    public AudioClip musicaMenu;
    public AudioClip GetOUT;

    private enum EstadoMusica { Normal, Batalla }
    private EstadoMusica estadoActual = EstadoMusica.Normal;

    void Start()
    {
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
        return GameObject.FindWithTag("Enemy") != null;
    }

    void CambiarMusica(EstadoMusica nuevoEstado)
    {
        estadoActual = nuevoEstado;

        switch (estadoActual)
        {
            case EstadoMusica.Normal:
                musicSource.clip = background;
                musicSource.volume = 0.1f; // volumen más bajo para background
                break;
            case EstadoMusica.Batalla:
                musicSource.clip = batalla;
                musicSource.volume = 0.35f; // volumen más alto para batalla
                break;
        }

        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volumen = 1f)
    {
        SFXSource.volume = volumen;
        SFXSource.PlayOneShot(clip);
    }

    // Métodos para pasos
    public void PlaySteps()
    {
        if (!stepsSource.isPlaying)
        {
            stepsSource.clip = caminar;
            stepsSource.loop = true;
            stepsSource.volume = 1f; // ajusta a tu gusto, 0-1
            stepsSource.Play();
        }
    }

    public void StopSteps()
    {
        if (stepsSource.isPlaying)
        {
            stepsSource.Stop();
        }
    }

    public void CambiarMusicaFondo(AudioClip clip)
    {
        if (musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}
