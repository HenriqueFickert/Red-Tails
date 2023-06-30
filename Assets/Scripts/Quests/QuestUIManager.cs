using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestUIManager : MonoBehaviour {

    public static QuestUIManager uiManager;

    // Bools
    public bool questAvailable =  false;
    public bool questRunning = false;
    public bool questPanelActive = false;
    private bool questLogPanelActive = false;

    //Panels
    public GameObject questPanel;
    public GameObject questLogPanel;


    //Quest Object

    private QuestObject currentQuestObject;

    //Quest List

    public List<Quest> availableQuests = new List<Quest>();
    public List<Quest> activeQuests = new List<Quest>();


    //Buttons

    public GameObject qButton;
    public GameObject qLogButton;
    private List<GameObject> qButtons = new List<GameObject>();

    public GameObject acceptButton;
    public GameObject giveUpButton;
    public GameObject completeButton;

    //Spacer

    public Transform qButtonSpacer; //  qButton available
    public Transform qButtonSpacer2;// running qButton
    public Transform qLogButtonSpacer;// running in qLog

    //Quest Infos

    public Text questTitle;
    public Text questDescription;
    public Text questSummary;


    //Quest Log Infos

    public Text questLogTitle;
    public Text questLogDescription;
    public Text questLogSummary;



    public QButtonScript acceptButtonScript;
    public QButtonScript giveupButtonScript;
    public QButtonScript completeButtonScript;

    private void Start()
    {

        // ACESSO DIRETO AOS BOTOES

        acceptButton = GameObject.Find("Quest Canvas").transform.Find("Quest Panel").transform.Find("Quest Description").transform.Find("GrupoBotoes").transform.Find("Accept Button").gameObject;
        acceptButtonScript = acceptButton.GetComponent<QButtonScript>();

        giveUpButton = GameObject.Find("Quest Canvas").transform.Find("Quest Panel").transform.Find("Quest Description").transform.Find("GrupoBotoes").transform.Find("Give Up Button").gameObject;
        giveupButtonScript = giveUpButton.GetComponent<QButtonScript>();

        completeButton = GameObject.Find("Quest Canvas").transform.Find("Quest Panel").transform.Find("Quest Description").transform.Find("GrupoBotoes").transform.Find("Complete Button").gameObject;
        completeButtonScript = completeButton.GetComponent<QButtonScript>();

        acceptButton.SetActive(false);
        giveUpButton.SetActive(false);
        completeButton.SetActive(false);


    }

    private void Awake()
    {
        if(uiManager == null)
        {
            uiManager = this;
        }
        else if(uiManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        HideQuestPanel();
    }



	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            questLogPanelActive = !questLogPanelActive;
            ShowQuestLogPanel();


           
        }

      //  Debug.Log("Running: "+questRunning);
       // Debug.Log("Available: " + questAvailable);
       // Debug.Log("Panel: " + questPanelActive);
		
	}


    //Called from quest object
    public void CheckQuests(QuestObject questObject)
    {
        currentQuestObject = questObject;
        QuestManager.questManager.QuestRequest(questObject);
        if((questRunning || questAvailable) && !questPanelActive)
        {
            ShowQuestPanel();
        }
        else
        {
            //Msg qnd nao ha quests disponiveis
            Debug.Log("No Quest Available");
        } 
    }


    // SHOW PANEL

    public void ShowQuestPanel()
    {
        questPanelActive = true;
        questPanel.SetActive(questPanelActive);

        //Fill in Data

        FillQuestButtons();
    }

    // SHOW LOG PANEL

   public void ShowQuestLogPanel()
    {
        questLogPanel.SetActive(true);
        if (questLogPanelActive && !questPanelActive)
        {
            foreach(Quest curQuest in QuestManager.questManager.questListatual)
            {
                GameObject questButton = Instantiate(qLogButton);
                QLogButtonScript qbutton = questButton.GetComponent<QLogButtonScript>();

                qbutton.questID = curQuest.id;
                qbutton.questTitle.text = curQuest.titulo;

                questButton.transform.SetParent(qLogButtonSpacer, false);
                qButtons.Add(questButton);
            }
        }
        else if(!questLogPanelActive && !questPanelActive)
        {
            HideQuestLogPanel();
        }

    }

    // SHOW QUEST LOG
    public void ShowQuestLog(Quest activeQuest)
    {
        questLogTitle.text = activeQuest.titulo;

        if(activeQuest.progresso == Quest.QuestProgress.ACEITO)
        {
            questLogDescription.text = activeQuest.dica;
            questLogSummary.text = activeQuest.ObjetivoQuest + " : " + activeQuest.NumObjetivoQuest + " / " + activeQuest.ObjetivoQuestRequeridos;
        }
        else if (activeQuest.progresso == Quest.QuestProgress.COMPLETO)
        {
            questLogDescription.text = activeQuest.parabens;
            questLogSummary.text = activeQuest.ObjetivoQuest + " : " + activeQuest.NumObjetivoQuest + " / " + activeQuest.ObjetivoQuestRequeridos;
         }
        
    }

    // HIDE QUEST PANEL

    public void HideQuestPanel()
    {
        questPanelActive = false;
        questAvailable = false;
        questRunning = false;

        // clear text

        questTitle.text = "";
        questDescription.text = "";
        questSummary.text = "";

        //clear lists

        availableQuests.Clear();
        activeQuests.Clear();

        // clear buttons

        for(int i =0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }

        qButtons.Clear();

        // hide panel
        questPanel.SetActive(questPanelActive);
       
    }

    // HIDE QUEST LOG PANEL

   public void HideQuestLogPanel()
    {
        questLogPanelActive = false;

        questLogTitle.text = "";
        questLogDescription.text = "";
        questLogSummary.text = "";

        // CLEAR BUTTON LIST

        for (int i = 0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }

        qButtons.Clear();
        questLogPanel.SetActive(questLogPanelActive);

    }

    // fill buttons for quest panel

    void FillQuestButtons()
    {
        foreach (Quest availableQuest in availableQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = availableQuest.id;
            qBScript.questTitle.text = availableQuest.titulo;


            questButton.transform.SetParent(qButtonSpacer, false);
            qButtons.Add(questButton);

        }


        foreach (Quest activeQuest in activeQuests )
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = activeQuest.id;
            qBScript.questTitle.text = activeQuest.titulo;


            questButton.transform.SetParent(qButtonSpacer2, false);
            qButtons.Add(questButton);

        }
    }

    // SHOW QUEST ON BUTTON PRESS IN QUEST PANEL

    public void ShowSelectedQuest(int questID)
    {
        for(int i = 0; i < availableQuests.Count; i++)
        {
            if(availableQuests[i].id == questID)
            {
                questTitle.text = availableQuests[i].titulo;
                if(availableQuests[i].progresso == Quest.QuestProgress.DISPONIVEL)
                {
                    questDescription.text = availableQuests[i].descricao;
                    questSummary.text = availableQuests[i].ObjetivoQuest + " : " + availableQuests[i].NumObjetivoQuest + " / " + availableQuests[i].ObjetivoQuestRequeridos;
                }
            }
        }


        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].id == questID)
            {
                questTitle.text = activeQuests[i].titulo;
                if (activeQuests[i].progresso == Quest.QuestProgress.ACEITO)
                {
                    questDescription.text = activeQuests[i].dica;
                    questSummary.text = activeQuests[i].ObjetivoQuest + " : " + activeQuests[i].NumObjetivoQuest + " / " + activeQuests[i].ObjetivoQuestRequeridos;
                }
                else if (activeQuests[i].progresso == Quest.QuestProgress.COMPLETO)
                {
                    questDescription.text = activeQuests[i].parabens;
                    questSummary.text = activeQuests[i].ObjetivoQuest + " : " + activeQuests[i].NumObjetivoQuest + " / " + activeQuests[i].ObjetivoQuestRequeridos;
                }
            }
        }



    }














}
