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


    void Start()
    {
        battleSystem = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
    }


    public void SelectEnemyButtonsItens(int itensIndex)
    {
        for (int i = 0; i < verificateEnemyButton.Length; i++)
        {
            if (verificateEnemyButton[i].activeSelf)
            {
                enemyButton[i].onClick.RemoveAllListeners();
                int index = i;
                enemyButton[i].onClick.AddListener(() => { battleSystem.OnEnemyButtonIten(index, itensIndex); });
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
                enemyButton[i].onClick.RemoveAllListeners();
                int index = i;
                enemyButton[i].onClick.AddListener(() => {battleSystem.OnEnemyButtonAttack(index); });
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
}
