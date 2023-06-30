using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLivroAnimation : MonoBehaviour {

    CreditosController creditosControllerScript;
	void Start () {
        creditosControllerScript = GetComponentInParent<CreditosController>();

    }
	

    public void AnimIda()
    {
       // creditosControllerScript.TrocaTexturaProx();
    }
    public void AnimVolta()
    {
      //  creditosControllerScript.TrocaDeTexturaPrev();
    }

    public void AnimClickFinal()
    {
      //  creditosControllerScript.FinalClick();
    }
}
