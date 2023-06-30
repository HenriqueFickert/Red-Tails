using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engrenagem : MonoBehaviour {

    public bool estaQuebrada;
    public int index;

    private DesafioProjetor ProjetorScript;

    // Use this for initialization
    void Start () {

        ProjetorScript = FindObjectOfType<DesafioProjetor>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (estaQuebrada)
        {
            ProjetorScript.trocaEngrenagem(index);
        }
        else if(DesafioProjetor.numEngrenagemRuim <= 0)
        {
            ProjetorScript.substitui();
        }
    }
}
