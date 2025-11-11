using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class VerificateButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject attackButton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject itensButton;
    [SerializeField] private GameObject returnButton;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private GameObject itensPanel;

    [SerializeField] private EnemyButtonController enemyButtonController;

    // ATIVAR BOTOES

    // Ativa os  botões de ataque e Voltar
    public void ActivateButtons()
    {
        optionPanel.SetActive(true);
        attackButton.SetActive(true);
        itensButton.SetActive(true);
        backButton.SetActive(true);
    }
    
    /*public void ActivateDialguePanel() //Ativa o painel de Dialogo
    {
        dialoguePanel.SetActive(true);
    }*/

    public void ActivateItensPanel() //Ativa o painel de Itens
    {
        itensPanel.SetActive(true);
    }

    public void ActivateReturnButton()
    {
        optionPanel.SetActive(true);
        returnButton.SetActive(true);
    }


    // DESATIVAR BOTOES


    public void DisactivateButtons() // Desativa os botoes de ataque e Voltar
    {
        attackButton.SetActive(false);
        itensButton.SetActive(false);
        backButton.SetActive(false);
        returnButton.SetActive(false);
        optionPanel.SetActive(false);
    }

    /*public void DisactivateDialguePanel()
    {
        dialoguePanel.SetActive(false);

    }*/

    public void DisactivateItensPanel() //Ativa o painel de Itens
    {
        itensPanel.SetActive(false);
        optionPanel.SetActive(false);
        returnButton.SetActive(false);
    }

    public void DisactivateReturnButton()
    {
        enemyButtonController.DisactivateButtonsEnemy();
        optionPanel.SetActive(false);
        returnButton.SetActive(false);
        DisactivateItensPanel();
    }

    public void SetPosition(Vector3 NewPosition)
    {
        optionPanel.transform.position = NewPosition;
    }
}
