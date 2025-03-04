using UnityEngine;
using UnityEngine.UI;


public class VerificateButtonUI : MonoBehaviour
{
    public Button primaryButtonPlayer;
    public Button primaryButtonPlayer_2;
    public Button primaryButtonEnemy;

    public GameObject attackButton;
    public GameObject mpButton;
    public GameObject healButton;
    public GameObject returnButton;
    public GameObject enemyButton;
    public GameObject optionPanel;
    public GameObject dialoguePanel;



    // DISATIVAR BOTOES
    public void DisactivateButtons()
    {
        attackButton.SetActive(false);
        mpButton.SetActive(false);
        optionPanel.SetActive(false);
    }

    public void DisactivateButtonsEnemy()
    {
        enemyButton.SetActive(false);
    }

    public void DisactivateDialguePanel()
    {
        dialoguePanel.SetActive(false);
    }

    public void DisactivateButtonsMP()
    {
        healButton.SetActive(false);
        returnButton.SetActive(false);
        optionPanel.SetActive(false);
    }

    // ATIVAR BOTOES
    public void ActivateButtonsMP()
    {
        optionPanel.SetActive(true);
        healButton.SetActive(true);
        returnButton.SetActive(true);
        primaryButtonPlayer_2.Select();
    }

    public void ActivateButtonsEnemy()
    {
        enemyButton.SetActive(true);
        primaryButtonEnemy.Select();
    }
    public void ActivateButtons()
    {
        optionPanel.SetActive(true);
        attackButton.SetActive(true);
        mpButton.SetActive(true);
        primaryButtonPlayer.Select();
    }
    public void ActivateDialguePanel()
    {
        dialoguePanel.SetActive(true);
        //Debug.LogError("Erro");
    }
}
