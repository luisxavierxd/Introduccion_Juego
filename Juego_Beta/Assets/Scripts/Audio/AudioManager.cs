
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("----------Audio Source------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Audio Clip---------S---")]
    public AudioClip background;  // MÃºsica normal
    public AudioClip casa;    
    public AudioClip ataque;
    public AudioClip victoria;
    public AudioClip muerte;
    public AudioClip puerta;
    public AudioClip daño;
    public AudioClip item;
    public AudioClip batalla;


}
