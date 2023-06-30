using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapa : MonoBehaviour {

    public static bool mostramapa;

    public GameObject cameraPrincipal;
    public GameObject cameraPaths;

    private int lugarAtual;
    private int proxLugar;

    private bool TerminaPaths;
    private bool LigaFor;

    public GameObject icon;
    public GameObject jogador;
   // public Rigidbody corpoPlayer;

    public GameObject mapaHUD;
  //  public Image iconeTransp;

    public GameObject dormitorio;
    public GameObject enfermaria;
    public GameObject oficina;
    public GameObject torre;
    public GameObject deposito;
    public GameObject qg;

    public CPC_CameraPath[] Paths;

    private bool mudaTela;
    private float tempoEscuro;
    private float valor;

    //private float moveX;
    //private float moveY;

    public Animator animator;

    // Use this for initialization
    void Start () {

        mapaHUD.SetActive(false);

        cameraPrincipal.SetActive(true);
        cameraPaths.SetActive(false);
      
        mostramapa = false;
        mudaTela = false;
        tempoEscuro = 0;
        TerminaPaths = false;
        LigaFor = false;
        valor = 0;

        //Comeca no dormitorio

        lugarAtual = 1;
        proxLugar = 1;

     //   Debug.Log(Paths[20].points.Count);
	}
	
	
	void Update () {

        if (LigaFor)
        {
            cameraPrincipal.SetActive(false);
            cameraPaths.SetActive(true);

            for (int i = 0; i < 30; i++)
            {
                if (Paths[i].IsPlaying())
                {
                    //Debug.Log(Paths[i].GetCurrentTimeInWaypoint());
                 //   Debug.Log(Paths[i].GetCurrentWayPoint());

                  
                    // dependendo do tamanho do path o valor nao 1
                  //  if ((Paths[i].GetCurrentTimeInWaypoint() > (Paths[i].points.Count - 1.3f)) && !TerminaPaths)

                    if((Paths[i].GetCurrentWayPoint() == Paths[i].points.Count-2) && (Paths[i].GetCurrentTimeInWaypoint() > 0.7f) && !TerminaPaths)
                    {
                        TerminaPaths = true;
                        FadeOut();
                    }

                    if (Paths[i].GetCurrentTimeInWaypoint() > 1 && TerminaPaths)
                    {
                        
                        TerminaPaths = false;
                        LigaFor = false;
                        Paths[i].StopPath();
                        Paths[i].SetCurrentTimeInWaypoint(0);
                        cameraPrincipal.SetActive(true);
                        cameraPaths.SetActive(false);


                        if (i <= 4)
                        {
                            lugarAtual = 1;
                            jogador.transform.position = new Vector3(28.63f, 73.49908f, 263.64f);

                        }

                        if (i > 4 && i < 10)
                        {
                            lugarAtual = 2;
                            jogador.transform.position = new Vector3(68.303f, 73.49908f, 263.5f);

                        }

                        if (i > 9 && i < 15)
                        {
                            lugarAtual = 3;
                            jogador.transform.position = new Vector3(87.57f, 73.49908f, 334.34f);

                        }

                        if (i > 14 && i < 20)
                        {
                            lugarAtual = 4;
                            jogador.transform.position = new Vector3(78.8f, 73.49f, 107.18f);

                        }

                        if (i > 19 && i < 25)
                        {
                            lugarAtual = 5;
                            jogador.transform.position = new Vector3(99.74f, 73.49908f, 75.038f);

                        }

                        if (i > 24 && i < 30)
                        {
                            lugarAtual = 6;
                            jogador.transform.position = new Vector3(28.9f, 73.49908f, 55.6f);

                        }



                       
                    }
                    
                }
               
                
            }
        }

              

        if (mudaTela)
        {
            tempoEscuro += Time.deltaTime;



            if (tempoEscuro > 1)
            {
                tempoEscuro = 0;
                mudaTela = false;
                mostramapa = false;

                FadeIn();



                if(!TerminaPaths && !LigaFor)
                AtualizaLugar();

                  

              


            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mostramapa && !IniciaPainel.estaPainel)
            {
                mostramapa = false;
                //Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                mostramapa = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (mostramapa)
            mapaHUD.SetActive(true);
        else
            mapaHUD.SetActive(false);
       
    

    }

    public void FadeIn()
    {
        animator.SetTrigger("Clareia");
    }

    public void FadeOut()
    {
        mudaTela = true;
        animator.SetTrigger("Escurece");
    }


    //---------------------------------------------------------------------------

    public void AtualizaLugar()
    {


        if (lugarAtual != proxLugar)
        {
            LigaFor = true;

            //Ir para Dormitorio
            if (proxLugar == 1)
            {
                //chamar path de camera que vai de X(lugar onde estou) para 1
                if(lugarAtual == 2)
                    Paths[0].PlayPath(3);
                
                if (lugarAtual == 3)
                    Paths[1].PlayPath(10);
                
                if (lugarAtual == 4)
                    Paths[2].PlayPath(8);
                
                if (lugarAtual == 5)
                    Paths[3].PlayPath(10);
                
                if (lugarAtual == 6)
                    Paths[4].PlayPath(10);
                
            }


            //Ir para Enfermaria
            if (proxLugar == 2)
            {
                //chamar path de camera que vai de X(lugar onde estou) para 2
                if (lugarAtual == 1)
                    Paths[5].PlayPath(3);       
                
                if (lugarAtual == 3)
                    Paths[6].PlayPath(10);
                
                if (lugarAtual == 4)
                    Paths[7].PlayPath(10);

                if (lugarAtual == 5)
                    Paths[8].PlayPath(10);
                
                if (lugarAtual == 6)
                    Paths[9].PlayPath(10);
           
            }


            //Ir para Oficina
            if (proxLugar == 3)
            {
                //chamar path de camera que vai de X(lugar onde estou) para 3
                if (lugarAtual == 1)
                    Paths[10].PlayPath(7);
                
                if (lugarAtual == 2)
                    Paths[11].PlayPath(8);
                
                if (lugarAtual == 4)
                    Paths[12].PlayPath(8);
                
                if (lugarAtual == 5)
                    Paths[13].PlayPath(7);
                
                if (lugarAtual == 6)
                    Paths[14].PlayPath(10);
                

            }


            //Ir para Torre
            if (proxLugar == 4)
            {
                //chamar path de camera que vai de X(lugar onde estou) para 4
                if (lugarAtual == 1)
                    Paths[15].PlayPath(8);
                
                if (lugarAtual == 2)
                    Paths[16].PlayPath(10);
                
                if (lugarAtual == 3)
                    Paths[17].PlayPath(10);
                
                if (lugarAtual == 5)
                    Paths[18].PlayPath(3);
                
                if (lugarAtual == 6)
                    Paths[19].PlayPath(6);
            }

           
            //Ir para Deposito
            if (proxLugar == 5)
            {
                //chamar path de camera que vai de X(lugar onde estou) para 5
                if (lugarAtual == 1)
                    Paths[20].PlayPath(8);
                
                if (lugarAtual == 2)
                    Paths[21].PlayPath(10);
                
                if (lugarAtual == 3)
                    Paths[22].PlayPath(10);
                
                if (lugarAtual == 4)
                    Paths[23].PlayPath(3);
                
                if (lugarAtual == 6)
                    Paths[24].PlayPath(5);
            }


            //Ir para QG
            if (proxLugar == 6)
            {
                //chamar path de camera que vai de X(lugar onde estou) para 6
                if (lugarAtual == 1)
                    Paths[25].PlayPath(8);
                
                if (lugarAtual == 2)
                    Paths[26].PlayPath(8);
                
                if (lugarAtual == 3)
                    Paths[27].PlayPath(10);
                
                if (lugarAtual == 4)
                    Paths[28].PlayPath(10);
                
                if (lugarAtual == 5)
                    Paths[29].PlayPath(4);
            }
        }
    }


    public void VaiDormitorio()
    {
        icon.transform.localPosition = dormitorio.transform.localPosition;
        proxLugar = 1;

        if (proxLugar != lugarAtual)
            FadeOut();
    }

    public void VaiEnfermaria()
    {
        icon.transform.localPosition = enfermaria.transform.localPosition;
        proxLugar = 2;

        if (proxLugar != lugarAtual)
            FadeOut();
    }

    public void VaiOficina()
    {
        icon.transform.localPosition = oficina.transform.localPosition;
        proxLugar = 3;

        if (proxLugar != lugarAtual)
            FadeOut();
    }

    public void VaiTorre()
    {
        icon.transform.localPosition = torre.transform.localPosition;
        proxLugar = 4;

        if (proxLugar != lugarAtual)
            FadeOut();
    }

    public void VaiDeposito()
    {
        icon.transform.localPosition = deposito.transform.localPosition;
        proxLugar = 5;

        if (proxLugar != lugarAtual)
            FadeOut();
    }

    public void VaiQG()
    {
        icon.transform.localPosition = qg.transform.localPosition;
        proxLugar = 6;

        if (proxLugar != lugarAtual)
            FadeOut();
    }

    
}
