using UnityEngine;

public class Extras : MonoBehaviour
{

    public Material[] mats;

    public Renderer render;

    public Renderer BGRender;

    public Material[] BGmaterial;

    private Animator anim;

    private int index = 0;

    private bool estaClicando;

    private void Start()
    {
        anim = GetComponent<Animator>();

    }

    private void OnMouseDown()
    {

      
        if (MenuPathController.indexAtual == 2)
        {
            if (!estaClicando)
            {
                estaClicando = true;
                anim.SetBool("Ida", true);
                if (index < mats.Length - 1)
                {
                    index++;
                }
                else
                {
                    index = 0;
                }
            }
        }

    }

    private void OnMouseEnter()
    {
        if (MenuPathController.indexAtual == 2)
        {
            BGRender.material = BGmaterial[1];
        }
    }
    private void OnMouseExit()
    {
        if (MenuPathController.indexAtual == 2)
        {
            BGRender.material = BGmaterial[0];
        }
    }

    public void ChangeMaterialAnimation()
    {
        render.material = mats[index];
        anim.SetBool("Ida", false);
        anim.SetBool("Volta", true);
    }

    public void CancelAnimation()
    {
        estaClicando = false;
        anim.SetBool("Volta", false);
    }

}
