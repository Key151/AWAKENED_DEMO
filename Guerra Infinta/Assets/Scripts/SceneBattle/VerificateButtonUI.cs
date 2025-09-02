using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class VerificateButtonUI : MonoBehaviour
{
    [SerializeField] private Button primaryButtonPlayer;
    [SerializeField] private Button primaryButtonEnemy;

    [SerializeField] private GameObject attackButton;
    [SerializeField] private GameObject returnButton;
    //[SerializeField] private GameObject enemyButton_1;
    //[SerializeField] private GameObject enemyButton_2;
    //[SerializeField] private GameObject enemyButton_3;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private GameObject itensPanel;

    public GameObject[] enemyButtonsGO; // GameObject dos botıes dos inimigos para poder ativar e desavitar
    public Button[] enemyButtons;       // Buttons dos botıes dos inimigos para poder selecionar
    public GameObject[] verificateEnemyButton; // Objeto que pertence ao bot„o, se ele for desativado, o bot„o ficarÅEdesativado
    public GameObject[] enemyUI;

    [SerializeField] private ItensUI itensUI;


    public void Update()
    {

    }

    //Move o painel de aÁıes
    /*public void MovePanel(UnitPlayer player)
    {
        optionPanel.transform.position = new Vector2(player.transform.position.x + 3.5f, player.transform.position.y);
    }*/

    // ATIVAR BOTOES

    // Ativa os  botıes de ataque e Voltar
    public void ActivateButtons()
    {
        optionPanel.SetActive(true);
        attackButton.SetActive(true);
        returnButton.SetActive(true);
        primaryButtonPlayer.Select();
    }

    public void SelectEnemy()//Ativa  os botıes para atacar os inimigos
    {
        for(int i = 0; i < verificateEnemyButton.Length; i++)
        {
            if (verificateEnemyButton[i].activeSelf)
            {
                enemyButtonsGO[i].SetActive(true);
                enemyButtons[i].Select();
            }
        }
        //primaryButtonEnemy.Select();
    }
    
    public void ActivateDialguePanel() //Ativa o painel de aÁıes
    {
        dialoguePanel.SetActive(true);
    }

    public void ActivateItensPanel() //Ativa o painel de aÁıes
    {
        //itensUI.UpdateItensUI();
        itensPanel.SetActive(true);
    }


    // DESATIVAR BOTOES


    public void DisactivateButtons() // Desativa os botıes de ataque e Voltar
    {
        attackButton.SetActive(false);
        returnButton.SetActive(false);
        optionPanel.SetActive(false);
    }

    
    public void DisactivateButtonsEnemy() //Desativa  os botıes para atacar os inimigos
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

    // ATUALIZA OS BOT‘ES DOS INIMIGOS

    public void KillEnemyButton(int enemyKilled) //N„o permite que o bot„o do inimigo fique ativo
    {
        verificateEnemyButton[enemyKilled].SetActive(false);
    }




    /*
    public void UpdateEnemyButtonDown() //Faz com que a seleÁ„o dos botıes dos inimigos vÅEpara baixo
    {

        selectedEnemyButton++;

        while (!enemyButtons[selectedEnemyButton].IsActive())
        {
            selectedEnemyButton++;
            if(selectedEnemyButton >= 3)
            {
                selectedEnemyButton = 0;
            }
        }    
        enemyButtons[selectedEnemyButton].Select();

    }*/


    /*
    public void UpdateEnemyButtonUp() //Faz com que a seleÁ„o dos botıes dos inimigos vÅEpara cima
    {
        selectedEnemyButton --;

        while (!enemyButtons[selectedEnemyButton].IsActive())
        {
            selectedEnemyButton--;
            if(selectedEnemyButton < 0)
            {
                selectedEnemyButton = 3;
            }
        }
        enemyButtons[selectedEnemyButton].Select();
        
    }*/
}
