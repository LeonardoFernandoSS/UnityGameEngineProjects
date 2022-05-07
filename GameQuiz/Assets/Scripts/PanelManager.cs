using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public Animator animator;

    public GameObject accountUI;
    public GameObject commentUI;
    public GameObject commentsUI;
    public GameObject finishUI;
    public GameObject introUI;
    public GameObject levelsUI;
    public GameObject playersUI;
    public GameObject questionUI;
    public GameObject ranksUI;
    public GameObject rankUI;
    public GameObject resultUI;

    /*
    Executa transição entre as telas "Seleção de Nível" para "Seleção de Jogador".
    */
    public void LevelsToPlayers()
    {
        animator.SetTrigger("Right");

        playersUI.SetActive(true);
        levelsUI.SetActive(false);
    }

    /*
    Executa transição entre as telas "Seleção de Jogador" para "Seleção de Nível".
    */
    public void PlayersToLevels()
    {
        animator.SetTrigger("Left");

        levelsUI.SetActive(true);
        playersUI.SetActive(false);
    }

    /*
    Executa transição entre as telas "Seleção de Jogador" para "Novo Jogador".
    */
    public void PlayersToAccount()
    {
        animator.SetTrigger("Right");

        accountUI.SetActive(true);
        playersUI.SetActive(false);
    }

    /*
    Executa transição entre as telas "Novo Jogador" para "Seleção de Jogador".
    */
    public void AccountToPlayers()
    {
        animator.SetTrigger("Left");

        playersUI.SetActive(true);
        accountUI.SetActive(false);
    }

    /*
    Executa transição entre as telas "Seleção de Jogador" para "Responder Questão".
    */
    public void PlayersToQuestion()
    {
        animator.SetTrigger("Right");

        questionUI.SetActive(true);
        playersUI.SetActive(false);
    }

    /*
    Executa transição entre as telas "Responder Questão" para "Resultado Questão".
    */
    public void QuestionToResult()
    {
        animator.SetTrigger("Right");

        resultUI.SetActive(true);
        questionUI.SetActive(false);
    }

    /*
    Apresenta tela "Visualizar Comentário" sobre a anterior.
    */
    public void OpenComment()
    {
        animator.SetTrigger("Open");

        commentUI.SetActive(true);
    }

    /*
    Esconde tela "Visualizar Comentário" e apresenta tela anterior.
    */
    public void CloseComment()
    {
        animator.SetTrigger("Close");

        commentUI.SetActive(false);
    }
    /*
    Apresenta tela "Seleção de Comentário" sobre a anterior.
    */
    public void OpenComments()
    {
        animator.SetTrigger("Open");

        commentsUI.SetActive(true);
    }

    /*
    Esconde tela "Seleção de Comentário" e apresenta tela anterior.
    */
    public void CloseComments()
    {
        animator.SetTrigger("Close");

        commentsUI.SetActive(false);
    }
    /*
    Apresenta tela "Classificação Geral" sobre a anterior.
    */
    public void OpenRanks()
    {
        animator.SetTrigger("Open");

        ranksUI.SetActive(true);
    }

    /*
    Esconde tela "Classificação Geral" e apresenta tela anterior.
    */
    public void CloseRanks()
    {
        animator.SetTrigger("Close");

        ranksUI.SetActive(false);
    }
    /*
    Apresenta tela "Classificação por Nível" sobre a anterior.
    */
    public void OpenRank()
    {
        animator.SetTrigger("Open");

        rankUI.SetActive(true);
    }

    /*
    Esconde tela "Classificação por Nível" e apresenta tela anterior.
    */
    public void CloseRank()
    {
        animator.SetTrigger("Close");

        rankUI.SetActive(false);
    }
    /*
    Apresenta tela "Seleção de Material de Apoio" sobre a anterior.
    */
    public void OpenIntro()
    {
        animator.SetTrigger("Open");

        introUI.SetActive(true);
    }

    /*
    Esconde tela "Seleção de Material de Apoio" e apresenta tela anterior.
    */
    public void CloseIntro()
    {
        animator.SetTrigger("Close");

        introUI.SetActive(false);
    }

    /*
    Executa transição entre as telas "Resultado Questão" para "Responder Questão".
    */
    public void ResultToQuestion()
    {
        animator.SetTrigger("Right");

        questionUI.SetActive(true);
        resultUI.SetActive(false);
    }

    /*
    Executa transição entre as telas "Resultado Questão" para "Resultado Teste".
    */
    public void ResultToFinish()
    {
        animator.SetTrigger("Right");

        finishUI.SetActive(true);
        resultUI.SetActive(false);
    }

    /*
    Executa transição entre as telas "Resultado Teste" para "Seleção de Jogador".
    */
    public void FinishToPlayers()
    {
        animator.SetTrigger("Left");

        playersUI.SetActive(true);
        finishUI.SetActive(false);
    }

    /*
    Executa transição entre as telas "Resultado Teste" para "Seleção de Nível".
    */
    public void FinishToLevels()
    {
        animator.SetTrigger("Left");

        levelsUI.SetActive(true);
        finishUI.SetActive(false);        
    }
}
