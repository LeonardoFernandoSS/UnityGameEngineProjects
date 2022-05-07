using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentsUI : MonoBehaviour
{
    public GameManager gameManager;
    public PanelManager panelManager;

    public int c_question;
    public int t_questions;

    public Button btnNext;
    public Button btnPrevious;

    public Text txtPlayer;
    public Text txtQuestion;
    public Text txtComment;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        t_questions = gameManager.questions.Length;

        UpdateUI();
    }

    /*
    Ativa ou desativa botões "Comentário antecedente" e "Comentário seguinte".
    Atualiza as informações dos campo de texto "Enunciado da questão", "Comentário" e "Nome do jogador".
    */
    void UpdateUI()
    {
        btnNext.interactable        = c_question < t_questions - 1;
        btnPrevious.interactable    = c_question > 0;

        string comment = gameManager.questions[c_question].comment;

        txtQuestion.text    = gameManager.questions[c_question].description;
        txtComment.text     = comment == "" ? "Nenhum comentários ou anotação salva para está questão." : comment;
        txtPlayer.text      = gameManager.player.description;
    }

    /*
    Tarefas executadas pelo botão fechar tela "Seleção de Comentários".
    */
    public void OnPlayers()
    {
        gameManager.DropQuestions();

        panelManager.CloseComments();
    }

    /*
    Tarefas executadas pelo botão "Comentário Seguinte".
    */
    public void OnNext()
    {
        c_question++;
        c_question = Mathf.Clamp(c_question, 0, t_questions);

        UpdateUI();
    }

    /*
    Tarefas executadas pelo botão "Comentário Antecedente".
    */
    public void OnPrevious()
    {
        c_question--;
        c_question = Mathf.Clamp(c_question, 0, t_questions);

        UpdateUI();
    }
}
