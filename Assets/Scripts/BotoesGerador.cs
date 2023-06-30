using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesGerador : MonoBehaviour {

    public int index;
    private DesafioGerador geradorScript;

    // Use this for initialization
    void Start () {

        geradorScript = FindObjectOfType<DesafioGerador>();

    }
	
	// Update is called once per frame
	void Update () {


		
	}

    private void OnMouseDown()
    {
        geradorScript.apertaBotao(index);
    }
}
