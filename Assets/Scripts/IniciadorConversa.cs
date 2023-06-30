using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciadorConversa : MonoBehaviour
{

    public ControladorFrases Controlador;

    public bool Instantaneo;

    // Usar essa variavel para puxar a conversa
    public bool LigaFrase;

    private Animator anim;

  //  public bool Inicial;
  //  private bool controle;
  
    public Fala fala;
    public bool umaVez;

    public void Start()
    {
        LigaFrase = false;
      //  controle = false;


        anim = GameObject.Find("InteraçãoGeral").GetComponent<Animator>();
    }

    public void Update()
    {
        if (LigaFrase)
        {
            LigaFrase = false;
            Controlador.ComecarDialogo(fala);
        }
    }

    public void IniciarDialogo()
    {
        Controlador.ComecarDialogo(fala);
    }

    public void TerminaDialogo()
    {
        Controlador.TerminaConversa();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            if (Instantaneo)
                IniciarDialogo();

            if (!umaVez) { 
            anim.SetBool("Descendo", true);
            anim.SetBool("Subindo", false);
        }
        }
    }

    private void OnTriggerStay(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player") && !umaVez)
        {
            if (!Instantaneo)
            {
                if (Input.GetKeyDown(KeyCode.E)) { 
                IniciarDialogo();
                    anim.SetBool("Descendo", false);
                    anim.SetBool("Subindo", true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            if (umaVez)
                Destroy(gameObject);
            TerminaDialogo();
            anim.SetBool("Descendo", false);
           anim.SetBool("Subindo", true);
        }

    }
}

    
