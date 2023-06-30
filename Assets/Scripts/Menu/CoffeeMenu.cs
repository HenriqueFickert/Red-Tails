using UnityEngine;

public class CoffeeMenu : MonoBehaviour
{

    public AudioSource audioS;
    private int index = 0;
    public AudioClip[] musicas;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Radio"))
        {

            index++;

            if (index >= musicas.Length)
            {
                index = 0;
            }

            audioS.clip = musicas[index];
            audioS.Play();

        }
    }
}
