using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBattleController : MonoBehaviour
{

    [SerializeField] string sceneBattle;
    [SerializeField] EnemysList enemysList;

    public void StartBattle(int? index = null)
    {
        enemysList.SelectedEnemy(index);
        SceneManager.LoadScene(sceneBattle);
    }

}
