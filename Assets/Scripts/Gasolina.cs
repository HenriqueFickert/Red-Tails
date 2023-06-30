using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gasolina : MonoBehaviour {

    public bool comecou;
    public bool umterco;
    public bool doistercos;
    public bool encheu;
    public bool funcionando;
  
   // public bool metade;

    public bool AsaEsq;
    public bool AsaDir;

    private Animator anim;

    private float tempo;

	// Use this for initialization
	void Start () {


        anim = GetComponent<Animator>();

        encheu = false;
        comecou = false;
        umterco = false;
        doistercos = false;

        anim.speed = 0.1f;
        tempo = 0;
      //  metade = false;

}
	
	// Update is called once per frame
	void Update () {
        
        if (AsaEsq)
        {

            if (funcionando)
            {
                if (comecou && !umterco)
                    anim.speed = 0.08f;

                if (umterco && !doistercos)
                    anim.speed = 0.17f;

                if (doistercos && !encheu)
                    anim.speed = 0.4f;
            }

        }
        //if (AsaDir)
       // {

     //   }




       
		
	}

    public void Comecou()
    {
        comecou = true;
    }


  //  public void Metade()
   // {
    //    metade = true;
   // }

    public void UmTerco()
    {
        
        umterco = true;

    }

    public void DoisTercos()
    {

        doistercos = true;
    }

    public void Encheu()
    {
        encheu = true;
    }
}
