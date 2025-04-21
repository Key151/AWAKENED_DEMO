using UnityEngine;
using UnityEngine.UI;


public class VerificateButtonUI : MonoBehaviour
{
    public Button primaryButtonPlayer;
    public Button primaryButtonPlayer_2;
    public Button primaryButtonPlayer_3;
    public Button primaryButtonEnemy;
    public Button primaryButtonMove;

    public GameObject attackButton;
    public GameObject mpButton;
    public GameObject healButton;
    public GameObject toMovementButton;
    public GameObject moveButton;
    public GameObject returnButton;
    public GameObject enemyButton;
    public GameObject optionPanel;
    public GameObject dialoguePanel;



    // DISATIVAR BOTOES

    // Desativa os primeiros botões de ataque e MP
    public void DisactivateButtons()
    {
        attackButton.SetActive(false);
        mpButton.SetActive(false);
        optionPanel.SetActive(false);
    }

    //Após clicar no botão MP, será desativado esses botões: Cura e Movimento
    public void DisactivateButtonsMP()
    {
        healButton.SetActive(false);
        toMovementButton.SetActive(false);
        optionPanel.SetActive(false);
    }
    //Após clicar no botão Movimento, será ativado esses botões: Mover e Retornar
    public void DisactivateButtonsMovement()
    {
        moveButton.SetActive(false);
        returnButton.SetActive(false);
        optionPanel.SetActive(false);
    }

    //Desativa  os botões para atacar os inimigos
    public void DisactivateButtonsEnemy()
    {
        enemyButton.SetActive(false);
    }

    public void DisactivateDialguePanel()
    {
        dialoguePanel.SetActive(false);
    }

    

    // ATIVAR BOTOES

    // Ativa os primeiros botões de ataque e MP
    public void ActivateButtons()
    {
        optionPanel.SetActive(true);
        attackButton.SetActive(true);
        mpButton.SetActive(true);
        primaryButtonPlayer.Select();
    }

    //Após clicar no botão MP, será ativado esses botões: Cura e Movimento
    public void ActivateButtonsMP()
    {
        optionPanel.SetActive(true);
        healButton.SetActive(true);
        toMovementButton.SetActive(true);
        primaryButtonPlayer_2.Select();
    }

    //Após clicar no botão Movimento, será ativado esses botões: Mover e Retornar
    public void ActivateButtonsMovement()
    {
        optionPanel.SetActive(true);
        moveButton.SetActive(true);
        returnButton.SetActive(true);
        primaryButtonPlayer_3.Select();
    }

<<<<<<< Updated upstream
    public void SelectEnemy()
=======
    //Ativa  os botões para atacar os inimigos
    public void ActivateButtonsEnemy()
>>>>>>> Stashed changes
    {
        enemyButton.SetActive(true);
        primaryButtonEnemy.Select();
    }

    
    public void ActivateDialguePanel()
    {
        dialoguePanel.SetActive(true);
    }
}
