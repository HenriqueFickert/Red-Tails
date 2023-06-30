using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rachaduras : MonoBehaviour {

    public int index;
    private AviaoRachadura aviaoRachaduraScript;

    void Start()
    {
        aviaoRachaduraScript = FindObjectOfType<AviaoRachadura>();
    }

    private void OnMouseDrag()
    {
        aviaoRachaduraScript.Rachadura(index);;
    }


}
