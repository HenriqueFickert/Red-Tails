using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelAudioController : MonoBehaviour {

    //Fio
    [Header("Fio")]
    public AudioSource[] audioSFio;
    public AudioClip clickAudio;
    public AudioClip carregandoAudio;
    public AudioClip estouroAudio;
    //Relogio
    [Header("Relogio")]
    public AudioSource audioSRelogio;
    public AudioClip relogioAudio;
    public AudioClip relogioVoltaAudio;
    //Botoes
    [Header("Botoes")]
    public AudioSource audioSBotoes;
    public AudioClip botaoAudio;
    //Chaves
    [Header("Chaves")]
    public AudioSource audioSChaves;
    public AudioClip resetChavesAudio;
    public AudioClip chavesAudio;
    //BotaoConfirma
    [Header("Confirma")]
    public AudioSource audioSBotaoConfirma;
    public AudioClip botaoConfirmaAudio;
    //Certo e Errado
    [Header("Certo e Errado")]
    public AudioSource audioSCertoErrado;
    public AudioClip certoAudio;
    public AudioClip erradoAudio;
    [Header("Tampa")]
    public AudioSource audioSTampa;
    public AudioClip tampaAudio;



    //Fio
    public void FioClick(int index)
    {
        audioSFio[index].PlayOneShot(clickAudio, AtributosMenu.volumeEFX);
    }
    //Arrumar
    public void FioCarregando(int index)
    {
        audioSFio[index].PlayOneShot(carregandoAudio, AtributosMenu.volumeEFX);
    }
    public void FioEstourando(int index)
    {
        audioSFio[index].PlayOneShot(estouroAudio, AtributosMenu.volumeEFX);
    }

    //Relogio
    //Arrumar
    public void TempoRelogio()
    {
        audioSRelogio.PlayOneShot(relogioAudio, AtributosMenu.volumeEFX);
    }
    public void VoltaRelogio()
    {
        audioSRelogio.PlayOneShot(relogioVoltaAudio, AtributosMenu.volumeEFX);
    }
    //Botao
    public void ClickBotao()
    {
        audioSBotoes.PlayOneShot(botaoAudio, AtributosMenu.volumeEFX);
    }
    //Chaves
    public void ClickChaves()
    {
        audioSChaves.PlayOneShot(chavesAudio, AtributosMenu.volumeEFX);
    }
    public void ResetChaves()
    {
        audioSChaves.PlayOneShot(resetChavesAudio, AtributosMenu.volumeEFX);
    }
    //BotaoConfirma
    public void BotaoConfirma()
    {
        audioSBotaoConfirma.PlayOneShot(botaoConfirmaAudio, AtributosMenu.volumeEFX);
    }
    //CertoErrado
    public void Certo()
    {
        audioSCertoErrado.PlayOneShot(certoAudio, AtributosMenu.volumeEFX);
    }
    public void Errado()
    {
        audioSCertoErrado.PlayOneShot(erradoAudio, AtributosMenu.volumeEFX);
    }
    //Tampa
    public void Tampa()
    {
        audioSTampa.PlayOneShot(tampaAudio, AtributosMenu.volumeEFX);
    }
}
