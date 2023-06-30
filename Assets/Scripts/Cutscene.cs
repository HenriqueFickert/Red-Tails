using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour {

    public VideoPlayer video;
    public GameObject fundo;

    public bool Cut1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!video.isPlaying)
        {
            if (Cut1) { 
            SceneManager.LoadScene("LoadSceneGame");
            FluxoTempo.dias = 1;
        }
            if (!Cut1)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            fundo.SetActive(false);
        }




        if (Input.GetMouseButton(0)) {
            SceneManager.LoadScene("LoadSceneGame");
            FluxoTempo.dias = 1;
        }
    }
}
