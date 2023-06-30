using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : Interaction {
    private PainelAudioController painelAudioControllerScript;

    ChavesScript chavesScript;

    public int valorIndex;

    Vector3 posMouse;

   private bool estaAtivo;
    private Fios fios;

    private bool somReset;

    void Start () {
        painelAudioControllerScript = GameObject.Find("PainelAviao").GetComponent<PainelAudioController>();
        fios = GameObject.Find("DesafioFio").GetComponent<Fios>();
        chavesScript = FindObjectOfType<ChavesScript>();
    }
	

	void Update () {

        if (somReset)
        {
            painelAudioControllerScript.ResetChaves();
            somReset = false;
        }

        if (fios.desafiosAtivos[1])
        {
            //SOLTAR DA CHAVE
            if (estaAtivo)
            {

                if (Input.GetMouseButtonUp(0))
                {
                    Vector3 direcaoMouseAtual = (Input.mousePosition - posMouse);
                    float angulo = Vector3.SignedAngle(Vector3.right, direcaoMouseAtual, Vector3.forward);
                    //  print(angulo);

                    if (angulo == 0)
                    {
                        chavesScript.PegaIndex(valorIndex, 0);
                    }
                    else if (angulo >= 45 && angulo <= 135)
                    {
                        transform.localEulerAngles = new Vector3(0, 0, -30);
                        chavesScript.PegaIndex(valorIndex, 1);
                    }
                    else if (angulo <= -45 && angulo >= -135)
                    {
                        transform.localEulerAngles = new Vector3(0, 0, 30);
                        chavesScript.PegaIndex(valorIndex, 2);
                    }
                    else if (Mathf.Abs(angulo) < 45)
                    {
                        transform.localEulerAngles = new Vector3(0, -30, 0);
                        chavesScript.PegaIndex(valorIndex, 3);
                    }
                    else
                    {
                        transform.localEulerAngles = new Vector3(0, 30, 0);
                        chavesScript.PegaIndex(valorIndex, 4);
                    }
                    painelAudioControllerScript.ClickChaves();
                    estaAtivo = false;
                }
            }
        }

        //PARA RESETAR OU APLICAR O ERRADO
        if (chavesScript.resetar)
        {
            StartCoroutine("Reseta");
        }
        if (chavesScript.estaErrado)
        {
            StartCoroutine("Errado");
        }
    }

    //CLICK DA CHAVE
    private void OnMouseDown()
    {
        if (fios.desafiosAtivos[1])
        {
            if (!chavesScript.estaClickado)
            {
                posMouse = (Input.mousePosition);
                transform.localEulerAngles = new Vector3(0, 0, 0);
                estaAtivo = true;
                chavesScript.PegaIndex(valorIndex, 0);
            }
        }
    }

    //CHECKA SE ESTA ERRADO
    IEnumerator Errado() {
        painelAudioControllerScript.Errado();
        transform.localEulerAngles = new Vector3(0, 0, 0);
        chavesScript.PegaIndex(valorIndex, 0);
        yield return new WaitForSeconds(0.2f);
        chavesScript.estaErrado = false;
        yield return 0;
    }

    IEnumerator Reseta()
    {
        somReset = true;
        transform.localEulerAngles = new Vector3(0, 0, 0);
        chavesScript.PegaIndex(valorIndex, 0);
        yield return new WaitForSeconds(0.3f);
        chavesScript.resetar = false;
        yield return 0;
    }

}
