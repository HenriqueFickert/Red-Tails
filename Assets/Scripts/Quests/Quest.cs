using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Quest{

    public enum QuestProgress { DISPONIVEL, INDISPONIVEL, ACEITO, COMPLETO, CONCLUIDO }
    public string titulo;               // Nome da Quest
    public int id;                     // Identificador da Quest
    public QuestProgress progresso;   // Atual situacao da Quest (enum)
    public string descricao;         // Descricao da Quest
    public string dica;             // Dica para o jogador
    public string parabens;        // Mensagem ao cumprir a Quest
    public string sumario;        // 
    public int ProxQuest;        // Proxima Quest a ser feita


    public string ObjetivoQuest; // Nome do objetivo da Quest
    public int NumObjetivoQuest; // Numero atual do objetivo da Quest
    public int ObjetivoQuestRequeridos; // Quantidade de objetivos a serem cumpridos

    public int Recompensa;
}
