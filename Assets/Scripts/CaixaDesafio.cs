using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDesafio : MonoBehaviour {

    public int index;

    public GameObject caixa;
    public GameObject item;

    public bool caixaEstaAqui;
    public bool temItem;

    

    void Start()
    {
      

      
    }

    void Update()
    {

        if (caixaEstaAqui)
            caixa.SetActive(true);
        else
            caixa.SetActive(false);

        if (temItem)
            item.SetActive(true);
        else
            item.SetActive(false);

    }

    private void OnMouseDown()
    {

         if (!caixaEstaAqui && Matriz.estaComCaixa)
        {

            Matriz.estaComCaixa = false;
            caixaEstaAqui = true;
        }

      else  if (!caixaEstaAqui && !Matriz.estaComCaixa && temItem)
        {
            Matriz.numItensPegos++;
            temItem = false;
        }
       
     else if (caixaEstaAqui && !Matriz.estaComCaixa)
        {
            caixaEstaAqui = false;
            Matriz.estaComCaixa = true;
        }


    }
}
