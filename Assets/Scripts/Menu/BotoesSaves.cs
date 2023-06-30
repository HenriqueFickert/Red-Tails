using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesSaves : MonoBehaviour {

    public int index;
    private SaveController saveControllerScript;

	void Start () {
        saveControllerScript = FindObjectOfType<SaveController>();
    }


    private void OnMouseDown()
    {
        if (MenuPathController.indexAtual == 4)
        {
            saveControllerScript.CarregaDia(index);
 
        }
            
    }

    private void OnMouseEnter()
    {
        if (MenuPathController.indexAtual == 4)
        {
            saveControllerScript.TrocaMaterialBotao(((index - 1) + 6), (index-1));
        }
    }

    private void OnMouseExit()
    {
        if (MenuPathController.indexAtual == 4)
        {
            saveControllerScript.TrocaMaterialBotao((index - 1),(index-1));
        }
    }
}
