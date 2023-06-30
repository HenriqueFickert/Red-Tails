using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private CharacterController _controller;
    private Animator anim;
    //Movimentação
    Vector3 _movement;
    public float moveSpeed = 1f;
    private bool isRunning;
    //Gravidade
    [SerializeField] float gravityMultiplier = 2.0f;

    private float lh;
    private float lv;

    //Temporizador
    private float tempoCorrida;


    public static bool estaNoDesafio;


    void Start()
    {
        anim = GetComponent<Animator>();
        estaNoDesafio = false;
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!estaNoDesafio && !Mapa.mostramapa && !IniciaPainel.estaPainel)
        {
            if (Input.GetButton("Run") && Input.GetAxis("Vertical") > 0)
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                moveSpeed = 1f;
            }

            _movement = GetKeys() * GetSpeed();
            _movement = transform.TransformDirection(_movement);

            if (lh > 0)
            {
                transform.Rotate(0, 3, 0);
            }
            else if (lh < 0)
            {
                transform.Rotate(0, -3, 0);
            }
        }
        // Animações

        anim.SetFloat("MotionBlend", Input.GetAxis("Vertical") * moveSpeed);

        if (lh > 0) {
            anim.SetBool("GirandoDir", true);
        }else if (lh < 0)
        {
            anim.SetBool("GirandoEsq", true);
        }

        if (lv > 0)
        {
            anim.SetBool("Andando", true);
            anim.SetBool("GirandoDir", false);
            anim.SetBool("GirandoEsq", false);
        }
        else if (lv < 0)
        {
            anim.SetBool("BackWalk", true);
            anim.SetBool("GirandoDir", false);
            anim.SetBool("GirandoEsq", false);
        }
        else
        {
            anim.SetBool("BackWalk", false);
            anim.SetBool("Andando", false);
        }

   
    }

    void FixedUpdate()
    {
        //Gravidade  
        _movement.y += Physics.gravity.y * gravityMultiplier;
        //Aplica o movimento
        if (!anim.GetBool("IdleParede") || anim.GetBool("BackWalk"))
        {
            _controller.Move(_movement * Time.fixedDeltaTime);
        }
        
    }

    //Pega os Axis e coloca em um Vector 3
    Vector3 GetKeys()
    {
        lh = Input.GetAxis("Horizontal");
        lv = Input.GetAxis("Vertical");

        return new Vector3(0, 0, lv);
    }

    //Verifica se ta correndo ou andando
    float GetSpeed()
    {
        if (isRunning)
        {
            if (moveSpeed < 3)
            {
                moveSpeed += 8f * Time.deltaTime;
            }

            return moveSpeed;
        }
        else
            if (moveSpeed > 1f)
        {
            moveSpeed -= 1f * Time.deltaTime;
        }
        else
        {
            moveSpeed = 1f;
        }
        return moveSpeed;
    }


}
