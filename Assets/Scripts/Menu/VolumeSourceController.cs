using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSourceController : MonoBehaviour {

    public bool isEFX;

    private AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        if (isEFX)
        {
            audioS.volume = AtributosMenu.volumeEFX;
        }
        else
        {
            audioS.volume = AtributosMenu.volumeMusica;
        }
    }


    void Update()
    {
        if (isEFX)
        {
            audioS.volume = AtributosMenu.volumeEFX;
        }else
        {
            audioS.volume = AtributosMenu.volumeMusica;
        }
    }

}
