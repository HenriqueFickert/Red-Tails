using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosController : MonoBehaviour {

    public Renderer renderPagina;
   // public Renderer renderDogTag;
    public Renderer renderLivro;

    public Material[] matsPagina;
   // public Material[] matsDogTag;
    public Material[] matsLivro;

    private int indexAtual;

    public int valorAtual;

    public static bool estaClicado = false;


    public void TrocaTexturaProx()
    {
        renderPagina.material = matsPagina[valorAtual];
       // renderDogTag.material = matsDogTag[valorAtual];
        renderLivro.material = matsLivro[valorAtual];
    }

    public void TrocaDeTexturaPrev()
    {
        renderPagina.material = matsPagina[valorAtual];
       // renderDogTag.material = matsDogTag[valorAtual];
        renderLivro.material = matsLivro[valorAtual];
    }

    public void AcrescentaValor()
    {
        if (!estaClicado){
            if (valorAtual < matsPagina.Length - 1)
                valorAtual++;

            TrocaTexturaProx();
        }
       
    }
    public void DiminuiValor()
    {
        if (!estaClicado)
        {
            if (valorAtual > 0)
                valorAtual--;

            TrocaDeTexturaPrev();
        }
       
    }

    public void FinalClick()
    {
        estaClicado = false;
    }
}
