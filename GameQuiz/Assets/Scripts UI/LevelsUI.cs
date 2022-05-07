using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUI : MonoBehaviour
{
    public GameManager gameManager;
    public PanelManager panelManager;
    
    public int c_level;
    public int t_levels;
    public int t_players;

    public Button btnNext;
    public Button btnPrevious;
    public Button btnRank;

    public Text txtLevel;
    public Text txtSubdescription;

    void OnEnable()
    {
        t_levels = gameManager.levels.Length;
        t_players = gameManager.players.Length;

        UpdateUI();
    }

    /*
    Ativa ou desativa botões "Nível antecedente", "Nível seguinte" e "Classificação Geral".
    Atualiza as informações dos campo de texto "Descrição do Nível" e "Subdescrição do Nível".
    */
    void UpdateUI()
    {
        btnNext.interactable        = c_level < t_levels - 1;
        btnPrevious.interactable    = c_level > 0;

        btnRank.interactable = t_players > 0;

        txtLevel.text = gameManager.levels[c_level].description;
        txtSubdescription.text = "(" + gameManager.levels[c_level].subdescription + ")";
    }

    /*
    Tarefas executadas pelo botão transitar para tela "Seleção de Jogador".
    */
    public void OnPlayers()
    {
        gameManager.PlayLevel(c_level);

        panelManager.LevelsToPlayers();
    }

    /*
    Tarefas executadas pelo botão abrir tela "Classificação Geral".
    */
    public void OnRanks()
    {
        gameManager.OrderToFinalScore();

        panelManager.OpenRanks();
    }

    /*
    Tarefas executadas pelo botão abrir tela "Seleção de Material de Apoio".
    */
    public void OnIntro()
    {
        gameManager.PlaySupports(c_level);

        panelManager.OpenIntro();
    }

    /*
    Tarefas executadas pelo botão "Nível Seguinte".
    */
    public void OnNext()
    {
        c_level++;
        c_level = Mathf.Clamp(c_level, 0, t_levels);

        UpdateUI();
    }

    /*
    Tarefas executadas pelo botão "Nível Antecedente".
    */
    public void OnPrevious()
    {
        c_level--;
        c_level = Mathf.Clamp(c_level, 0, t_levels);

        UpdateUI();
    }
}
