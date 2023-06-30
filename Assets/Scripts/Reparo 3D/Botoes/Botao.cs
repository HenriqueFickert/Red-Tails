using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : Interaction
{
    private BotaoScript botaoScript;

    public bool cima;
    public int valorIndex;

    private Fios fios;
    void Start () {
        fios = GameObject.Find("DesafioFio").GetComponent<Fios>();
        botaoScript = FindObjectOfType<BotaoScript>();
    }

    void Update () {
		
	}

    public override void Executa()
    {
        if (fios.desafiosAtivos[2])
        {
            if (cima)
            {
                if (!botaoScript.botaoCimaEmUso)
                {

                    //Para os Botoes de Cima
                    if (valorIndex == 10)
                    {
                        botaoScript.StartCoroutine("CheckSequenciaCima");
                    }
                    else
                    {
                        StartCoroutine("AnimBotao");
                        botaoScript.botoesCima[valorIndex] = true;
                        botaoScript.atualBotoesCima[valorIndex] += 1;
                        StartCoroutine(botaoScript.LigaLuzCima(valorIndex));
                    }
                }
            }
            else
            {
                if (!botaoScript.botaoBaixoEmUso)
                {
                    //Para os Botoes de baixo
                    if (valorIndex == 10)
                    {
                        botaoScript.StartCoroutine("CheckSequenciaBaixo");
                    }
                    else
                    {
                        StartCoroutine("AnimBotao");
                        botaoScript.botoesBaixo[valorIndex] = true;
                        botaoScript.atualBotoesBaixo[valorIndex] += 1;
                        StartCoroutine(botaoScript.LigaLuzBaixo(valorIndex));
                    }
                }
            }
        }
    }


    private IEnumerator AnimBotao()
    {

        Vector3 pos = transform.localPosition;
        pos.x = pos.x + 0.02f;
        transform.localPosition = pos;

        yield return new WaitForSeconds(0.2f);

            pos = transform.localPosition;
            pos.x = pos.x - 0.02f;
            transform.localPosition = pos;

        yield return 0;
    }
}
