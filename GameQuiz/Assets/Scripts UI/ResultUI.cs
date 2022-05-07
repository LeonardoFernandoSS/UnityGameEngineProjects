using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{    
    public QuizManager quizManager;
    public GameManager gameManager;
    public PanelManager panelManager;

    public Button btnQuestion;
    public Button btnFinish;

    public Text txtResult;
    public Text txtQuestion;

    public int t_questions;
    public int c_question;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        t_questions = quizManager.t_questions;
        c_question = quizManager.c_question;
    
        UpdateUI();
    }

    /*
    Ativa ou desativa botões " Verificar Resultado do Teste" e "Proxima Questão".
    Atualiza as informações dos campo de texto "Enunciado da questão" e "Resultado da Questão".
    */
    void UpdateUI()
    {
        btnQuestion.gameObject.SetActive(c_question < t_questions - 1);
        btnFinish.gameObject.SetActive(c_question == t_questions - 1);

        txtResult.text = gameManager.question.correct == quizManager.hunch ? "CORRETA" : "INCORRETA";

        txtQuestion.text = (quizManager.c_question + 1).ToString("D2") + ". ";
        txtQuestion.text += gameManager.questions[c_question].description;
    }

    /*
    Tarefas executadas pelo botão transitar para tela "Responder Questão".
    */
    public void OnQuestion()
    {
        quizManager.Next();

        gameManager.PlayQuestion(quizManager.c_question);

        quizManager.Play();

        panelManager.ResultToQuestion();
    }

    /*
    Tarefas executadas pelo botão abrir tela "Visualizar Comentário".
    */
    public void OnComment()
    {
        panelManager.OpenComment();
    }

    /*
    Tarefas executadas pelo botão transitar para tela "Resultado Teste".
    */
    public void OnFinish()
    {
        gameManager.NewRecord(quizManager.points, quizManager.stopwatch);

        panelManager.ResultToFinish();
    }
}
