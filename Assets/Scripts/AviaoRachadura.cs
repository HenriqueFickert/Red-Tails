using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaoRachadura : MonoBehaviour {

    public GameObject[] Buracos;
    public GameObject[] rachaduraAberta;
    public GameObject[] rachaduraFechada;

    private float tempo;
    private int numRamdom;

    public GameObject Placa;


	// Use this for initialization
	void Start () {

        for(int i = 0; i < Buracos.Length; i++)
        {
            Buracos[i].SetActive(true);
        }

        for (int j = 0; j < rachaduraAberta.Length; j++)
        {
            rachaduraAberta[j].SetActive(true);
        }

        for (int k = 0; k < rachaduraFechada.Length; k++)
        {
            rachaduraFechada[k].SetActive(false);
        }



    }
	



    public void Buraco(int index)
    {
        numRamdom = Random.Range(-2, 2);
        Buracos[index].SetActive(false);

        if (numRamdom >= 0)
            Instantiate(Placa, Buracos[index].transform.position, Quaternion.Euler(Random.Range(-105.7f,105), -19.65f,-90));
    }

    public void Rachadura(int index)
    {
        tempo += Time.deltaTime;
        if (tempo >= 3)
        {
            rachaduraAberta[index].SetActive(false);
            rachaduraFechada[index].SetActive(true);
            tempo = 0;
        }
    }


}
