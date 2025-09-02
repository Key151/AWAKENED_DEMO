using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BattleSystem;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyButtonController : MonoBehaviour
{

    BattleSystem battleSystem;

    [SerializeField] private GameObject[] verificateEnemyButton;
    [SerializeField] private Button[] enemyButton;
    [SerializeField] private InventoryBattleList inventory;

    private enum State { Attack, Iten, Other }
    private State state;


    void Start()
    {
        battleSystem = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
        state = State.Other;
    }


    public void SelectEnemyButtonsItens(Unit player)
    {
        for (int i = 0; i < verificateEnemyButton.Length; i++)
        {
            if (verificateEnemyButton[i].activeSelf)
            {
                if(state != State.Iten)
                {
                    int index = i;
                    //enemyButton[i].onClick.AddListener(() => { UseItem(player, index); });
                }
                if (i == verificateEnemyButton.Length - 1)
                {
                    state = State.Iten;
                }
                enemyButton[i].gameObject.SetActive(true);
                enemyButton[i].Select();
            }
        }
    }

    public void SelectEnemyButtonAtack()
    {
        for (int i = 0; i < verificateEnemyButton.Length; i++)
        {
            if (verificateEnemyButton[i].activeSelf)
            {
                if (state != State.Attack)
                {
                    int index = i;
                    enemyButton[i].onClick.AddListener(() => {battleSystem.OnEnemyButton(index); });
                }
                if(i == verificateEnemyButton.Length -1)
                {
                    state = State.Attack;
                }
                enemyButton[i].gameObject.SetActive(true);
                enemyButton[i].Select();
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

    public void UseItem(Unit player,Unit target)
    {
        foreach (var item in inventory.inventoryList)
        {
            item.ApplyEffect(player, target);
        }
    }

}
