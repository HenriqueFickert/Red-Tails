using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoConfirma : Interaction {

    public ChavesScript chavesScript;

	void Start () {
		
	}
	
	
	void Update () {
		
	}

    public override void Executa()
    {
        if (!chavesScript.estaClickado)
        {
            chavesScript.StartCoroutine("Check");
        }
    }
}
