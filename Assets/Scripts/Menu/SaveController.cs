using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour {

    public Material[] materiaisBotoes;
    public Renderer[] renderBotoes;

    public void CarregaDia(int numDia)
    {
        FluxoTempo.dias = numDia;
        if (numDia == 1)
        {
            SceneManager.LoadScene(1);
        }
        if (numDia == 6)
        {
            SceneManager.LoadScene("CutScene2");
        }
        else {
            SceneManager.LoadScene("LoadSceneGame");
        }
       
    }

    public void TrocaMaterialBotao(int index, int index2)
    {
        renderBotoes[index2].material = materiaisBotoes[index];
    }
}
