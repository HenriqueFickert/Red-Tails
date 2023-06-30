using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocoCamera : MonoBehaviour {

    public Transform playerT;
    private Vector3 distRelativa;

	void Start () {
        distRelativa = (transform.position - playerT.position);
	}
	

	void Update () {
        transform.position = playerT.position + distRelativa;
	}

}
