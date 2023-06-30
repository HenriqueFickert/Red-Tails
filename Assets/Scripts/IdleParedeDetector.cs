using UnityEngine;

public class IdleParedeDetector : MonoBehaviour
{
    private Animator animPlayer;

    public Animator animDropDown;

    private void Start()
    {
        animPlayer = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Parede"))
        {
            animPlayer.SetBool("IdleParede", true);
            animDropDown.SetBool("Descendo", true);
            animDropDown.SetBool("Subindo", false);
        }
        if (other.CompareTag("Figurante"))
        {
            animPlayer.SetBool("IdleParede", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Parede"))
        {
            animPlayer.SetBool("IdleParede", false);
            animDropDown.SetBool("Descendo", false);
            animDropDown.SetBool("Subindo", true);
        }
        if (other.CompareTag("Figurante"))
        {
            animPlayer.SetBool("IdleParede", false);
        }
    }

}
