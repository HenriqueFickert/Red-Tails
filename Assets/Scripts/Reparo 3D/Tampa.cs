using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tampa : MonoBehaviour {

    private PainelAudioController painelAudioControllerScript;

    private Animator anim;
    private bool estaClickado;
    private int index = 0;

    void Start () {
        painelAudioControllerScript = GameObject.Find("PainelAviao").GetComponent<PainelAudioController>();
        anim = GetComponent<Animator>();
	}
	
	
	void Update () {

        //se ja falou para o cookie qual o modelo do painel
        if (estaClickado)
        {
            if (index == 0)
            {
                anim.SetBool("EstaAberta", true);
                estaClickado = false;
                painelAudioControllerScript.Tampa();
                index = 1;
            }else
            {
                anim.SetBool("EstaAberta", false);
                painelAudioControllerScript.Tampa();
                estaClickado = false;
                index = 0;
            }

        }

    }

    private void OnMouseDown()
    {
        estaClickado = true;
    }

}