using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

    public Dropdown resolutionDropDown;

    Resolution[] resolutions;

    public AudioSource audioSorceMenu;
    public AudioClip clickSound;
    public AudioClip LightButtomSound;

    private bool isAudioLightRunning;

    private bool opcoesAtiva;

    public GameObject menuOpcoes;

    public Slider sliderMusica;
    public Slider sliderEFX;

    public Material[] materiaisBotoes;
    public Renderer renderBotoes;

    void Start()
    {
        //Volta do pause
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = enabled;

        //Resolutions
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        int currentResoltionIndex = 0;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResoltionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResoltionIndex;
        resolutionDropDown.RefreshShownValue();
    }


    private void Update()
    {
        VolumeMusicaController();
        VolumeEFXController();
    }

    public void Opcoes()
    {
        opcoesAtiva = !opcoesAtiva;
        if (opcoesAtiva) {
            menuOpcoes.SetActive(true);
        }else
        {
            menuOpcoes.SetActive(false);
        }
    }

    //Qualidade Grafica
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Tela Cheia
    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    //Resolucao
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Volume
    public void VolumeMusicaController()
    {
        
        AtributosMenu.volumeMusica = sliderMusica.value;
    }
    public void VolumeEFXController()
    {
        
        AtributosMenu.volumeEFX = sliderEFX.value;
    }



    //Sound EFX
    public IEnumerator AudioClick()
    {
        audioSorceMenu.PlayOneShot(clickSound, AtributosMenu.volumeEFX);
        yield return new WaitForSeconds(clickSound.length);
    }

    //Para o Options
    public void PlayAudioClick()
    {
        audioSorceMenu.PlayOneShot(clickSound, AtributosMenu.volumeEFX);
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
        audioSorceMenu.PlayOneShot(LightButtomSound, AtributosMenu.volumeEFX);
        yield return new WaitForSeconds(LightButtomSound.length);
        isAudioLightRunning = false;
    }

    public void TrocaMaterialBotao(int index)
    {
        renderBotoes.material = materiaisBotoes[index];
    }
}
