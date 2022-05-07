using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    public GameManager gameManager;
    public QuizManager quizManager;
    public PanelManager panelManager;

    public Text txtStopwatch;
    public Text txtPoints;
    public Text txtRank;

    public Text txtLevel;
    public Text txtSubdescription;
    public Text txtPlayer;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        UpdateUI();
    }

    /*
    Atualiza as informações dos campo de texto "Nome do jogador", "Descrição do nível", "Subdescrição do nível", "Pontos", "Classificação" e "Tempo".
    */
    void UpdateUI()
    {
        txtPlayer.text          = gameManager.player.description;
        txtLevel.text           = gameManager.level.description;
        txtSubdescription.text  = "(" + gameManager.level.subdescription + ")";
        
        txtPoints.text  = gameManager.player.points.ToString("D4");
        txtRank.text    = gameManager.player.rank.ToString() + "º";

        float stopwatch = gameManager.player.stopwatch;

        txtStopwatch.text = gameManager.FormatStopwatch(stopwatch);
    }

    /*
    Tarefas executadas pelo botão transitar para tela "Seleção de Jogador".
    */
    public void OnPlayers()
    {
        gameManager.DropQuestions();
        
        gameManager.ReloadPlayer();

        panelManager.FinishToPlayers();
    }

    /*
    Tarefas executadas pelo botão transitar para tela "Seleção de Nível".
    */
    public void OnLevels()
    {
        gameManager.DropQuestions();
        
        gameManager.ReloadPlayer();
        
        panelManager.FinishToLevels();
    }
}
