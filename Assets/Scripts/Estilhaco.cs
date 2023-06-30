using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estilhaco : MonoBehaviour {

    public int index;
    private TelefoneDesafio telefoneDesafioScript;

    // Use this for initialization
    void Start () {

        telefoneDesafioScript = FindObjectOfType<TelefoneDesafio>();

    }
	
	// Update is called once per frame
	void Update () {

        telefoneDesafioScript.Estilhaco(index);

    }
}
