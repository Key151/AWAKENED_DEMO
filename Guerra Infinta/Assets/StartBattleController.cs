using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBattleController : MonoBehaviour
{

    [SerializeField] string sceneBattle;
    [SerializeField] EnemysList enemysList;

    public void StartBattle(IReadOnlyList<GameObject> enemies = null)
    {
        PlayerManager.Instance.SavePosition();
        enemysList.SelectedEnemy(enemies);
        SceneManager.LoadScene(sceneBattle);
    }

}
