using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matriz : MonoBehaviour {

    public GameObject CaixaNaMao;

    //int linhas, colunas;
   // private float timer;
    public static bool estaComCaixa;

  //  int [,] EspacoFrente;
  //  int [,] EspacoTras;

   // public GameObject[] Caixas;

    public static int numItensPegos;
 

   // private Vector2 EspacoVazio;
   // private Vector2 UltimoEspacoClicado;

    // Use this for initialization
    void Start () {

        estaComCaixa = false;

      //  linhas = 4;
       // colunas = 4;

      //  timer = 0;
        numItensPegos = 0;
/*
        EspacoVazio = new Vector2(1, 2);

        UltimoEspacoClicado = new Vector2(1, 2);



        EspacoFrente = new int[,] {

            { 0, 1, 0, 1 },
            { 1, 0, 1, 0 },
            { 0, 1, 0, 1 },
            { 1, 0, 1, 0 }
        };

        EspacoTras = new int[,] {

            { 1, 0, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 0 },
            { 1, 0, 0, 0 }
        };

        */
    }
	
	// Update is called once per frame
	void Update () {

   
      
        
/*
        // PRINTAR MATRIZ NO CONSOLE

        string msg = "";
        for (int j = 0; j < linhas; j++)
        {
            for (int k = 0; k < colunas; k++)
            {
                msg += EspacoFrente[j, k].ToString();
            }
            msg += "\n";
        }
      //  print(msg);
      */

       
/*
        //OCULTAR E DESOCULTAR AS CAIXAS

        for (int j = 0; j < linhas; j++)
        {
            for (int k = 0; k < colunas; k++)
            {


                // LINHA 1
                if (j == 0) {
                    if (EspacoFrente[j, k] == 0)
                        Caixas[k].SetActive(false);
                    else
                        Caixas[k].SetActive(true);
                }

                // LINHA 2
                if (j == 1)
                {
                    if (EspacoFrente[j, k] == 0)
                        Caixas[k+4].SetActive(false);
                    else
                        Caixas[k+4].SetActive(true);
                }

                // LINHA 3
                if (j == 2)
                {
                    if (EspacoFrente[j, k] == 0)
                        Caixas[k+8].SetActive(false);
                    else
                        Caixas[k+8].SetActive(true);
                }

                // LINHA 4
                if (j == 3)
                {
                    if (EspacoFrente[j, k] == 0)
                        Caixas[k+12].SetActive(false);
                    else
                        Caixas[k+12].SetActive(true);
                }
            }
            
        }
       */

        if (estaComCaixa)
            CaixaNaMao.SetActive(true);
        else
            CaixaNaMao.SetActive(false);


    }


    /* Se mao esta vazia && clicou em algum dos espacos adjacentes ao espaco vazio(vector2){
     * espaco clicado fica vazio ( alterar o valor na matriz)
     * ultimo espaco clicado(vector2) se torna o local clicado
     * mao fica cheia
     *  
     * 
     * }
     * 
     * 
     * Se mao nao esta cheia && clicou em algum espaco vazio que corresponda a algum dos dois vector 2{
     * espaco clicado fica ocupado (alterar o valor na matriz)
     * mao fica vazia
     * espaco vazio(vector2) = ultimo espaco clicado(vector2)
     * ultimo espaco clicado(vector2) = lugar onde ele clicou
     * }
     * 
     * 
     * Se eu cliquei no item && estou com a mao vazia && nesse local da matriz esta vazio{
     * 
     * item some
     * contador de itens pegos aumenta em 1
     * 
     * }
     * 
     * 
     * se o contador for igual a 3 o desafio acaba
     * 
     * 
     * 
    */    
}



