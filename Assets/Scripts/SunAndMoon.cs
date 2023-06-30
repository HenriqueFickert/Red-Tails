using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SunAndMoon : MonoBehaviour {

   private Transform posicaoObjeto;
   private Transform posicaoInicial;

	void Start () {
        posicaoObjeto = GetComponent<Transform>();
        posicaoInicial = GameObject.Find("RefSol").GetComponent<Transform>();
    }
	

	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.right, Time.deltaTime * 0.02f);
        //transform.LookAt(Vector3.zero);  
        if (FluxoTempo.voltaSol) {
            FluxoTempo.voltaSol = false;
            MudaHora();
        }   
       
	}

    private void MudaHora()
    {
      posicaoObjeto.rotation = Quaternion.Lerp(posicaoObjeto.rotation, posicaoInicial.rotation, 50 * Time.deltaTime);
        // Rodar de volta pra 292.5 graus ou seja, 7:30 da manha
    }

    }


