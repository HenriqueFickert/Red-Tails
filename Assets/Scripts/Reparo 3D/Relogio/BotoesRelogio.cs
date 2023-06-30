using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesRelogio : MonoBehaviour {

   private RelogioScript relogioScript;

    public int indexBotao;

	void Start () {
        relogioScript = GetComponentInParent<RelogioScript>();
	}

    private void OnMouseDown()
    {

        if (!relogioScript.botaoAtivo && indexBotao == relogioScript.indexRelogio && relogioScript.indexRelogio >= 0 && relogioScript.indexRelogio <= 2)
        {
            relogioScript.botaoAtivo = true;
            relogioScript.StartCoroutine("Checkagem");
        }
    }

}
