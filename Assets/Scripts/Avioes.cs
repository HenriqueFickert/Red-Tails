using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avioes : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
        transform.Translate(1000 * Time.deltaTime, 0, 0);
	}
}
