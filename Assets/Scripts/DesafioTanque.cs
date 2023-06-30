using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioTanque : MonoBehaviour {

    private bool ladoEsq;

    public GameObject galaoDir;
    public GameObject galaoEsq;

    public Animator gasEsq1;
    public Gasolina nivelEsq1;
    public Animator gasEsq2;
    public Gasolina nivelEsq2;
    public Animator gasEsq3;
    public Gasolina nivelEsq3;

    public Animator gasDir1;
    public Gasolina nivelDir1;
    public Animator gasDir2;
    public Gasolina nivelDir2;
    public Animator gasDir3;
    public Gasolina nivelDir3;

    private float tempoesq;
    private float tempodir;

    private int numRecipiente;

    // Use this for initialization
    void Start () {

        ladoEsq = true;
        galaoEsq.SetActive(true);

       
        galaoDir.SetActive(false);

      //  gasEsq1.speed = 0.1f;
        

        numRecipiente = 0;

        tempodir = 0;
        tempoesq = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

       

        if (ladoEsq)
        {
            if (numRecipiente == 0)
                gasEsq1.SetBool("Subir", true);

            if (numRecipiente == 1)
                gasEsq2.SetBool("Subir", true);

            if (numRecipiente == 2)
                gasEsq3.SetBool("Subir", true);

            if (numRecipiente == 3)
            {
                ladoEsq = false;
                galaoEsq.SetActive(false);
                galaoDir.SetActive(true);
                gasDir1.SetBool("Subir", true);
            }
        }
        else
        {
            if (nivelDir1.comecou && nivelDir1.funcionando)
                gasDir1.speed = 0.2f;
            if(numRecipiente == 4)
                gasDir2.SetBool("Subir", true);

            if (nivelDir2.comecou && nivelDir2.funcionando)
                gasDir2.speed = 0.4f;
            if (numRecipiente == 5)
                gasDir3.SetBool("Subir", true);

            if (nivelDir3.comecou && nivelDir3.funcionando)
                gasDir3.speed = 1f;
         //   if (nivelDir1.encheu)
               



        }


        if (Input.GetKeyDown(KeyCode.Space) && numRecipiente < 6)
        {
            numRecipiente++;

         //    Debug.Log("apertou espaco");

            if (numRecipiente == 1 && nivelEsq1.comecou && !nivelEsq1.encheu && nivelEsq1.funcionando)
            {
                nivelEsq1.funcionando = false;
                gasEsq1.speed = 0;
            }

            if (numRecipiente == 2 && nivelEsq2.comecou && !nivelEsq2.encheu && nivelEsq2.funcionando)
            {
                nivelEsq2.funcionando = false;
                gasEsq2.speed = 0;
            }

            if (numRecipiente == 3 && nivelEsq3.comecou && !nivelEsq3.encheu && nivelEsq3.funcionando)
            {
                nivelEsq3.funcionando = false;
                gasEsq3.speed = 0;
            }

            if (numRecipiente == 4 && nivelDir1.comecou && !nivelDir1.encheu && nivelDir1.funcionando)
            {
                nivelDir1.funcionando = false;
                gasDir1.speed = 0;
            }

            if (numRecipiente == 5 && nivelDir2.comecou && !nivelDir2.encheu && nivelDir2.funcionando)
            {
                nivelDir2.funcionando = false;
                gasDir2.speed = 0;
            }

            if (numRecipiente == 6 && nivelDir3.comecou && !nivelDir3.encheu && nivelDir3.funcionando)
            {
                nivelDir3.funcionando = false;
                gasDir3.speed = 0;
            }


        }

        if(numRecipiente < 3)
            tempoesq += Time.deltaTime;

        
        else if (numRecipiente >= 3 && numRecipiente < 6)
            tempodir += Time.deltaTime;


    //    Debug.Log("Tempo Esq:" + tempoesq);
    //    Debug.Log("Tempo Dir:" + tempodir);


    }
}
