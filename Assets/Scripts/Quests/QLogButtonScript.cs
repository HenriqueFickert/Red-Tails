﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QLogButtonScript : MonoBehaviour {

    public int questID;
    public Text questTitle;

	public void ShowAllInfos()
    {
        QuestManager.questManager.ShowQuestLog(questID);
    }

    public void ClosePanel()
    {
        QuestUIManager.uiManager.HideQuestLogPanel();
    }
}
