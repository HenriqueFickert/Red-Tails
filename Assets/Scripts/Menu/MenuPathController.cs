using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPathController : MonoBehaviour {

    public CPC_CameraPath[] Paths;

    public static int indexAtual;
    public GameObject voltarButton;


    private bool isAudioLightRunning;
    public AudioSource audioS;
    public AudioClip clickSound;
    public AudioClip passSound;

    private bool estaNoPath;

    public Material[] materiaisBotoes;
    public Renderer renderBotoes;

    void Start () {
		
	}
	

	void Update () {

        if (estaNoPath)
        {
            for (int i = 0; i < Paths.Length; i++)
            {
                if ((Paths[i].GetCurrentWayPoint() == Paths[i].points.Count - 2) && (Paths[i].GetCurrentTimeInWaypoint() > 0.9f))
                {
                    voltarButton.SetActive(true);
                }
            }
        }
       
    }

    public void PegaIndex(int index) {
        //Som
        PlayAudioClick();

        if (index == 0)
        {
            //Jogar
            FluxoTempo.dias = 1;
            SceneManager.LoadScene(1);
            
        }
        else if (index == 1)
        {
            //Instruçao
            Paths[2].PlayPath(2);
            
        }
        else if (index == 2)
        {
            //Extras
            Paths[0].PlayPath(2);
           
        }
        else if (index == 3)
        {
            //Creditos
            Paths[1].PlayPath(2);
          
        }
        else if (index == 4)
        {
            //Save
            Paths[3].PlayPath(2);
           
        }
        else if (index == 5)
        {
            //Sair
            Application.Quit();
        }

        if (index != 0)
        {

            estaNoPath = true;
        }
        
        indexAtual = index;
    }

    public void BotaoVoltar()
    {
        //Som
        PlayAudioClick();

        if (indexAtual == 1)
        {
            //Instruçao
            Paths[6].PlayPath(2);
            
        }
        else if (indexAtual == 2)
        {
            //Extras
            Paths[4].PlayPath(2);
            
        }
        else if (indexAtual == 3)
        {
            //Creditos
            Paths[5].PlayPath(2);
            
        }
        else if (indexAtual == 4)
        {
            //Saves
            Paths[7].PlayPath(2);
        }
        voltarButton.SetActive(false);
        indexAtual = -1;
        estaNoPath = false;
    }


    //Sound EFX
    public IEnumerator AudioClick()
    {
        audioS.PlayOneShot(clickSound, AtributosMenu.volumeEFX);
        yield return new WaitForSeconds(clickSound.length);
    }

    //Para o Options
    public void PlayAudioClick()
    {
        audioS.PlayOneShot(clickSound, AtributosMenu.volumeEFX);
    }

    public void PlayLightAudio()
    {
        if (!isAudioLightRunning)
        {
            isAudioLightRunning = true;
            StartCoroutine(AudioLight());
        }
    }

    IEnumerator AudioLight()
    {
        audioS.PlayOneShot(passSound, AtributosMenu.volumeEFX);
        yield return new WaitForSeconds(passSound.length);
        isAudioLightRunning = false;
    }

    public void TrocaMaterialBotao(int index)
    {
        renderBotoes.material = materiaisBotoes[index];
    }

}
