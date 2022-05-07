using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountUI : MonoBehaviour
{
    public GameManager gameManager;
    public PanelManager panelManager;

    public InputField inpAccount;
    public Button btnPlayers;

    public string account;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        account = "";

        UpdateUI();
    }

    /*
    Ativa ou desativa botão "Criar jogador"
    Atualiza informação da caixa de texto "Nome jogador"
    */
    void UpdateUI()
    {
        btnPlayers.interactable = !(account == "" || gameManager.ExistPlayer(inpAccount.text));

        inpAccount.text = account;
    }

    /*
    Tarefas executadas pelo botão transitar para tela "Seleção de Jogador".
    */
    public void OnPlayers()
    {
        panelManager.AccountToPlayers();
    }

    /*
    Tarefas executadas pelo botão salvar atualização do comentário e transitar para tela "Seleção de Jogador".
    */ 
    public void OnSave()
    {
        gameManager.NewPlayer(inpAccount.text);    

        OnPlayers();
    }

    /*
    Tarefas executadas pela caixa de texto "Nome Jogador" quando atualizada.
    */ 
    public void OnChangeAccount()
    {
        account = inpAccount.text;

        UpdateUI();
    }
}
