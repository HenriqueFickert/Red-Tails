using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioHelice : MonoBehaviour {

    public GameObject helice;
    private float modificador;
    private bool podeApertar;
    private float tempo;
	// Use this for initialization
	void Start () {
        podeApertar = true;
        tempo = 0;
        modificador = 1;
	}
	
	// Update is called once per frame
	void Update () {

        helice.transform.Rotate(15*Time.deltaTime*modificador,0,0);




        if (Input.GetMouseButtonDown(0) && podeApertar && modificador <= 110)
            modificador+=10;

        if (modificador > 70)
        {
            tempo += Time.deltaTime;

            if (tempo > 10)
            {
                tempo = 0;
                podeApertar = false;
            }
        }
        else
            tempo = 0;

        if(modificador>1 && podeApertar)
        modificador -= 25 * Time.deltaTime;

        //Debug.Log("Modificador:" + modificador);
        
		
	}
}
