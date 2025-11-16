using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyButtonController : MonoBehaviour
{
    [SerializeField] private GameObject[] verificateEnemyButton;
    [SerializeField] private Button[] enemyButton;

    [Header("Classes")]
    [SerializeField] private BattleSystem battleSystem;
    [SerializeField] private VerificateButtonUI verificateButtonUI;


    private void Awake()
    {
        for(int i = 0; i < verificateEnemyButton.Length; i++)
        {
            KillEnemyButton(i);
        }
    }

    public void UseItem(int index, TypeBattle type)
    {
        if(type == TypeBattle.TargetEnemy)
        {
            SelectEnemyButtonsItens(index);
        }
        else if (type == TypeBattle.TargetPlayer)
        {

        }
    }

    public void SelectPlayerItens()
    {

    }

    public void SelectEnemyButtonsItens(int itensIndex)
    {
        for (int i = 0; i < verificateEnemyButton.Length; i++)
        {
            if (verificateEnemyButton[i].activeSelf)
            {
                enemyButton[i].onClick.RemoveAllListeners();
                int index = i;
                enemyButton[i].onClick.AddListener(() => { OnEnemyButtonIten(index, itensIndex); });
                enemyButton[i].gameObject.SetActive(true);
            }
        }
    }

    public void SelectEnemyButtonAtack()
    {
        for (int i = 0; i < verificateEnemyButton.Length; i++)
        {
            if (verificateEnemyButton[i].activeSelf)
            {
                enemyButton[i].onClick.RemoveAllListeners();
                int index = i;
                enemyButton[i].onClick.AddListener(() => {OnEnemyButtonAttack(index); });
                enemyButton[i].gameObject.SetActive(true);
            }
        }
    }

    public void DisactivateButtonsEnemy() //Desativa  os botões para atacar os inimigos
    {
        for (int i = 0; i < enemyButton.Length; i++)
        {
            enemyButton[i].gameObject.SetActive(false);
        }
    }

    public void OnEnemyButtonAttack(int enemyNumber)
    {
        verificateButtonUI.DisactivateReturnButton();
        battleSystem.GetToAttackEnemy(enemyNumber);
    }

    public void OnEnemyButtonIten(int enemyNumber, int itensIndex)
    {
        verificateButtonUI.DisactivateReturnButton();
        StartCoroutine(battleSystem.UseItem(itensIndex, enemyNumber));
    }

    public void KillEnemyButton(int enemyKilled) //Desativa o botao do inimigo
    {
        verificateEnemyButton[enemyKilled].SetActive(false);
    }

    public void ActivateEnemyButton(int enemyActive) // Ativa o botão do inimigo
    {
        verificateEnemyButton[enemyActive].SetActive(true);
    }

}
