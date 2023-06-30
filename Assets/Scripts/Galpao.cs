using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galpao : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider hit)
    {
        QuestManager.questManager.AddQuestItem("Chegar na garagem",1);
    }
}
