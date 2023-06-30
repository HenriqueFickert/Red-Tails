using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoScript : MonoBehaviour {
    private PainelAudioController painelAudioControllerScript;

    public bool[] botoesCima = new bool[3];
    public bool[] botoesBaixo = new bool[5];

    public int[] atualBotoesCima = new int[3];
    public int[] atualBotoesBaixo = new int[5];

    private int[] respostaCertaCima = new int [3];
    private int[] respostaCertaBaixo = new int[5];

    public Light[] luzCima;
    public Light[] luzBaixo;

    public bool botaoCimaEmUso;
    public bool botaoBaixoEmUso;
    public float tempoLuz;

    public Transform botaoTCima;
    public Transform botaoTBaixo;

    private bool venceuBaixo;
    private bool venceuCima;

    public bool venceuDBotao;

    public Cookie cookieFunc;

    void Start () {

        painelAudioControllerScript = GameObject.Find("PainelAviao").GetComponent<PainelAudioController>();

        //Deixa todas as luzes apagadas
        for (int i = 0; i < botoesCima.Length; i++)
        {
            botoesCima[i] = false;
            luzCima[i].intensity = 0;
        }

        for (int i = 0; i < botoesBaixo.Length; i++)
        {
            botoesBaixo[i] = false;
            luzBaixo[i].intensity = 0;
        }

        
    }

    private void Update()
    {
        if (venceuBaixo && venceuCima)
        {
            venceuDBotao = true;
        }
    }

    // -------------------------------------- LUZES DE CIMA --------------------------------------

    //Luz aviso:
    public IEnumerator LigaLuzCima(int index)
    {
        botaoCimaEmUso = true;
        luzCima[index].intensity = 10;
        luzCima[index].color = Color.yellow;
        painelAudioControllerScript.ClickBotao();

        yield return new WaitForSeconds(tempoLuz);

        botaoCimaEmUso = false;
        luzCima[index].intensity = 0;
        botoesCima[index] = false;
        yield return 0;
    }

    //Luz Errado:
    IEnumerator LigaLuzVermelhoCima()
    {
        botaoCimaEmUso = true;
        painelAudioControllerScript.Errado();

        for (int i = 0; i < botoesCima.Length; i++)
        {
            luzCima[i].intensity = 10;
            luzCima[i].color = Color.red;
        }

        yield return new WaitForSeconds(tempoLuz);

        for (int i = 0; i < botoesCima.Length; i++)
        {
            luzCima[i].intensity = 0;
            botoesCima[i] = false;
        }

        atualBotoesCima = new int[3] { 0, 0, 0 };
        botaoCimaEmUso = false;
        yield return 0;
    }

    //Luz Certo:
    IEnumerator LigaLuzVerdeCima()
    {
        painelAudioControllerScript.Certo();
        for (int i = 0; i < botoesCima.Length; i++)
        {
            luzCima[i].intensity = 10;
            luzCima[i].color = Color.green;
        }
        // atualBotoesCima = new int[3] { 0, 0, 0 };
        yield return 0;
    }



    //Sequencias Certas
   
//



    //Checkagem
    public IEnumerator CheckSequenciaCima()
    {
        painelAudioControllerScript.BotaoConfirma();
        if (Cookie.modeloPainel == 1)
            respostaCertaCima = new int[3] { 1, 2, 3 };

        if (Cookie.modeloPainel == 2)
            respostaCertaCima = new int[3] { 4, 0, 1 };

        if (Cookie.modeloPainel == 3)
            respostaCertaCima = new int[3] { 3, 2, 3 };



        botaoTCima.localEulerAngles = new Vector3(botaoTCima.localEulerAngles.x, botaoTCima.localEulerAngles.y, 8.4f);

        yield return new WaitForSeconds(0.2f);
        botaoCimaEmUso = true;
        for (int i = 0; i < atualBotoesCima.Length; i++)
        {
            if (atualBotoesCima[i] != respostaCertaCima[i])
            {
                botaoTCima.localEulerAngles = new Vector3(botaoTCima.localEulerAngles.x, botaoTCima.localEulerAngles.y, -8.4f);
                StartCoroutine(LigaLuzVermelhoCima());
                cookieFunc.Errou();
                break;
            }
            else
            {
                //Acertou
                venceuCima = true;
                StartCoroutine(LigaLuzVerdeCima());
            }
        }
        yield return 0;
    }

    // -------------------------------------- LUZES DE BAIXO --------------------------------------

    //Luz aviso:
    public IEnumerator LigaLuzBaixo(int index)
    {
        botaoBaixoEmUso = true;
        luzBaixo[index].intensity = 10;
        luzBaixo[index].color = Color.yellow;
        painelAudioControllerScript.ClickBotao();

        yield return new WaitForSeconds(tempoLuz);

        botaoBaixoEmUso = false;
        luzBaixo[index].intensity = 0;
        botoesBaixo[index] = false;
        yield return 0;
    }

    //Luz Errado:ERROU
    IEnumerator LigaLuzVermelhoBaixo()
    {
        botaoBaixoEmUso = true;
        painelAudioControllerScript.Errado();

        for (int i = 0; i < botoesBaixo.Length; i++)
        {
            luzBaixo[i].intensity = 10;
            luzBaixo[i].color = Color.red;
        }

        yield return new WaitForSeconds(tempoLuz);

        for (int i = 0; i < botoesBaixo.Length; i++)
        {
            luzBaixo[i].intensity = 0;
            botoesBaixo[i] = false;
        }

        botaoBaixoEmUso = false;
        atualBotoesBaixo = new int[5] { 0, 0, 0, 0, 0 };
        yield return 0;
    }

    //Luz Certo:ACERTOU
    IEnumerator LigaLuzVerdeBaixo()
    {
        painelAudioControllerScript.Certo();
        for (int i = 0; i < botoesBaixo.Length; i++)
        {
            luzBaixo[i].intensity = 10;
            luzBaixo[i].color = Color.green;
        }
        // atualBotoesCima = new int[3] { 0, 0, 0 };
        yield return 0;
    }

    //Checkagem
    public IEnumerator CheckSequenciaBaixo()
    {
        painelAudioControllerScript.BotaoConfirma();
        if (Cookie.modeloPainel == 1)
        respostaCertaBaixo = new int[5] { 1, 0, 2, 3, 0 };

        if (Cookie.modeloPainel == 2)
            respostaCertaBaixo = new int[5] { 3, 1, 3, 1, 3 };

        if (Cookie.modeloPainel == 3)
            respostaCertaBaixo = new int[5] { 3, 2, 1, 1, 1 };


        botaoBaixoEmUso = true;
        botaoTBaixo.localEulerAngles = new Vector3(botaoTBaixo.localEulerAngles.x, botaoTBaixo.localEulerAngles.y, 8.4f);

        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < atualBotoesBaixo.Length; i++)
        {
            if (atualBotoesBaixo[i] != respostaCertaBaixo[i])
            {
                //Errou
                botaoTBaixo.localEulerAngles = new Vector3(botaoTBaixo.localEulerAngles.x, botaoTBaixo.localEulerAngles.y, -8.4f);
                StartCoroutine(LigaLuzVermelhoBaixo());
                break;
            }
            else
            {
                //Acertou
                venceuBaixo = true;
                StartCoroutine(LigaLuzVerdeBaixo());
            }
        }
        yield return 0;
    }

    public void Resetar()
    {
        venceuBaixo = false;
        venceuCima = false;
        botaoCimaEmUso = false;
        botaoBaixoEmUso = false;
        botaoTBaixo.localEulerAngles = new Vector3(botaoTBaixo.localEulerAngles.x, botaoTBaixo.localEulerAngles.y, -8.4f);
        botaoTCima.localEulerAngles = new Vector3(botaoTCima.localEulerAngles.x, botaoTCima.localEulerAngles.y, -8.4f);

        atualBotoesCima = new int[3] { 0, 0, 0 };
        atualBotoesBaixo = new int[5] { 0, 0, 0, 0, 0 };
        for (int i = 0; i < botoesBaixo.Length; i++)
        {
            botoesBaixo[i] = false;
            luzBaixo[i].intensity = 0;
        }

        for (int i = 0; i < botoesCima.Length; i++)
        {
            botoesCima[i] = false;
            luzCima[i].intensity = 0;
        }
    }
}
