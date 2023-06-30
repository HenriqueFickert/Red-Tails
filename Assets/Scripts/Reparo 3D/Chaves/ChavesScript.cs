using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChavesScript : MonoBehaviour {
    private PainelAudioController painelAudioControllerScript;

    private int[] sequenciaAtual = new int[6];
    private int[] sequenciaCerta = new int[6];

    public Cookie cookieFunc;

    public GameObject botaoConfirma;
    public bool estaClickado;

    public bool estaErrado;
    private Fios fios;

    //PARA SETAR O RESET
    public bool resetar;

    public bool venceuDChaves = false;
    private bool playsomvitoria;

    void Start()
    {
        painelAudioControllerScript = GameObject.Find("PainelAviao").GetComponent<PainelAudioController>();
        fios = GameObject.Find("DesafioFio").GetComponent<Fios>();
        
        for (int i = 0; i < sequenciaAtual.Length; i++)
        {
            sequenciaAtual[i] = 0;
        }

        if (venceuDChaves)
        {
            if (!playsomvitoria)
            {
                print("oi");
                painelAudioControllerScript.Certo();
                playsomvitoria = true;
            }
        }
    }

    //BOTAO DE CONFIRMAR
    public IEnumerator Check() {
        if (fios.desafiosAtivos[1])
        {


            if (Cookie.modeloPainel == 1)
                sequenciaCerta = new int[6] { 0, 0, 1, 2, 3, 4 };

            if (Cookie.modeloPainel == 2)
                sequenciaCerta = new int[6] { 1, 3, 1, 4, 2, 0 };

            if (Cookie.modeloPainel == 3)
                sequenciaCerta = new int[6] { 4, 0, 0, 0, 0, 3 };



            estaClickado = true;
            Vector3 pos = botaoConfirma.transform.localPosition;
            pos.x = pos.x + 0.02f;
            botaoConfirma.transform.localPosition = pos;

            yield return new WaitForSeconds(0.5f);

            pos = botaoConfirma.transform.localPosition;
            pos.x = pos.x - 0.02f;
            botaoConfirma.transform.localPosition = pos;

            for (int i = 0; i < sequenciaCerta.Length; i++)
            {
                if (sequenciaAtual[i] != sequenciaCerta[i])
                {
                    estaErrado = true;
                    estaClickado = false;
                    cookieFunc.Errou();
                    break;
                }
                else
                {
                    venceuDChaves = true;
                    estaClickado = true;
                    //SE ESTIVER CERTO
                }
            }

            yield return 0;
        }
    }

    //PEGA O INDEX DAS CHAVES
    public void PegaIndex(int index, int valorPos) {
        sequenciaAtual[index] = valorPos;
    }

}
