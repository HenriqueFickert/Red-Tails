using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciaPainel : MonoBehaviour {

    public GameObject camJogador;
    public GameObject camPainel;
    public GameObject painel;

    public Material[] TiposPainel;
    public Renderer[] renderPainel;

    private int numPainel;

    public Mapa fade;
    public Cookie cookie;

    private bool vai;
    private bool umaVez;
    private float tempo;

    public static bool estaPainel;


    private Animator anim;

    // Use this for initialization
    void Start () {

        estaPainel = false;

        vai = false;
        umaVez = true; ;
        camJogador.SetActive(true);
        camPainel.SetActive(false);
        painel.SetActive(false);


        tempo = 0;

        anim = GameObject.Find("InteraçãoGeral").GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (vai)
        {
            tempo += Time.deltaTime;  


            if(tempo > 1   )
            {
                tempo = 0;
                vai = false;
                Iniciar();
            }
        }

    
		
	}

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {

            anim.SetBool("Descendo", true);
            anim.SetBool("Subindo", false);
        }
    }

    private void OnTriggerStay(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && umaVez)
            {
                umaVez = false;
                anim.SetBool("Descendo", false);
                anim.SetBool("Subindo", true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = enabled;

                fade.FadeOut();

                vai = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
          
            anim.SetBool("Descendo", false);
            anim.SetBool("Subindo", true);
        }

    }


    public void Iniciar() {

        //RANDOMIZAR O PAINEL

        numPainel = Random.Range(0, 3);
        for (int i = 0; i < renderPainel.Length; i++)
        {
            renderPainel[i].material = TiposPainel[numPainel];
        }


        cookie.PerguntaPainel();
        estaPainel = true;
        camJogador.SetActive(false);
        camPainel.SetActive(true);
        painel.SetActive(true);

    }
}
