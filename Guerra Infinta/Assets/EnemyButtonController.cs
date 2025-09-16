using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BattleSystem;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyButtonController : MonoBehaviour
{

    BattleSystem battleSystem;
    VerificateButtonUI verificateButtonUI;

    [SerializeField] private GameObject[] verificateEnemyButton;
    [SerializeField] private Button[] enemyButton;

    void Start()
    {
        battleSystem = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
        verificateButtonUI = GameObject.Find("ButtonsController").GetComponent<VerificateButtonUI>();
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
                //enemyButton[i].Select();
            }
            /*else
            {
                enemyButton.RemoveAt(i);
                verificateEnemyButton.RemoveAt(i);
                i--;
            }*/
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
                //enemyButton[i].Select();
            }
            /*else
            {
                enemyButton.RemoveAt(i);
                verificateEnemyButton.RemoveAt(i);
                i--;
            }*/
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
        //VerificateButtonUI.DisactivateButtonsEnemy();
        DisactivateButtonsEnemy();
        verificateButtonUI.DisactivateReturnButton();
        battleSystem.GetToAttackEnemy(enemyNumber);
    }

    public void OnEnemyButtonIten(int enemyNumber, int itensIndex)
    {
        DisactivateButtonsEnemy();
        verificateButtonUI.DisactivateReturnButton();
        battleSystem.UseItem(itensIndex, enemyNumber);
    }
}
