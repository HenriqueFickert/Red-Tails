using UnityEngine;

public class BotoesCreditos : MonoBehaviour
{

    public bool isNext;
    private CreditosController creditosScript;

    private Animator anim;

    void Start()
    {
        creditosScript = FindObjectOfType<CreditosController>();
        anim = GetComponentInParent<Animator>();
    }


    void Update()
    {

    }


    private void OnMouseDown()
    {
        if (MenuPathController.indexAtual == 3)
        {
            if (isNext)
            {
                creditosScript.AcrescentaValor();
                anim.SetBool("VirandoIda", true);
                anim.SetBool("VirandoVolta", false);
            }
            else
            {
                creditosScript.DiminuiValor();
                anim.SetBool("VirandoIda", false);
                anim.SetBool("VirandoVolta", true);
            }
        }

    }
}
