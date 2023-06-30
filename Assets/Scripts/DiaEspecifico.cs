using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaEspecifico : MonoBehaviour {

    public GameObject[] Falas;
    private int Contador;

    // Use this for initialization
    void Start () {

        Contador = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

        for(int i = 0; i < Falas.Length; i++)
        {
            if (i != Contador)
                Falas[i].SetActive(false);
            else
                Falas[i].SetActive(true);
        }



        print(Contador);
        

    }

    public void SomaContador()
    {
        Contador++;
    }
}
