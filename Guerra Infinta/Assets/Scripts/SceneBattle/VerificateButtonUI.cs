using UnityEngine;
using UnityEngine.UI;


public class VerificateButtonUI : MonoBehaviour
{
    [SerializeField] private Button primaryButtonPlayer;
    [SerializeField] private Button primaryButtonPlayer_2;
    [SerializeField] private Button primaryButtonPlayer_3;
    [SerializeField] private Button primaryButtonEnemy;
    [SerializeField] private Button primaryButtonMove;

    [SerializeField] private GameObject attackButton;
    [SerializeField] private GameObject mpButton;
    [SerializeField] private GameObject healButton;
    [SerializeField] private GameObject toMovementButton;
    [SerializeField] private GameObject moveButton;
    [SerializeField] private GameObject returnButton;
    [SerializeField] private GameObject enemyButton_1;
    [SerializeField] private GameObject enemyButton_2;
    [SerializeField] private GameObject enemyButton_3;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject dialoguePanel;

    public void MovePanel(UnitPlayer player)
    {
        optionPanel.transform.position = new Vector2(player.transform.position.x + 2.0f, player.transform.position.y);
    }

    // Desativa os primeiros botıes de ataque e MP
    public void DisactivateButtons()
    {
        attackButton.SetActive(false);
        mpButton.SetActive(false);
        optionPanel.SetActive(false);
    }

    //ApÛs clicar no bot„o MP, serÅEdesativado esses botıes: Cura e Movimento
    public void DisactivateButtonsMP()
    {
        healButton.SetActive(false);
        toMovementButton.SetActive(false);
        optionPanel.SetActive(false);
    }
    //ApÛs clicar no bot„o Movimento, serÅEativado esses botıes: Mover e Retornar
    public void DisactivateButtonsMovement()
    {
        moveButton.SetActive(false);
        returnButton.SetActive(false);
        optionPanel.SetActive(false);
    }

    //Desativa  os botıes para atacar os inimigos
    public void DisactivateButtonsEnemy()
    {
        enemyButton_1.SetActive(false);
        enemyButton_2.SetActive(false);
        enemyButton_3.SetActive(false);
    }

    public void DisactivateDialguePanel()
    {
        dialoguePanel.SetActive(false);
    }

    

    // ATIVAR BOTOES

    // Ativa os primeiros botıes de ataque e MP
    public void ActivateButtons()
    {
        optionPanel.SetActive(true);
        attackButton.SetActive(true);
        mpButton.SetActive(true);
        primaryButtonPlayer.Select();
    }

    //ApÛs clicar no bot„o MP, serÅEativado esses botıes: Cura e Movimento
    public void ActivateButtonsMP()
    {
        optionPanel.SetActive(true);
        healButton.SetActive(true);
        toMovementButton.SetActive(true);
        primaryButtonPlayer_2.Select();
    }

    //ApÛs clicar no bot„o Movimento, serÅEativado esses botıes: Mover e Retornar
    public void ActivateButtonsMovement()
    {
        optionPanel.SetActive(true);
        moveButton.SetActive(true);
        returnButton.SetActive(true);
        primaryButtonPlayer_3.Select();
    }
    public void SelectEnemy()
    {
        enemyButton_1.SetActive(true);
        enemyButton_2.SetActive(true);
        enemyButton_3.SetActive(true);
        primaryButtonEnemy.Select();
    }

    //Ativa  os botıes para atacar os inimigos
    public void ActivateButtonsEnemy()
    {
        enemyButton_1.SetActive(true);
        enemyButton_2.SetActive(true);
        enemyButton_3.SetActive(true);
        primaryButtonEnemy.Select();
    }

    
    public void ActivateDialguePanel()
    {
        dialoguePanel.SetActive(true);
    }
}
