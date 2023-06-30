using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirTorre : MonoBehaviour {

    private bool cima;
    private bool subir;
    public Mapa fade;
    private float tempo;
    public GameObject player;

    // Use this for initialization
    void Start () {

        cima = false;
        subir = false;

        tempo = 0;


    }

    // Update is called once per frame
    void Update () {

        if (subir)
        {
            tempo += Time.deltaTime;


            if (tempo > 1f)
            {
                tempo = 0;
                subir = false;
                Subir();
            }
        }

    }


    private void OnTriggerStay(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               

                //  Cursor.lockState = CursorLockMode.None;
                //  Cursor.visible = enabled;

                subir = true;

                fade.FadeOut();

                

            }
        }

    }


    public void Subir()
    {
        if (cima)
            cima = false;
        else
            cima = true;

        if (cima)
            player.transform.position = new Vector3(76.83f,81.56f,107.34f);
        
        else
           player.transform.position = new Vector3(78.8f, 73.49f, 107.18f);
        
        

    }
}
