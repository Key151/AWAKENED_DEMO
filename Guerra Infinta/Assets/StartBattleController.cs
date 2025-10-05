using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBattleController : MonoBehaviour
{

    [SerializeField] string sceneBattle;
    [SerializeField] EnemysList enemysList;

    public void StartBattle()
    {
        enemysList.selectedEnemy();
        SceneManager.LoadScene(sceneBattle);
    }

}
