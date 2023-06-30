using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour {

    private bool inTrigger = false;

    public List<int> availableQuestsID = new List<int>();
    public List<int> receivableQuestsID = new List<int>();

    public GameObject questMarker;
    public Image theImage;

    public Sprite questAvailableSprite;
    public Sprite questReceivableSprite;


    // Use this for initialization
    void Start () {

        SetQuestMarker();
		
	}

   public void SetQuestMarker()
    {
        if (QuestManager.questManager.CheckCompletedQuests(this))
        {
            questMarker.SetActive(true);
            theImage.sprite = questReceivableSprite;
            theImage.color = Color.blue;
        }

        else if (QuestManager.questManager.CheckAvailableQuests(this))
        {
            questMarker.SetActive(true);
            theImage.sprite = questAvailableSprite;
            theImage.color = Color.blue;

        }

        else if (QuestManager.questManager.CheckAcceptedQuests(this))
        {
            questMarker.SetActive(true);
            theImage.sprite = questReceivableSprite;
            theImage.color = Color.magenta;

        }

        else{

            questMarker.SetActive(false);

        }
    } 


	// Update is called once per frame
	void Update () {

        if(inTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            // Quest UI Manager

            // QuestManager.questManager.QuestRequest(this);

            if(!QuestUIManager.uiManager.questPanelActive)
            QuestUIManager.uiManager.CheckQuests(this);
        }
		
	}

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.tag == "Player")
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.tag == "Player")
        {
            inTrigger = false;
        }
    }
}
