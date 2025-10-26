using UnityEngine;
using System.Collections.Generic;

public class EnemysList: MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList;
    public static List<GameObject> enemyPrefab = new List<GameObject>();
    public static int qtdEnemy;

    [Header("Enemy percent")]
    [SerializeField] private int percentEnemySpaw = 100;
    [SerializeField] private int minusPercent = 15; // Modificar posteriormente para dado de acordo para cada inimigo

    public void SelectedEnemy(IReadOnlyList<GameObject> enemies = null)
    {
        if (enemies == null)
        {
            qtdEnemy = 0;
            enemyPrefab?.Clear();
            for (int maxEnemy = 3; maxEnemy > 0; maxEnemy--)
            {
                if (percentEnemySpaw >= Random.Range(0, 100))
                {
                    int index = Random.Range(0, enemyList.Count);
                    enemyPrefab.Add(enemyList[index]);
                    percentEnemySpaw -= minusPercent;
                    qtdEnemy++;
                }
            }
        }
        else
        {
            qtdEnemy = 0;
            enemyPrefab?.Clear();
            for (int index = 0; index < enemies.Count; index++)
            {
                enemyPrefab.Add(enemies[index]);
                qtdEnemy++;
            }
        }
    }
}