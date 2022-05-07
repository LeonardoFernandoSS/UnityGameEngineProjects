using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{
    public GameManager gameManager;
    public PanelManager panelManager;

    public int c_question;
    public int t_questions;

    public Button btnNext;
    public Button btnPrevious;

    public Text txtSuport;
    public Text txtLevel;
    public Text txtQuestion;

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
    Ativa ou desativa botões "Material de Apoio antecedente" e "Material de Apoio seguinte".
    Atualiza as informações dos campo de texto "Enunciado do Matérial de Apoio", "Descrição do Nível".
    */
    void UpdateUI()
    {
        btnNext.interactable        = c_question < t_questions - 1;
        btnPrevious.interactable    = c_question > 0;

        txtQuestion.text = gameManager.questions[c_question].description;
        txtSuport.text = gameManager.questions[c_question].support;
        txtLevel.text = gameManager.level.description;    
    }

    /*
    Tarefas executadas pelo botão fechar tela "Seleção de Material de Apoio".
    */
    public void OnLevels()
    {
        gameManager.DropQuestions();

        panelManager.CloseIntro();
    }

    /*
    Tarefas executadas pelo botão "Material de Apoio Seguinte".
    */
    public void OnNext()
    {
        c_question++;
        c_question = Mathf.Clamp(c_question, 0, t_questions);

        UpdateUI();
    }

    /*
    Tarefas executadas pelo botão "Material de Apoio Antecedente".
    */
    public void OnPrevious()
    {
        c_question--;
        c_question = Mathf.Clamp(c_question, 0, t_questions);

        UpdateUI();
    }
}
