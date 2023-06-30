using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QButtonScript : MonoBehaviour {

    public int questID;
    public Text questTitle;

    /*

    private GameObject acceptButton;
    private GameObject giveUpButton;
    private GameObject completeButton;

    
    private QButtonScript acceptButtonScript;
    private QButtonScript giveupButtonScript;
    private QButtonScript completeButtonScript;

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
    */

    // SHOW ALL INFOS

    public void ShowAllInfos()
    {
        QuestUIManager.uiManager.ShowSelectedQuest(questID);


        // ACCEPT BUTTON
        if (QuestManager.questManager.RequestAvailbleQuest(questID))
        {
            QuestUIManager.uiManager.acceptButton.SetActive(true);
            QuestUIManager.uiManager.acceptButtonScript.questID = questID;
        }
        else
        {
            QuestUIManager.uiManager.acceptButton.SetActive(false);
        }

        // GIVE UP BUTTON
        if (QuestManager.questManager.RequestAcceptedQuest(questID))
        {
            QuestUIManager.uiManager.giveUpButton.SetActive(true);
            QuestUIManager.uiManager.giveupButtonScript.questID = questID;
        }
        else
        {
            QuestUIManager.uiManager.giveUpButton.SetActive(false);
        }

        // COMPLETE BUTTON
        if (QuestManager.questManager.RequestCompleteQuest(questID))
        {
            QuestUIManager.uiManager.completeButton.SetActive(true);
            QuestUIManager.uiManager.completeButtonScript.questID = questID;
        }
        else
        {
            QuestUIManager.uiManager.completeButton.SetActive(false);
        }
    }


    public void AcceptQuest()
    {
        QuestManager.questManager.AcceptQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();

        // UPDATE ALL NPCS
        QuestObject[] curretQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];

        foreach (QuestObject obj in curretQuestGuys)
        {
            obj.SetQuestMarker();

        }
    }



    public void GiveUpQuest()
    {
        QuestManager.questManager.GiveUpQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();

        // UPDATE ALL NPCS
        QuestObject[] curretQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];

        foreach (QuestObject obj in curretQuestGuys)
        {
            obj.SetQuestMarker();

        }
    }



    public void CompleteQuest()
    {
        QuestManager.questManager.CompleteQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();

        // UPDATE ALL NPCS
        QuestObject[] curretQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];

        foreach (QuestObject obj in curretQuestGuys)
        {
            obj.SetQuestMarker();

        }
    }


        public void ClosePanel()
    {

        QuestUIManager.uiManager.HideQuestPanel();
        //QuestUIManager.uiManager.acceptButton.SetActive(false);
       // QuestUIManager.uiManager.giveUpButton.SetActive(false);
       // QuestUIManager.uiManager.completeButton.SetActive(false);
    }











}
