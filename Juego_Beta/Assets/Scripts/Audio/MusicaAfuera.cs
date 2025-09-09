using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaAfuera : MonoBehaviour
{

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        
    }

}
