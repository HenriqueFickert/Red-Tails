using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    //Resoluçao
    Resolution[] resolutions;
    public Dropdown resolutionDropDown;

    //Audio
    public AudioSource audioSorceMenu;
    public AudioClip clickSound;
    public AudioClip LightButtomSound;
    private bool isAudioLightRunning;

    //Musica
    public Slider sliderMusica;
    public Slider sliderEFX;

    //Pause
    public GameObject menuPause;
    private bool estaPausado = false;
    public GameObject menuSettings;

    void Start()
    {
        sliderMusica.value = AtributosMenu.volumeMusica;
        sliderEFX.value =  AtributosMenu.volumeEFX;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!estaPausado)
                estaPausado = true;
            else
                estaPausado = false;
        }

        if (estaPausado)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = enabled;
            menuPause.SetActive(true);
        }
        else
        {
            menuPause.SetActive(false);
            menuSettings.SetActive(false);
            Time.timeScale = 1;
          //  Cursor.lockState = CursorLockMode.Locked;
         //   Cursor.visible = false;
        }

        VolumeEFXController();
        VolumeMusicaController();

    }

    public void Resume()
    {
        Time.timeScale = 1;
        estaPausado = false;
        menuPause.SetActive(false);
        menuSettings.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
      // Cursor.visible = false;
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("Menu");
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
}
