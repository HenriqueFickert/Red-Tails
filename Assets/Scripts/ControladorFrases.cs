using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorFrases : MonoBehaviour {

    public Text nomeHUD;
    public Text fraseHUD;

    public Animator anim;
    private int numRostoAtual;


    private Queue<string> frases;
    public GameObject BarraFalas;
    public GameObject[] Rostos;

    public DiaEspecifico[] Dias;

    private bool barraEstaAtiva;
    private float tempoAtual;
    private float tempoMax;

    private Fala falaEspecial;


	// Use this for initialization
	void Start () {

        frases = new Queue<string>();
        tempoAtual = 0;

        barraEstaAtiva = false;
        BarraFalas.SetActive(false);

        for(int i = 0; i < Rostos.Length; i++)
            Rostos[i].SetActive(false);
        
		
	}
	
	// Update is called once per frame
	void Update () {
     
        
        if (barraEstaAtiva)
            BarraFalas.SetActive(true);
        else
        {
            BarraFalas.SetActive(false);
            for (int i = 0; i < Rostos.Length; i++)
                Rostos[i].SetActive(false);
        }

    }


    public void ComecarDialogo(Fala fala)
    {
       

        if (!barraEstaAtiva)
        {
            falaEspecial = fala;

            anim.SetBool("IsOpen", true);
            Cursor.lockState = CursorLockMode.None;
            barraEstaAtiva = true;
           

            nomeHUD.text = fala.Nome;

            numRostoAtual = fala.NumRosto;
            Rostos[numRostoAtual].SetActive(true);

            frases.Clear();

            foreach (string frase in fala.Frase)
                frases.Enqueue(frase);

            

            MostraProxFrase();
        } 
    }

    public void MostraProxFrase()
    {
        if(frases.Count == 0)
        {
            TerminaConversa();

            return;
        }

    

        string fraseAtual = frases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Escrever(fraseAtual));

        if (falaEspecial.PelosDuasPessoasFalando && frases.Count != falaEspecial.Frase.Length - 1)
        {
            if (numRostoAtual == falaEspecial.NumRosto)
            {
                Rostos[numRostoAtual].SetActive(false);
                numRostoAtual = falaEspecial.NumRosto2;
                nomeHUD.text = falaEspecial.Nome2;
                Rostos[numRostoAtual].SetActive(true);

            }
            else
            {

                Rostos[numRostoAtual].SetActive(false);
                numRostoAtual = falaEspecial.NumRosto;
                nomeHUD.text = falaEspecial.Nome;
                Rostos[numRostoAtual].SetActive(true);

            }
        }

    }

    IEnumerator Escrever(string frase)
    {
        fraseHUD.text = "";

        foreach (char letra in frase.ToCharArray())
        {
            fraseHUD.text += letra;
            yield return null;
        }
        

    }


    public void TerminaConversa()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim.SetBool("IsOpen", false);

        if (FluxoTempo.dias == 2)
            Dias[0].SomaContador();

        if (FluxoTempo.dias == 3)
            Dias[1].SomaContador();

        if (FluxoTempo.dias == 4)
            Dias[2].SomaContador();

        if (FluxoTempo.dias == 5)
            Dias[3].SomaContador();
        //     Debug.Log("Acabou de conversar");
    }

    public void SomeHUD()
    {
        barraEstaAtiva = false;

    }
}
