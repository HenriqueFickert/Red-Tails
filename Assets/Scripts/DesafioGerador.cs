using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioGerador : MonoBehaviour {

    public GameObject[] Botoes;
    public GameObject[] Marcadores;
    public GameObject alavanca;

    private float num1;
    private float num2;
    private float num3;


    // Use this for initialization
    void Start () {

        num1 = 0;
        num2 = 0;
        num3 = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

    //    Mathf.Clamp(Marcadores[0].transform.rotation.z, 0, 90);
    //    Mathf.Clamp(Marcadores[1].transform.rotation.z, 0, 90);
     //   Mathf.Clamp(Marcadores[2].transform.rotation.z, 0, 90);



     


    }

    public void apertaBotao(int index)
    {
        if(index == 1)
        {
            Marcadores[0].transform.Rotate(0, 0, 90);
            Marcadores[1].transform.Rotate(0, 0, 45);
        }

        if (index == 2)
        {
            Marcadores[1].transform.Rotate(0, 0, -45);
            Marcadores[2].transform.Rotate(0, 0, 45);
        }

        if (index == 3) { 
        
            Marcadores[0].transform.Rotate(0, 0, -45);
            Marcadores[1].transform.Rotate(0, 0, 90);
            Marcadores[2].transform.Rotate(0, 0, 45);
           
        }

        if (index == 4)
        {
            Marcadores[0].transform.Rotate(0, 0, 45);
            Marcadores[1].transform.Rotate(0, 0, 90);
            Marcadores[2].transform.Rotate(0, 0, -45);
        }


       

    }


    public void checaResposta()
    {

        if (num1 == 1 && num2 == 1 && num3 == 1)
        {
            //resposta certa
        }
        else
        {
            //reseta
        }
    }

    
}
