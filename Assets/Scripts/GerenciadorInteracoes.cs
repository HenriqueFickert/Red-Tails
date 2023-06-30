using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorInteracoes : MonoBehaviour {

    public GameObject[] Dias;
    public bool[] TerminouDia;



    // Use this for initialization
    void Start () {

        for(int i = 0; i < 6; i++)
        {
            Dias[i].SetActive(false);
        }


      
     

    }
	
	// Update is called once per frame
	void Update () {

     if(FluxoTempo.dias == 1)
        {
            Dias[0].SetActive(true);
            Dias[1].SetActive(false);
            Dias[2].SetActive(false);
            Dias[3].SetActive(false);
            Dias[4].SetActive(false);
            Dias[5].SetActive(false);

        }

      if (FluxoTempo.dias == 2)
        {
            Dias[0].SetActive(false);
            Dias[1].SetActive(true);
            Dias[2].SetActive(false);
            Dias[3].SetActive(false);
            Dias[4].SetActive(false);
            Dias[5].SetActive(false);

        }

      if (FluxoTempo.dias == 3)
        {
            Dias[0].SetActive(false);
            Dias[1].SetActive(false);
            Dias[2].SetActive(true);
            Dias[3].SetActive(false);
            Dias[4].SetActive(false);
            Dias[5].SetActive(false);

        }

      if (FluxoTempo.dias == 4)
        {
            Dias[0].SetActive(false);
            Dias[1].SetActive(false);
            Dias[2].SetActive(false);
            Dias[3].SetActive(true);
            Dias[4].SetActive(false);
            Dias[5].SetActive(false);

        }

       if (FluxoTempo.dias == 5)
        {
            Dias[0].SetActive(false);
            Dias[1].SetActive(false);
            Dias[2].SetActive(false);
            Dias[3].SetActive(false);
            Dias[4].SetActive(true);
            Dias[5].SetActive(false);

        }

      if (FluxoTempo.dias == 6)
        {
            Dias[0].SetActive(false);
            Dias[1].SetActive(false);
            Dias[2].SetActive(false);
            Dias[3].SetActive(false);
            Dias[4].SetActive(false);
            Dias[5].SetActive(true);

        }

    }
}
