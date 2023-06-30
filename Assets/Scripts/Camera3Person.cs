using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3Person : MonoBehaviour {

    private Transform cameraTransform;
    public Transform alvo;
    public Transform alvoRaycast;
    public Transform player;

    private float _mouseX;
    private float _mouseY;
    private float mouseSense = 1;

    private float distancia = 1f;

    public Animator animPlayer;

    public LayerMask layerCam;

    public float ajusteCamera;
    public float distCam;

    private bool estaAnim;
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        cameraTransform = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
   
        _mouseX += Input.GetAxis("Mouse X");
        _mouseY -= Input.GetAxis("Mouse Y");

        _mouseY = Mathf.Clamp(_mouseY, -30, 45);

        if (_mouseX > 10)
        {
            alvo.Rotate(0, (_mouseX - 10), 0);
            _mouseX = 10;
        }
        else if (_mouseX < -10)
        {
            alvo.Rotate(0, (_mouseX + 10), 0);
            _mouseX = -10;
        }

        float delta = (Mathf.DeltaAngle(alvo.eulerAngles.y, player.eulerAngles.y));

        if (Mathf.Abs(delta) >= 10)
        {
            estaAnim = true;
        }else if (Mathf.Abs(delta) < 5)
        {
            estaAnim = false;
        }

        if (estaAnim && Input.GetAxis("Horizontal") == 0)
        {
            float valor = Mathf.MoveTowardsAngle(player.eulerAngles.y, alvo.eulerAngles.y, 3f );
            player.eulerAngles = new Vector3(0, valor, 0);
        }


        if (delta > 5 && Input.GetAxis("Vertical") == 0)
        {
            animPlayer.SetBool("Andando", false);
            animPlayer.SetBool("GirandoDir", estaAnim);
        }else if (delta < -5 && Input.GetAxis("Vertical") == 0)
        {
            animPlayer.SetBool("Andando", false);
            animPlayer.SetBool("GirandoEsq", estaAnim);
        }else
        {
            animPlayer.SetBool("GirandoDir", false);
            animPlayer.SetBool("GirandoEsq", false);
        }


      //  RaycastHit hit;
      //  if (Physics.Linecast(alvoRaycast.position, transform.position, out hit, layerCam))
      //  {
          //  transform.position = hit.point + transform.forward * ajusteCamera;
     //   }


       // cameraTransform.LookAt(alvoRaycast.position);


      //  transform.RotateAround(alvo.position, transform.up, -Input.GetAxis("Mouse X"));
        //transform.RotateAround(alvo.position, transform.right, -Input.GetAxis("Mouse Y"));

       // transform.position = alvo.position - transform.forward * distCam;

       // cameraTransform.RotateAround(alvo.position, alvo.up, _mouseX * mouseSense);
       // cameraTransform.RotateAround(alvo.position, cameraTransform.right, _mouseY * mouseSense);

        //print(delta);
        
        distancia += 0.1f;
        distancia = Mathf.Min(distancia, 3.5f);

        Vector3 posCamera = alvo.position - distancia * alvo.forward;
        cameraTransform.position = posCamera + alvo.up * distancia/3;
        cameraTransform.LookAt(alvo.position);
        

        cameraTransform.RotateAround(alvo.position, alvo.up, _mouseX * mouseSense);
        cameraTransform.RotateAround(alvo.position, cameraTransform.right, _mouseY * mouseSense);

        RaycastHit hit;
        if (Physics.Linecast(alvoRaycast.position, transform.position, out hit, layerCam))
        {
            // if (hit.collider.CompareTag("Player")) break;

            //distancia -= 0.1f;
            //cameraTransform.position = alvoRaycast.position - cameraTransform.forward * distancia;
            transform.position = hit.point + transform.forward * ajusteCamera;
        }

        //foreach (Collider c in Physics.OverlapSphere(cameraTransform.position,0.1f))
        //{
        //cameraTransform.RotateAround(alvo.position, alvo.up, 5);
        //}

    }

    private void FixedUpdate()
    {
        
        RaycastHit hit;
        Vector3 posAntiga = cameraTransform.position;
        for (int i = 0; i < 10; i++)
        {
            if (Physics.Linecast(alvoRaycast.position, transform.position, out hit, layerCam))
            {
               // if (hit.collider.CompareTag("Player")) break;

                //distancia -= 0.1f;
                //cameraTransform.position = alvoRaycast.position - cameraTransform.forward * distancia;
                transform.position = hit.point + transform.forward * ajusteCamera;
            }
        }
        
    }

}



    /*
        private const float Y_ANGLE_MIN = -15;
        private const float Y_ANGLE_MAX = 15;

        public Transform lookAt;
        public Transform camTransform;

        private float distance = 7;
        private float currentX = 0;
        private float currentY = 0;
        private float sensivityX = 4;
        private float sensivityY = 4;

        public float ajusteCamera;
        private RaycastHit hit = new RaycastHit();

        void Start () {
            camTransform = transform;
            Cursor.lockState = CursorLockMode.Locked;
          //  Cursor.visible = false;

        }

        private void Update() {
            currentX += Input.GetAxis("Mouse X");
            currentY -= Input.GetAxis("Mouse Y");
            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        void LateUpdate () {
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY * sensivityY, currentX * sensivityX, 0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position);

            if (Physics.Linecast(lookAt.position, camTransform.transform.position, out hit))
            {
                camTransform.transform.position = hit.point + camTransform.transform.forward * ajusteCamera;
            }
        }*/


