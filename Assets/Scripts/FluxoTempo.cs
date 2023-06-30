using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class FluxoTempo : MonoBehaviour
{

    public static int dias;

    private float tempo;
    private float tempoescuro;

    public Text relogio;
    public Text numeroDia;

    public static int velocidade;

    public static bool trocadia;

    private int segundos;
    private int minutos;
    private int horas;

    public Animator animator;

    public static bool voltaSol = false;



    // Use this for initialization
    void Start()
    {
        dias = 1;
        velocidade = 10;
        trocadia = false;
        tempoescuro = 0;

        tempo = 27000; // 7:30 da manha

  

        
    }

    // Update is called once per frame
    void Update()
    {


        //Dezembro e Janeiro: amanhece 07:30 anoitece 16:40

        if (!trocadia)
        {
            tempo += Time.deltaTime * 240 * 0.02f;

            segundos = (int)(tempo % 60);
            minutos = (int)(tempo / 60) % 60;
            horas = (int)(tempo / 3600) % 24;

          if(horas <= 9 && minutos <= 9)
            relogio.text = "0"+ horas + ":0" + minutos;

          if (horas <= 9 && minutos > 9)
                relogio.text = "0" + horas + ":" + minutos;

            if (horas > 9 && minutos > 9)
                relogio.text =  horas + ":" + minutos;

            if (horas > 9 && minutos <= 9)
                relogio.text = horas + ":0" + minutos;
        }

        //aumentar numero de dias
        numeroDia.text = "Dia " + dias;

        if (horas >= 16 && minutos >= 35 && !trocadia)
        {
            FadeOut();
            trocadia = true;
            segundos = 0;
            minutos = 30;
            horas = 0;
            tempo = 27000; // 7:30 da manha
        }

        // Transicao
        if (trocadia)
        {
            
            tempoescuro += Time.deltaTime;
            if(tempoescuro > 3)
            {
                dias += 1;
                voltaSol = true;
                FadeIn();
                tempoescuro = 0;
                trocadia = false;
            }
        }

      

    }// fim update


    public void FadeIn()
    {
        animator.SetTrigger("Clareia");
    }

    public void FadeOut()
    {
        animator.SetTrigger("Escurece");
    }






    public void ResetaDia()
    {



    }

    public void EncerraDia()
    {

    }

}




