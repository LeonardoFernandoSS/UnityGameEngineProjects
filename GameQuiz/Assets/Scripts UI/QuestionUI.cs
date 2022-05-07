using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionUI : MonoBehaviour
{
    public QuizManager quizManager;
    public GameManager gameManager;
    public PanelManager panelManager;

    public Button btnResult;

    public Text txtQuestion;

    public Toggle[] tgHunchs;

    public int c_question;
    public int c_hunch;
    public bool starting;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        starting = true;

        c_question = quizManager.c_question;

        quizManager.hunch = "";

        StartUI();

        starting = false;
    }

    void StartUI()
    {
        foreach (Toggle tgHunch in tgHunchs)
        {
            tgHunch.isOn = false;
        }

        UpdateUI();        
    }

    /*
    Ativa ou desativa botões "Verificar Resultado da Questão".
    Atualiza as informações dos campo de texto "Enunciado da questão".
    */
    void UpdateUI()
    {
        btnResult.interactable = quizManager.hunch != "";

        txtQuestion.text = (quizManager.c_question + 1).ToString("D2") + ". ";
        txtQuestion.text += gameManager.questions[c_question].description;

        int i_option = 0;

        foreach (Toggle tgHunch in tgHunchs)
        {
            tgHunch.GetComponentInChildren<Text>().text = gameManager.questions[c_question].incorrects[i_option];

            i_option++;
        }
    }

    /*
    Tarefas executadas pela caixa de seleção de "Alternativa" quando marcada.
    */ 
    public void OnMark(int c_hunch)
    {
        if (!starting)
        {
            quizManager.NewHunch(gameManager.question.incorrects[c_hunch]);

            UpdateUI();
        }    
    }

    /*
    Tarefas executadas pelo botão transitar para tela "Resultado Questão".
    */
    public void OnResult()
    {
        quizManager.CheckHunch(gameManager.question.correct, gameManager.level.multiplication);

        quizManager.Stop();

        panelManager.QuestionToResult();
    }

    /*
    Tarefas executadas pelo botão abrir tela "Visualizar Comentário".
    */
    public void OnComment()
    {
        quizManager.Pause();

        panelManager.OpenComment();
    }
}
