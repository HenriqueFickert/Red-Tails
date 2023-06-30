using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePath : MonoBehaviour {

    public CPC_CameraPath path;
    private float timer;

	// Use this for initialization
	void Start () {

        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (path.IsPlaying())
        {
            timer += Time.deltaTime;

            if(timer > 2)
            path.StopPath();
           // path.PlayPath(8);
        }
		
	}
}
