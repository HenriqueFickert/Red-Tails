using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaoPegandoFogo : MonoBehaviour {

    public GameObject[] Fogo;
    public GameObject[] Fumaca;
    public GameObject Faiscas;

    // public GameObject Explosao;

    public Mapa map;

    //public bool comecou;
    private float tempo;

    // Use this for initialization
    void Start () {

        Faiscas.SetActive(false);

      

    }

    // Update is called once per frame
    void Update () {



       

    }

    public void TocaChao()
    {
        Faiscas.SetActive(true);
    }

    public void Fade()
    {
        map.FadeOut();
    }

}

