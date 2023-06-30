using UnityEngine;
using UnityEngine.EventSystems;

public class Interaction : MonoBehaviour
{
    //Velocidade Cam
    private float speed = 3;
    //Posiçoes da camera
    private Transform cameraObject;
    private Transform cameraPosicaoRoot;
    private Transform cameraPosicaoBotao;
    private Transform cameraPosicaoRadio;
    private Transform cameraPosicaoRelogio;
    private Transform cameraPosicaoChaves;
    private Transform cameraPosicaoFio;
    private Transform cameraPosicaoModelo;
    //Colliders
    private BoxCollider[] colliderDBotao;
    private BoxCollider colliderDRadio;
    private BoxCollider colliderDRelogio;
    private BoxCollider colliderDChaves;
    private BoxCollider colliderFio;
    private BoxCollider colliderModelo;
    //Scripts
    private PanelInteraction panelInteraction;

    private RadioScript radioScript;

    private void Start()
    {
        panelInteraction = FindObjectOfType<PanelInteraction>();
        //Posicções camera
        cameraObject = GameObject.Find("CameraPainel").GetComponent<Transform>();
        cameraPosicaoRoot = GameObject.Find("PosicaoCameraRoot").GetComponent<Transform>();
        cameraPosicaoBotao = GameObject.Find("PosicaoCameraBotoes").GetComponent<Transform>();
        cameraPosicaoRadio = GameObject.Find("PosicaoCameraRadio").GetComponent<Transform>();
        cameraPosicaoRelogio = GameObject.Find("PosicaoCameraRelogio").GetComponent<Transform>();
        cameraPosicaoChaves = GameObject.Find("PosicaoCameraChaves").GetComponent<Transform>();
        cameraPosicaoFio = GameObject.Find("PosicaoCameraFio").GetComponent<Transform>();
        cameraPosicaoModelo = GameObject.Find("PosicaoCameraModelo").GetComponent<Transform>();
        //Colliders
        colliderDBotao = GameObject.Find("ObjetoBotoes").GetComponents<BoxCollider>();
        colliderDRadio = GameObject.Find("ObjetoRadio").GetComponent<BoxCollider>();
        colliderDRelogio = GameObject.Find("ObjetoRelogio").GetComponent<BoxCollider>();
        colliderDChaves = GameObject.Find("ObjetoChaves").GetComponent<BoxCollider>();
        colliderFio = GameObject.Find("ObjetoFio").GetComponent<BoxCollider>();
        colliderModelo = GameObject.Find("ObjetoModelo").GetComponent<BoxCollider>();
        //GameObjects

        //RadioScript
        radioScript = GameObject.Find("DesafioRadio").GetComponent<RadioScript>();


    }

    public virtual void Executa()
    {

    }

