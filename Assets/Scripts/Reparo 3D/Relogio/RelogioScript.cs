using System.Collections;
using UnityEngine;

public class RelogioScript : MonoBehaviour
{

    private PainelAudioController painelAudioControllerScript;

    public Transform rotAtual1;
    public Transform rotAtual2;
    public Transform rotAtual3;

    public Cookie cookieFunc;

    public float rotAlvo;
    public float velocidade;
    private float velRot;
    private float rotPositivo;

    public float limite;

    private int numDeVoltas;

    public GameObject[] botoes;

    public bool botaoAtivo;
    private bool botoesAtivo;

    public int indexRelogio = 0;

    public bool venceuDRelogio;

    private Fios fios;


    private void Start()
    {
        painelAudioControllerScript = GameObject.Find("PainelAviao").GetComponent<PainelAudioController>();
        fios = GameObject.Find("DesafioFio").GetComponent<Fios>();
        

        rotPositivo = 0;
        rotAtual1.localEulerAngles = new Vector3(0, 0, 0);
        rotAlvo = Random.Range(1, 361);

        numDeVoltas = 0;

        velRot = 0;
    }


    private void Update()
    {
        //Comeca o desafio
        if (fios.desafiosAtivos[3])
        {
            //Se estiver no valor do index dos botoes
            if (indexRelogio >= 0 && indexRelogio <= 2)
            {
                velRot -= velocidade * Time.deltaTime;
                //Se der chegar em 360 conta umam volta
                if (velRot <= -360)
                {
                    velRot = 0;
                    numDeVoltas++;
                   // painelAudioControllerScript.VoltaRelogio();
                }

                rotPositivo = velRot * (-1);

                //Qual Seta vai se movimentar e aplica a velicudade
                if (indexRelogio == 0)
                {
                    rotAtual1.localEulerAngles = new Vector3(velRot, 0, 0);
                }
                else if (indexRelogio == 1)
                {
                    velocidade = 100;
                    rotAtual2.localEulerAngles = new Vector3(velRot, 0, 0);
                }
                else if (indexRelogio == 2)
                {
                    velocidade = 200;
                    rotAtual3.localEulerAngles = new Vector3(velRot, 0, 0);
                }

                //Se o numero de voltar for 3 ele reseta o valor de voltas e gera um novo alvo
                if (numDeVoltas == 3)
                {
                    numDeVoltas = 0;
                  //  Reseta();
                }

            }
        }

    }

    public IEnumerator Checkagem()
    {
        if (fios.desafiosAtivos[3])
        {
            painelAudioControllerScript.BotaoConfirma();
            if (indexRelogio >= 0 && indexRelogio <= 2)
            {
                //Verificar se o o rot alvo + o limite passou de 360 e verificar se o rotalvo - o limite e menor que 0 e faz a condicao de vitoria
                if (rotPositivo <= rotAlvo + limite && rotPositivo >= rotAlvo - limite)
                {
                    //Se o jogador acerto ele abaixa o botao
                    if (!botoesAtivo)
                    {
                        Vector3 pos = botoes[indexRelogio].transform.localPosition;
                        pos.x = pos.x + 0.015f;
                        botoes[indexRelogio].transform.localPosition = pos;
                    }
                    //verifica se esta entre 0 e 2 para passar para o proximo relogio
                    if (indexRelogio >= 0 && indexRelogio < 2)
                    {
                        numDeVoltas = 0;
                        indexRelogio++;
                        RandomizaAlvo();
                    }
                    //se nao ele conta como vitoria
                    else
                    {
                        painelAudioControllerScript.Certo();
                        venceuDRelogio = true;
                        indexRelogio = 5;
                        botoesAtivo = true;
                    }
                    velRot = 0;

                }
                //Se ele errou
                else
                {
                    painelAudioControllerScript.Errado();
                    cookieFunc.Errou();
                    if (indexRelogio >= 0 && indexRelogio <= 2)
                    {
                        //Abaixa e sobe o botao
                        if (!botoesAtivo)
                        {
                            Vector3 pos = botoes[indexRelogio].transform.localPosition;
                            pos.x = pos.x + 0.015f;
                            botoes[indexRelogio].transform.localPosition = pos;

                            yield return new WaitForSeconds(0.2f);

                            pos = botoes[indexRelogio].transform.localPosition;
                            pos.x = pos.x - 0.015f;
                            botoes[indexRelogio].transform.localPosition = pos;
                        }
                    }

                }
                botaoAtivo = false;
            }
        }
        yield return 0;
    }

    private void RandomizaAlvo()
    {
        rotAlvo = Random.Range(1, 361);
    }


    public void Reseta()
    {
        //Botoes
        Vector3 pos = botoes[0].transform.localPosition;
        pos.x = pos.x - 0.015f;
        botoes[0].transform.localPosition = pos;

        pos = botoes[1].transform.localPosition;
        pos.x = pos.x - 0.015f;
        botoes[1].transform.localPosition = pos;

        pos = botoes[2].transform.localPosition;
        pos.x = pos.x - 0.015f;
        botoes[2].transform.localPosition = pos;

        indexRelogio = 0;
        botaoAtivo = false;
        numDeVoltas = 0;
    }
}
