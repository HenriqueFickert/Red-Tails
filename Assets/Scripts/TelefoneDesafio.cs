using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelefoneDesafio : MonoBehaviour {

    public GameObject[] Estilhacos;
    private float tempo;

    // Use this for initialization
    void Start () {
        tempo = 0;

        for (int i = 0; i < Estilhacos.Length; i++)
        {
            Estilhacos[i].SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {

        //contando o tempo que ele tem pra tirar os estilhacos -- pouco tempo

        //clica no estilhaco para oculta-lo
        //  if()
        //Estilhacos[i].SetActive(false);
	}



    public void Estilhaco(int index)
    {
        
        Estilhacos[index].SetActive(false);

       
    }
}
