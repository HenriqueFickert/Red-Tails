using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelInteraction : MonoBehaviour {

    public string nameObject = null;
   

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point);
                Interaction interaction = hit.transform.GetComponent<Interaction>();
                if (interaction != null) {
                    nameObject = hit.transform.name;
                    interaction.Executa();
                }
            }
        }
    }

}

//hit.transform.SendMessage("Executa", SendMessageOptions.DontRequireReceiver);