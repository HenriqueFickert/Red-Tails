using UnityEngine;

public class BotoesMenu : MonoBehaviour
{

    public int index;
    private MenuPathController menuPathScript;

    private void Start()
    {
        menuPathScript = FindObjectOfType<MenuPathController>();
    }

    private void OnMouseDown()
    {
        menuPathScript.PegaIndex(index);
    }
    private void OnMouseEnter()
    {
        menuPathScript.PlayLightAudio();
        menuPathScript.TrocaMaterialBotao(index+1);
    }

    private void OnMouseExit()
    {
        menuPathScript.TrocaMaterialBotao(0);
    }
}
