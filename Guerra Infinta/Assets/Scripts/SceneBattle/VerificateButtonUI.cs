using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class VerificateButtonUI : MonoBehaviour
{
    //[SerializeField] private Button primaryButtonPlayer;
    //[SerializeField] private Button primaryButtonEnemy;

    [SerializeField] private GameObject attackButton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject itensButton;
    [SerializeField] private GameObject returnButton;
    //[SerializeField] private GameObject enemyButton_1;
    //[SerializeField] private GameObject enemyButton_2;
    //[SerializeField] private GameObject enemyButton_3;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private GameObject itensPanel;

    public GameObject[] enemyButtonsGO; // GameObject dos botões dos inimigos para poder ativar e desavitar
    public Button[] enemyButtons;       // Buttons dos botões dos inimigos para poder selecionar
    public GameObject[] verificateEnemyButton; // Objeto que pertence ao botão, se ele for desativado, o botão fica desativado
    public GameObject[] enemyUI;

    [SerializeField] private ItensUI itensUI;


    public void Update()
    {

    }

    //Move o painel de ações
    /*public void MovePanel(UnitPlayer player)
    {
        optionPanel.transform.position = new Vector2(player.transform.position.x + 3.5f, player.transform.position.y);
    }*/

    // ATIVAR BOTOES

    // Ativa os  botões de ataque e Voltar
    public void ActivateButtons()
    {
        optionPanel.SetActive(true);
        attackButton.SetActive(true);
        itensButton.SetActive(true);
        backButton.SetActive(true);
        //primaryButtonPlayer.Select();
    }

    public void SelectEnemy()//Ativa  os botões para atacar os inimigos
    {
        for(int i = 0; i < verificateEnemyButton.Length; i++)
        {
            if (verificateEnemyButton[i].activeSelf)
            {
                enemyButtonsGO[i].SetActive(true);
                //enemyButtons[i].Select();
            }
        }
        //primaryButtonEnemy.Select();
    }
    
    public void ActivateDialguePanel() //Ativa o painel de Dialogo
    {
        dialoguePanel.SetActive(true);
    }

    public void ActivateItensPanel() //Ativa o painel de Itens
    {
        //itensUI.UpdateItensUI();
        itensPanel.SetActive(true);
    }

    public void ActivateReturnButton()
    {
        optionPanel.SetActive(true);
        returnButton.SetActive(true);
    }


    // DESATIVAR BOTOES


    public void DisactivateButtons() // Desativa os botões de ataque e Voltar
    {
        attackButton.SetActive(false);
        itensButton.SetActive(false);
        backButton.SetActive(false);
        returnButton.SetActive(false);
        optionPanel.SetActive(false);
    }

    
    public void DisactivateButtonsEnemy() //Desativa  os botões para atacar os inimigos
    {
        for (int i = 0; i < enemyButtonsGO.Length; i++)
        {
            enemyButtonsGO[i].SetActive(false);
        }
    }

    public void DisactivateDialguePanel()
    {
        dialoguePanel.SetActive(false);

    }

    public void DisactivateItensPanel() //Ativa o painel de Itens
    {
        itensPanel.SetActive(false);
        optionPanel.SetActive(false);
        returnButton.SetActive(false);
    }

    public void DisactivateReturnButton()
    {
        optionPanel.SetActive(false);
        returnButton.SetActive(false);
        DisactivateButtonsEnemy();
        DisactivateItensPanel();
    }

    // ATUALIZA OS BOTÔES DOS INIMIGOS

    public void KillEnemyButton(int enemyKilled) //Não permite que o botão do inimigo fique ativo
    {
        verificateEnemyButton[enemyKilled].SetActive(false);
    }
}
