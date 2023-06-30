using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonaFogo : MonoBehaviour {

    public GameObject LonaInteira;
    public GameObject LonaDestruida;

    public GameObject Fogo;
    public GameObject Fumaca;

    public bool comecou;
    private bool apagou;
    private float tempo;

	// Use this for initialization
	void Start () {

        

        Fogo.SetActive(false);
        Fumaca.SetActive(false);
        LonaDestruida.SetActive(false);
        LonaInteira.SetActive(true);

        apagou = false;
        comecou = false;
        tempo = 0;
		
	}
	
	// Update is called once per frame
	void Update () {


        //LOGICA DE COMO O JOGADOR IRA APAGAR O FOGO



        if (comecou)
        {
            tempo += Time.deltaTime;
            Fogo.SetActive(true);
            Fumaca.SetActive(true);


            if(tempo > 15 && !apagou)
            {
                Fogo.SetActive(false);
                LonaDestruida.SetActive(true);
                LonaInteira.SetActive(false);
            }



        }

        if (apagou)
        {
            LonaInteira.SetActive(true);
            LonaDestruida.SetActive(false);
            Fogo.SetActive(false);
        }
		
	}
}
