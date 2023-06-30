using UnityEngine;

public class Fios : MonoBehaviour
{

    private PainelAudioController painelAudioControllerScript;

    public GameObject[] fiosC;
    public GameObject[] fiosE;

    private float[] tempo = new float[4];

    public Light[] luz;

    public float[] tempoMaxD;

    public GameObject[] panelHUD;

    private bool[] jaMostrouPainel = new bool[4];

    public bool[] desafiosAtivos;

    //SCRIPTS
    private BotaoScript botaoScript;
    private ChavesScript chavesScript;
    private RadioScript radioScript;
    private RelogioScript relogioScript;

    void Start()
    {
        painelAudioControllerScript = GameObject.Find("PainelAviao").GetComponent<PainelAudioController>();
        botaoScript = GameObject.Find("DesafioBotoes").GetComponent<BotaoScript>();
        chavesScript = GameObject.Find("DesafioChaves").GetComponent<ChavesScript>();
        radioScript = GameObject.Find("DesafioRadio").GetComponent<RadioScript>();
        relogioScript = GameObject.Find("DesafioRelogio").GetComponent<RelogioScript>();

        for (int i = 0; i < fiosC.Length; i++)
        {
            fiosC[i].SetActive(false);
            jaMostrouPainel[i] = false;
            tempo[i] = 0;
        }

    }


    void Update()
    {

        //ATIVA DESAFIO DO RADIO
        if (fiosC[0].activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && jaMostrouPainel[0])
            {
                panelHUD[0].SetActive(false);
                desafiosAtivos[0] = true;
            }

            if (!jaMostrouPainel[0])
            {
                panelHUD[0].SetActive(true);
                jaMostrouPainel[0] = true;
            }


            if (desafiosAtivos[0] && !radioScript.venceuDRadio)
            {
                tempo[0] += Time.deltaTime;
                luz[0].intensity = 2;
                luz[0].intensity += tempo[0] * 0.05f;
                luz[0].color = Color.Lerp(luz[0].color, Color.red, 0.001f);
                if (tempo[0] >= tempoMaxD[0])
                {

                    radioScript.StartCoroutine("Resetar");

                    fiosC[0].SetActive(false);
                    fiosE[0].SetActive(true);
                    luz[0].intensity = 0;
                    tempo[0] = 0;
                    desafiosAtivos[0] = false;
                    painelAudioControllerScript.FioEstourando(0);
                }
            }

            if (radioScript.venceuDRadio)
            {
                luz[0].color = Color.green;
                luz[0].intensity = 10;
            }
        }

        //ATIVA O DESAFIO DAS CHAVES
        if (fiosC[1].activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && jaMostrouPainel[1])
            {
                panelHUD[1].SetActive(false);
                desafiosAtivos[1] = true;
            }

            if (!jaMostrouPainel[1])
            {
                panelHUD[1].SetActive(true);
                jaMostrouPainel[1] = true;
            }


            if (desafiosAtivos[1] && !chavesScript.venceuDChaves)
            {
                tempo[1] += Time.deltaTime;
                luz[1].intensity = 2;
                luz[1].intensity += tempo[1] * 0.05f;
                luz[1].color = Color.Lerp(luz[1].color, Color.red, 0.001f);
                if (tempo[1] >= tempoMaxD[1])
                {
                    chavesScript.resetar = true;
                    fiosC[1].SetActive(false);
                    fiosE[1].SetActive(true);
                    luz[1].intensity = 0;
                    tempo[1] = 0;
                    desafiosAtivos[1] = false;
                    painelAudioControllerScript.FioEstourando(1);
                }
            }

            if (chavesScript.venceuDChaves)
            {
                luz[1].color = Color.green;
                luz[1].intensity = 10;
            }

        }

        //ATIVA O DESAFIO DOS BOTOES
        if (fiosC[2].activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && jaMostrouPainel[2])
            {
                panelHUD[2].SetActive(false);
                desafiosAtivos[2] = true;
            }

            if (!jaMostrouPainel[2])
            {
                panelHUD[2].SetActive(true);
                jaMostrouPainel[2] = true;
            }


            if (desafiosAtivos[2] && !botaoScript.venceuDBotao)
            {
                tempo[2] += Time.deltaTime;
                luz[2].intensity = 2;
                luz[2].intensity += tempo[2] * 0.05f;
                luz[2].color = Color.Lerp(luz[2].color, Color.red, 0.001f);
                if (tempo[2] >= tempoMaxD[2])
                {
                    botaoScript.Resetar();
                    fiosC[2].SetActive(false);
                    fiosE[2].SetActive(true);
                    luz[2].intensity = 0;
                    tempo[2] = 0;
                    desafiosAtivos[2] = false;
                    painelAudioControllerScript.FioEstourando(2);
                }
            }

            if (botaoScript.venceuDBotao)
            {
                luz[2].color = Color.green;
                luz[2].intensity = 10;
            }
        }

        //ATIVA O DESAFIO DOS RELOGIOS
        if (fiosC[3].activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && jaMostrouPainel[3])
            {
                panelHUD[3].SetActive(false);
                desafiosAtivos[3] = true;
            }

            if (!jaMostrouPainel[3])
            {
                panelHUD[3].SetActive(true);
                jaMostrouPainel[3] = true;
            }


            if (desafiosAtivos[3] && !relogioScript.venceuDRelogio)
            {
                tempo[3] += Time.deltaTime;
                luz[3].intensity = 2;
                luz[3].intensity += tempo[3] * 0.05f;
                luz[3].color = Color.Lerp(luz[3].color, Color.red, 0.001f);
                if (tempo[3] >= tempoMaxD[3] )
                {
                    relogioScript.Reseta();
                    fiosC[3].SetActive(false);
                    fiosE[3].SetActive(true);
                    luz[3].intensity = 0;
                    tempo[3] = 0;
                    desafiosAtivos[3] = false;
                    painelAudioControllerScript.FioEstourando(3);
                }
            }

            if (relogioScript.venceuDRelogio)
            {
                luz[3].color = Color.green;
                luz[3].intensity = 10;
            }

        }


    }

    //PEGA O INDEX DO FIO CLICADO
    public void AtivaFio(int index)
    {
        fiosC[index].SetActive(true);
        fiosE[index].SetActive(false);
        painelAudioControllerScript.FioClick(index);
    }
}
