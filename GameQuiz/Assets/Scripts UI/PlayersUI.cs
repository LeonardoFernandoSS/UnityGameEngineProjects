using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersUI : MonoBehaviour
{
    public QuizManager quizManager;
    public GameManager gameManager;
    public PanelManager panelManager;

    public int c_player;
    public int t_players;

    public Button btnNext;
    public Button btnPrevious;
    public Button btnQuestion;
    public Button btnComments;
    public Button btnRank;
    
    public Text txtPlayer;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        t_players = gameManager.players.Length;
    
        UpdateUI();
    }

    /*
    Ativa ou desativa botões "Jogador antecedente", "Jogador seguinte", "Classificação por Nível", "Visualizar Comentários" e "Responder Questões".
    Atualiza as informações dos campo de texto "Nome do Jogador".
    */
    void UpdateUI()
    {
        btnNext.interactable        = c_player < t_players - 1;
        btnPrevious.interactable    = c_player > 0;

        btnQuestion.interactable = t_players > 0;
        btnComments.interactable = t_players > 0;
        btnRank.interactable = t_players > 0;

        if (t_players > 0)
        {
            txtPlayer.text = gameManager.players[c_player].description;    
        }
    }

    /*
    Tarefas executadas pelo botão transitar para tela "Responder Questão".
    */
    public void OnQuestion()
    {
        gameManager.PlayPlayer(c_player);

        quizManager.Reset(gameManager.level.t_question);

        quizManager.Play();

        panelManager.PlayersToQuestion();
    }

    /*
    Tarefas executadas pelo botão transitar para tela "Novo Jogador".
    */
    public void OnAccount()
    {
        panelManager.PlayersToAccount();
    }

    /*
    Tarefas executadas pelo botão abrir tela "Seleção de Comentário".
    */
    public void OnComments()
    {
        gameManager.PlayPlayer(c_player);
        
        panelManager.OpenComments();
    }

    /*
    Tarefas executadas pelo botão abrir tela "Classificação por Nível".
    */
    public void OnRank()
    {
        gameManager.OrderToScore();

        panelManager.OpenRank();
    }

    /*
    Tarefas executadas pelo botão transitar para tela "Seleção de Nível".
    */
    public void OnLevels()
    {
        gameManager.ReloadPlayer();
        
        panelManager.PlayersToLevels();
    }

    /*
    Tarefas executadas pelo botão "Jogador Seguinte".
    */
    public void OnNext()
    {
        c_player++;
        c_player = Mathf.Clamp(c_player, 0, t_players);

        UpdateUI();
    }

    /*
    Tarefas executadas pelo botão "Jogador Antecedente".
    */
    public void OnPrevious()
    {
        c_player--;
        c_player = Mathf.Clamp(c_player, 0, t_players);

        UpdateUI();
    }
}
