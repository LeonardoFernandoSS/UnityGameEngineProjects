using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RanksUI : MonoBehaviour
{
    public GameManager gameManager;
    public PanelManager panelManager;

    public Text[] txtPositons;
    public Text[] txtPlayers;
    public Text[] txtPoints;
    public Text[] txtStopwatchs;

    public Button btnNext;
    public Button btnPrevious;

    public int t_players;
    public int c_page;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        t_players   = gameManager.players.Length;
        c_page      = 0;

        UpdateUI();
    }

    /*
    Ativa ou desativa botões "Página antecedente" e "Página seguinte".
    Atualiza as informações dos campo de texto "Classificações Gerais", "Nomes dos Jogadores, "Pontuações Gerais" e "Tempos Gerais".
    */
    void UpdateUI()
    {
        btnNext.interactable        = c_page < 1;
        btnPrevious.interactable    = c_page > 0;

        int begin   = txtPlayers.Length * c_page;
        int end     = txtPlayers.Length + txtPlayers.Length * c_page;
        int count   = 0;

        for (int p = begin; p < end; p++)
        {
            txtPositons[count].text = (p + 1).ToString() + "º";

            txtPlayers[count].text  = p < t_players ? gameManager.players[p].description : "---";
            txtPoints[count].text   = p < t_players ? gameManager.players[p].t_points.ToString("D4") : "0000";

            float stopwatch         = p < t_players ? gameManager.players[p].t_stopwatch : 0;

            txtStopwatchs[count].text = gameManager.FormatStopwatch(stopwatch);

            count++;
        }        
    }

    /*
    Tarefas executadas pelo botão transitar para tela "Seleção de Nível".
    */
    public void OnLevels()
    {
        panelManager.CloseRanks();
    }

    /*
    Tarefas executadas pelo botão "Página de Classificação Geral Seguinte".
    */
    public void OnNext()
    {
        c_page++;
        c_page = Mathf.Clamp(c_page, 0, 2);

        UpdateUI();
    }

    /*
    Tarefas executadas pelo botão "Página de Classificação Geral Antecedente".
    */
    public void OnPrevious()
    {
        c_page--;
        c_page = Mathf.Clamp(c_page, 0, 2);

        UpdateUI();
    }
}
