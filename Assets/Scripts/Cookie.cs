using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cookie : MonoBehaviour {

  
    public GameObject HUDPergunta;
    public GameObject duvida;
    public GameObject marcadorErros;
    public GameObject ponteiro;

    public static int numDesafio;
    public static int modeloPainel;
    public static int numErros;

    public Text fraseDesafio;
    public GameObject HUDDuvida;
    private bool falando;
    private float tempoFala;

 

   // public RadioScript respostaRadio;
    public RelogioScript respostaRelogio;


    // Use this for initialization
    void Start () {

        HUDPergunta.SetActive(false);
        duvida.SetActive(false);
        marcadorErros.SetActive(false);
        HUDDuvida.SetActive(false);
        
        modeloPainel = 0;
        tempoFala = 0;
        falando = false;



        numDesafio = 0;
        numErros = 1;
        
    }

    // Update is called once per frame
    void Update () {
		
        if(numErros >=4)
        {
            numErros = 1;
            resetaPainel();
        }


        if (falando)
        {
            HUDDuvida.SetActive(true);
        }
        else
        {
            HUDDuvida.SetActive(false);
        }





	}

    public void PerguntaPainel()
    {

        HUDPergunta.SetActive(true);     
    }

    public void Model1()
    {
        modeloPainel = 1;
        HUDPergunta.SetActive(false);
        duvida.SetActive(true);
        marcadorErros.SetActive(true);
    }

    public void Model2()
    {
        modeloPainel = 2;
        HUDPergunta.SetActive(false);
        duvida.SetActive(true);
        marcadorErros.SetActive(true);
    }

    public void Model3()
    {
        modeloPainel = 3;
        HUDPergunta.SetActive(false);
        duvida.SetActive(true);
        marcadorErros.SetActive(true);
    }

    public void Duvida()
    {
        //pegar referencia do desafio atual em que o jogador esta
        //falar alguma coisa baseado nisso

        if (!falando)
            falando = true;
        else
            falando = false;
      
    

        //BOTOES
        if(numDesafio == 1)
        {
            if (modeloPainel == 1)
            {
                fraseDesafio.text = "Na fileira de cima, aperte o 1º botão 1 vez, o 2º 2 vezes e o 3º 3 vezes. Já na fileira de baixo, o 1º 1 vez, o 2º 0 vezes, o 3º 2 vezes, o 4º 3 vezes e o 5º 0 vezes";




            //    if (Cookie.modeloPainel == 1)
              //      respostaCertaCima = new int[3] { 1, 2, 3 };

               // if (Cookie.modeloPainel == 2)
               //     respostaCertaCima = new int[3] { 4, 0, 1 };

             //   if (Cookie.modeloPainel == 3)
              //      respostaCertaCima = new int[3] { 3, 2, 3 };

                //   if (Cookie.modeloPainel == 1)
                //   respostaCertaBaixo = new int[5] { 1, 0, 2, 3, 0 };

                // if (Cookie.modeloPainel == 2)
                //    respostaCertaBaixo = new int[5] { 3, 1, 3, 1, 3 };

                //  if (Cookie.modeloPainel == 3)
                //    respostaCertaBaixo = new int[5] { 3, 2, 1, 1, 1 };



            }

            if (modeloPainel == 2)
            {
                fraseDesafio.text = "Na fileira de cima, aperte o 1º botão 4 vezes, o 2º 0 vezes e o 3º 1 vez. Já na fileira de baixo, o 1º 3 vezes, o 2º 1 vez, o 3º 3 vezes, o 4º 1 vez e o 5º 3 vezes";
            }

            if (modeloPainel == 3)
            {
                fraseDesafio.text = "Na fileira de cima, aperte o 1º botão 3 vezes, o 2º 2 vezes e o 3º 3 vezes. Já na fileira de baixo, o 1º 3 vezes, o 2º 2 vezes, o 3º 1 vez, o 4º 1 vez e o 5º 1 vez";
            }
        }

        //RADIO
        if (numDesafio == 2)
        {
            fraseDesafio.text = "Essa música é muito boa, pena que chiado está atrapalhando";
        }

        //RELOGIO
        if (numDesafio == 3)
        {
            fraseDesafio.text = "O ponteiro do relógio deve estar em "+(respostaRelogio.rotAlvo + 40f)+" graus. Depois de posicionar ele, me pergunte a posição do próximo";
        }

        //CHAVES
        if (numDesafio == 4)
        {
            if (modeloPainel == 1)
            {
                fraseDesafio.text = "A posição das chaves deve ser: centro, centro, cima, baixo, direita, esquerda. ";
            }

            if (modeloPainel == 2)
            {
                fraseDesafio.text = "A posição das chaves deve ser: cima, direita, cima, esquerda, baixo, centro. ";
            }

            if (modeloPainel == 3)
            {
                fraseDesafio.text = "A posição das chaves deve ser: esquerda, centro, centro, centro, centro, direita ";
            }
        }

        //FIOS
        if (numDesafio == 5)
        {
            fraseDesafio.text = "Cuidado para levar um choque! Esses fios controlam que parte do painel está ativa, e do jeito que estão não parecem muito confiáveis...";
        }

        //MODELO
        if (numDesafio == 6)
        {
            fraseDesafio.text = "Esse painel parece antigo, será que está tudo em ordem...";
        }


        //PAINEL
        if (numDesafio == 7)
        {
            fraseDesafio.text = "Esse painel parece antigo, será que está tudo em ordem...";
        }







    }

    public void resetaPainel()
    {
        ponteiro.transform.Rotate(0, 0, 120);

        //Resetar Painel
    }

    public void Errou()
    {
        //ponteiro.transform.Rotate(0,0,-60);
       // numErros++;

    }
}
