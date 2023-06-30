using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fio : MonoBehaviour
{

    public int index;
    private Fios fios;


	void Start () {
        fios = GetComponentInParent<Fios>();
	}
	

	void Update () {
		
	}

    private void OnMouseDown()
    {
        fios.AtivaFio(index);
    }
}