    private void Update()
    {
        
        if (panelInteraction.nameObject == "ObjetoBotoes")
        {
            Cookie.numDesafio = 1;

            cameraObject.position = Vector3.Lerp(cameraObject.position, cameraPosicaoBotao.position, speed * Time.deltaTime);
            cameraObject.rotation = Quaternion.Lerp(cameraObject.rotation, cameraPosicaoBotao.rotation, speed * Time.deltaTime);
            radioScript.ativaSomRadio = false;
            colliderDBotao[0].enabled = false;
            colliderDBotao[1].enabled = false;
            colliderDRadio.enabled = true;
            colliderDRelogio.enabled = true;
            colliderDChaves.enabled = true;
            colliderFio.enabled = true;
            colliderModelo.enabled = true;
        }
        else if (panelInteraction.nameObject == "ObjetoRadio")
        {

            Cookie.numDesafio = 2;

            cameraObject.position = Vector3.Lerp(cameraObject.position, cameraPosicaoRadio.position, speed * Time.deltaTime);
            cameraObject.rotation = Quaternion.Lerp(cameraObject.rotation, cameraPosicaoRadio.rotation, speed * Time.deltaTime);
            radioScript.ativaSomRadio = true;
            colliderDBotao[0].enabled = true;
            colliderDBotao[1].enabled = true;
            colliderDRadio.enabled = false;
            colliderDRelogio.enabled = true;
            colliderDChaves.enabled = true;
            colliderFio.enabled = true;
            colliderModelo.enabled = true;
        }
        else if (panelInteraction.nameObject == "ObjetoRelogio")
        {
            Cookie.numDesafio = 3;

            cameraObject.position = Vector3.Lerp(cameraObject.position, cameraPosicaoRelogio.position, speed * Time.deltaTime);
            cameraObject.rotation = Quaternion.Lerp(cameraObject.rotation, cameraPosicaoRelogio.rotation, speed * Time.deltaTime);
            radioScript.ativaSomRadio = false;
            colliderDBotao[0].enabled = true;
            colliderDBotao[1].enabled = true;
            colliderDRadio.enabled = true;
            colliderDRelogio.enabled = false;
            colliderDChaves.enabled = true;
            colliderFio.enabled = true;
            colliderModelo.enabled = true;
        }
        else if (panelInteraction.nameObject == "ObjetoChaves")
        {

            Cookie.numDesafio = 4;

            cameraObject.position = Vector3.Lerp(cameraObject.position, cameraPosicaoChaves.position, speed * Time.deltaTime);
            cameraObject.rotation = Quaternion.Lerp(cameraObject.rotation, cameraPosicaoChaves.rotation, speed * Time.deltaTime);
            radioScript.ativaSomRadio = false;
            colliderDBotao[0].enabled = true;
            colliderDBotao[1].enabled = true;
            colliderDRadio.enabled = true;
            colliderDRelogio.enabled = true;
            colliderDChaves.enabled = false;
            colliderFio.enabled = true;
            colliderModelo.enabled = true;
        }
        else if (panelInteraction.nameObject == "ObjetoFio")
        {
            Cookie.numDesafio = 5;

            cameraObject.position = Vector3.Lerp(cameraObject.position, cameraPosicaoFio.position, speed * Time.deltaTime);
            cameraObject.rotation = Quaternion.Lerp(cameraObject.rotation, cameraPosicaoFio.rotation, speed * Time.deltaTime);
            radioScript.ativaSomRadio = false;
            colliderDBotao[0].enabled = true;
            colliderDBotao[1].enabled = true;
            colliderDRadio.enabled = true;
            colliderDRelogio.enabled = true;
            colliderDChaves.enabled = true;
            colliderFio.enabled = false;
            colliderModelo.enabled = true;
        }
        else if (panelInteraction.nameObject == "ObjetoModelo")
        {
            Cookie.numDesafio = 6;

            cameraObject.position = Vector3.Lerp(cameraObject.position, cameraPosicaoModelo.position, speed * Time.deltaTime);
            cameraObject.rotation = Quaternion.Lerp(cameraObject.rotation, cameraPosicaoModelo.rotation, speed * Time.deltaTime);
            radioScript.ativaSomRadio = false;
            colliderDBotao[0].enabled = true;
            colliderDBotao[1].enabled = true;
            colliderDRadio.enabled = true;
            colliderDRelogio.enabled = true;
            colliderDChaves.enabled = true;
            colliderFio.enabled = true;
            colliderModelo.enabled = false;
        }
        else if (panelInteraction.nameObject == "Painel")
        {
            Cookie.numDesafio = 7;

            radioScript.ativaSomRadio = false;
            cameraObject.position = Vector3.Lerp(cameraObject.position, cameraPosicaoRoot.position, speed * Time.deltaTime);
            cameraObject.rotation = Quaternion.Lerp(cameraObject.rotation, cameraPosicaoRoot.rotation, speed * Time.deltaTime);
            ActiveColliders();
        }

    }

    private void ActiveColliders()
    {
        colliderModelo.enabled = true;
        colliderDBotao[0].enabled = true;
        colliderDBotao[1].enabled = true;
        colliderDRadio.enabled = true;
        colliderDRelogio.enabled = true;
        colliderDChaves.enabled = true;
        colliderFio.enabled = true;
    }
}
