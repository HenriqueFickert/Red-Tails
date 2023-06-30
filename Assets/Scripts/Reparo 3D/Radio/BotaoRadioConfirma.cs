using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoRadioConfirma : MonoBehaviour {


    public RadioScript radioScript2;

	void Start () {
		
	}

	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (!radioScript2.botaoChecked)
        {
            radioScript2.StartCoroutine("Check");
        }
    }

}
