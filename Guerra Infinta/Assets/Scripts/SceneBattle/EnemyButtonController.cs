using UnityEngine;
using UnityEngine.UI;

public class EnemyButtonController : MonoBehaviour
{
    [SerializeField] private GameObject[] verificateEnemyButton;
    [SerializeField] private Button[] enemyButton;

    [Header("Classes")]
    [SerializeField] private BattleSystem battleSystem;
    [SerializeField] private VerificateButtonUI verificateButtonUI;


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
        DisactivateButtonsEnemy();
        verificateButtonUI.DisactivateReturnButton();
        battleSystem.GetToAttackEnemy(enemyNumber);
    }

    public void OnEnemyButtonIten(int enemyNumber, int itensIndex)
    {
        DisactivateButtonsEnemy();
        verificateButtonUI.DisactivateReturnButton();
        StartCoroutine(battleSystem.UseItem(itensIndex, enemyNumber));
    }
}
