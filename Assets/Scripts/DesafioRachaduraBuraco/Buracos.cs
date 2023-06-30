using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buracos : MonoBehaviour {

    public int index;
    private AviaoRachadura aviaoRachaduraScript;

    void Start () {
        aviaoRachaduraScript = FindObjectOfType<AviaoRachadura>();
    }

    private void OnMouseDown()
    {
        aviaoRachaduraScript.Buraco(index);
    }

}
