using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool IsGamePaused { get; private set; } = false;
    [SerializeField] EnemysList enemysList;

    void Start()
    {
        enemysList.selectedEnemy();
        IsGamePaused = false;
    }
    public static void SetPause(bool pause)
    {
        IsGamePaused = pause;
    }
}
