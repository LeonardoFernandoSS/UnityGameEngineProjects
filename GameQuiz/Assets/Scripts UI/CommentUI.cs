using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentUI : MonoBehaviour
{
    public GameManager gameManager;
    public QuizManager quizManager;
    public PanelManager panelManager;

    public InputField inpComment;
    public Button btnQuestion;

    public Text txtPlayer;
    public Text txtQuestion;

    public string comment;
    
    public int c_question;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        c_question = quizManager.c_question;

        comment = "";
        comment = gameManager.question.comment;

        UpdateUI();
    }

    /*
    Atualiza as informações da caixa de texto "Comentário" e campo de texto "Enunciado da questão".
    */
    void UpdateUI()
    {
        inpComment.text = comment;

        //txtQuestion.text = (quizManager.c_question + 1).ToString("D2") + ". ";
        txtQuestion.text = gameManager.questions[c_question].description;
        txtPlayer.text = gameManager.player.description;
    }

    /*
    Tarefas executadas pelo botão fechar tela "Visualizar Comentário".
    */ 
    public void OnQuestion()
    {
        if (quizManager.gameObject.activeSelf == true)
        {
            quizManager.Play();
        }        

        panelManager.CloseComment();
    }

    /*
    Tarefas executadas pelo botão salvar atualização do comentário e fechar tela "Visualizar Comentário".
    */ 
    public void OnSave()
    {
        gameManager.NewComment(inpComment.text);
        
        OnQuestion();
    }

    /*
    Tarefas executadas pela caixa de texto "Comentário" quando atualizada.
    */ 
    public void OnChangeComment()
    {
        comment = inpComment.text;

        UpdateUI();
    }
}
