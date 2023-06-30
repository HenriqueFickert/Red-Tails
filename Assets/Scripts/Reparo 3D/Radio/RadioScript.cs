using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour {

    private PainelAudioController painelAudioControllerScript;

    public GameObject botao;
    public GameObject seta;

    public Cookie cookieFunc;

    private int randomNumber;
    public float speed = 150f;
    private float rot;
    private float xSeta;
    private float varAtual;
    public AudioSource audioSChiado;
    public AudioSource audioSFala;

    public bool botaoChecked;

    public bool ativaSomRadio;

    public bool venceuDRadio;

    private Fios fios;

    void Start () {
        painelAudioControllerScript = GameObject.Find("PainelAviao").GetComponent<PainelAudioController>();
        rot = 0;
        varAtual = 0;
        randomNumber = Random.Range(200, 800);
        fios = GameObject.Find("DesafioFio").GetComponent<Fios>();
       
    }
	

	void Update () {

        //ATIVAR O SOM DE ACORDO SE ELE TA VISUALIZANDO O DESAFIO
        if (ativaSomRadio)
        {
            audioSChiado.enabled = true;
            audioSFala.enabled = true;
        }
        else
        {
            audioSChiado.enabled = false;
            audioSFala.enabled = false;
        }

        //INPUTS PARA O RADIO MOVER O MARCADOR
        if (fios.desafiosAtivos[0]) {
            if (!botaoChecked)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0f && rot < 1000)
                {
                    rot += speed * Time.deltaTime;
                    botao.transform.Rotate(0, speed * Time.deltaTime, 0);
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0f && rot > 0)
                {
                    rot -= speed * Time.deltaTime;
                    botao.transform.Rotate(0, -speed * Time.deltaTime, 0);
                }
            }

            
            rot = Mathf.Clamp(rot, 0, 1000);

            varAtual = rot * 0.72f / 1000;

            xSeta = 1.89f - varAtual;

            seta.transform.localPosition = new Vector3(seta.transform.localPosition.x, seta.transform.localPosition.y, xSeta);

            //FAZ A COMPARAÇAO DO SOM CHIADO P/ A FALA
            if (rot < randomNumber)
            {
                audioSFala.volume = (rot / randomNumber);
            }
            else
            {
                float calculo = (1 - (1000 - (rot - randomNumber)) / 500);

                if (calculo < 0)
                {
                    calculo = calculo * (-1);
                }

                audioSFala.volume = calculo;
            }

            audioSChiado.volume = 1 - audioSFala.volume;
            }


    }

    //RESETA O DESAFIO
    public IEnumerator Resetar()
    {
        rot = 0;
        varAtual = 0;
        randomNumber = Random.Range(200, 800);
        yield return new WaitForEndOfFrame();
        rot = Mathf.Clamp(rot, 0, 1000);

        varAtual = rot * 0.72f / 1000;

        xSeta = 1.89f - varAtual;
        seta.transform.localPosition = new Vector3(seta.transform.localPosition.x, seta.transform.localPosition.y, xSeta);

        if (rot < randomNumber)
        {
            audioSFala.volume = (rot / randomNumber);
        }
        else
        {
            float calculo = (1 - (1000 - (rot - randomNumber)) / 500);

            if (calculo < 0)
            {
                calculo = calculo * (-1);
            }

            audioSFala.volume = calculo;
        }

        audioSChiado.volume = 1 - audioSFala.volume;
    }

    //BOTAO DE CHECKAGEM DO RADIO
    public IEnumerator Check()
    {
        painelAudioControllerScript.BotaoConfirma();
        if (fios.desafiosAtivos[0])
        {
            botaoChecked = true;
            Vector3 pos = botao.transform.localPosition;
            pos.x = pos.x + 0.02f;
            botao.transform.localPosition = pos;

            yield return new WaitForSeconds(0.2f);

            if (rot <= randomNumber + 30 && rot >= randomNumber - 30)
            {
                //Se acertou
                venceuDRadio = true;
                painelAudioControllerScript.Certo();
            }
            else
            {
                cookieFunc.Errou();
                botaoChecked = false;
                pos = botao.transform.localPosition;
                pos.x = pos.x - 0.02f;
                botao.transform.localPosition = pos;
                painelAudioControllerScript.Errado();
            }
        }
       yield return 0;
    }

}

