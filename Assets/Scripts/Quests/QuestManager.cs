using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public static QuestManager questManager;

    public List<Quest> questList = new List<Quest>();  // Lista central
    public List<Quest> questListatual = new List<Quest>(); // Lista atual

    // private vars for our QuestObject

    private void Awake() {

        if (questManager == null)
        {
            questManager = this;
        }

        else if (questManager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }  
    


    public void QuestRequest(QuestObject NpcQuestObject){

        // QUESTS DISPONIVES

        if(NpcQuestObject.availableQuestsID.Count > 0)
        {
            for(int i = 0; i < questList.Count; i++)
            {
                for(int j = 0; j < NpcQuestObject.availableQuestsID.Count; j++)
                {
                    if(questList[i].id == NpcQuestObject.availableQuestsID[j] && questList[i].progresso == Quest.QuestProgress.DISPONIVEL)
                    {
                        Debug.Log("Quest ID: " + NpcQuestObject.availableQuestsID[j] + " " + questList[i].progresso);
                        //testing

                        //  AcceptQuest(NpcQuestObject.availableQuestsID[j]);
                        //quest ui manager

                        QuestUIManager.uiManager.questAvailable = true;
                        QuestUIManager.uiManager.availableQuests.Add(questList[i]);


                    }
                }
            }
        }

        // QUESTS ATIVAS

        for (int i = 0; i < questListatual.Count; i++){

            for (int j = 0; j < NpcQuestObject.receivableQuestsID.Count; j++){
                
                if(questListatual[i].id == NpcQuestObject.receivableQuestsID[j] && questListatual[i].progresso == Quest.QuestProgress.ACEITO || questListatual[i].progresso == Quest.QuestProgress.COMPLETO)
                {
                    
                    Debug.Log("Quest ID:" + NpcQuestObject.availableQuestsID[j] + " is " + questListatual[i].progresso);

                    //  CompleteQuest(NpcQuestObject.receivableQuestsID[j]);
                    // quest ui manager


                    QuestUIManager.uiManager.questRunning = true;
                    QuestUIManager.uiManager.activeQuests.Add(questList[i]);
                }

            }
        }

    }


    // ACEITAR QUEST

    public void AcceptQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progresso == Quest.QuestProgress.DISPONIVEL)
            {
                questListatual.Add(questList[i]);
                questList[i].progresso = Quest.QuestProgress.ACEITO;
            }
        }
    }

    // REJEITAR QUEST

    public void GiveUpQuest(int questID)
    {
        for (int i = 0; i < questListatual.Count; i++)
        {
            if (questListatual[i].id == questID && questListatual[i].progresso == Quest.QuestProgress.ACEITO)
            {
                questListatual[i].progresso = Quest.QuestProgress.DISPONIVEL;
                questListatual[i].ObjetivoQuestRequeridos = 0;
                questListatual.Remove(questListatual[i]);
            }
        }
    }

    // COMPLETAR QUEST

    public void CompleteQuest(int questID)
    {
        for (int i = 0; i < questListatual.Count; i++)
        {
            if (questListatual[i].id == questID && questListatual[i].progresso == Quest.QuestProgress.COMPLETO)
            {
                questListatual[i].progresso = Quest.QuestProgress.CONCLUIDO;
                questListatual.Remove(questListatual[i]);

                //REWARD
            }
        }

        // check for chain quests

        CheckChainQuest(questID);
    }


    // CHAIN QUESTS

        void CheckChainQuest(int questID)
    {
        int tempID = 0;

        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].ProxQuest > 0)
            {
                tempID = questList[i].ProxQuest;
            }
        }

        if(tempID > 0)
        {
            for(int i = 0; i < questList.Count; i++)
            {
                if(questList[i].id == tempID && questList[i].progresso == Quest.QuestProgress.INDISPONIVEL)
                {
                    questList[i].progresso = Quest.QuestProgress.DISPONIVEL;
                }
            }
        }
    }



    // ADICIONAR ITENS

    public void AddQuestItem(string questObjective, int itemAmount)
    {
        for(int i = 0; i < questListatual.Count; i++)
        {
            if(questListatual[i].ObjetivoQuest== questObjective && questListatual[i].progresso == Quest.QuestProgress.ACEITO)
            {
                questListatual[i].ObjetivoQuestRequeridos += itemAmount;
            }


            if(questListatual[i].ObjetivoQuestRequeridos >= questListatual[i].ObjetivoQuestRequeridos && questListatual[i].progresso == Quest.QuestProgress.ACEITO)
            {
                questListatual[i].progresso = Quest.QuestProgress.COMPLETO;
            }
        }
    }
    
    // REMOVER ITENS


    // VERIFICACOES

    // ESTA DISPONIVEL ?
    public bool RequestAvailbleQuest(int questID)
    {

        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progresso == Quest.QuestProgress.DISPONIVEL)
            {
                return true;
            }
        }

        return false;

    }

    // ESTA ACEITO ?
    public bool RequestAcceptedQuest(int questID)
    {

        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progresso == Quest.QuestProgress.ACEITO)
            {
                return true;
            }
        }

        return false;

    }

    // ESTA COMPLETO ?
    public bool RequestCompleteQuest(int questID)
    {

        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progresso == Quest.QuestProgress.COMPLETO)
            {
                return true;
            }
        }

        return false;

    }


    public bool CheckAvailableQuests(QuestObject NpcQuestObject) {

        for (int i = 0; i < questList.Count; i++)
        {

            for (int j = 0; j < NpcQuestObject.availableQuestsID.Count; j++)
            {
                if(questList[i].id == NpcQuestObject.availableQuestsID[j] && questList[i].progresso == Quest.QuestProgress.DISPONIVEL)
                {
                    return true;
                }
            }

        }

        return false;


    }

    public bool CheckAcceptedQuests(QuestObject NpcQuestObject)
    {

        for (int i = 0; i < questList.Count; i++)
        {

            for (int j = 0; j < NpcQuestObject.receivableQuestsID.Count; j++)
            {
                if (questList[i].id == NpcQuestObject.receivableQuestsID[j] && questList[i].progresso == Quest.QuestProgress.ACEITO)
                {
                    return true;
                }
            }

        }

        return false;


    }

    public bool CheckCompletedQuests(QuestObject NpcQuestObject)
    {

        for (int i = 0; i < questList.Count; i++)
        {

            for (int j = 0; j < NpcQuestObject.receivableQuestsID.Count; j++)
            {
                if (questList[i].id == NpcQuestObject.receivableQuestsID[j] && questList[i].progresso == Quest.QuestProgress.COMPLETO)
                {
                    return true;
                }
            }

        }

        return false;


    }



    // SHOW QUEST LOG
    public void ShowQuestLog(int questID)
    {
       for(int i = 0; i < questListatual.Count; i++)
        {
            if(questListatual[i].id == questID)
            {
                QuestUIManager.uiManager.ShowQuestLog(questListatual[i]);
            }
        }

    }










}
