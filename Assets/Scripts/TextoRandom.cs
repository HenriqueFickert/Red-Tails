using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoRandom : MonoBehaviour {

    private Text texto;

    private int index;
    private void Awake()
    {

        texto = GetComponent<Text>();
        index = Random.Range(0,3);
    }
    void Start () {


    
        if (index == 0)
        {
            texto.text = "Lee Archer foi um às do Tsukegee Airmen. Ele morreu em 2010 com 90 anos. Lightning provavelmente representa ele.";
        }else
        if (index == 1)
        {
            texto.text = "Aviões usados pelo esqudrão: P-39 Aticora (pior avião americano na época), P-40 Warhawk, B-25 Mitchell, P-51 Mustang (melhor avião americano na época), P-47 Thunderbolt";
        }else
        if (index == 2)
        {
            texto.text = "Andre Royo, o ator que atuou como Coffee no filme, conheceu alguns dos veteranos de guerra do esquadrão Red Tails.";
        }
    }

}
