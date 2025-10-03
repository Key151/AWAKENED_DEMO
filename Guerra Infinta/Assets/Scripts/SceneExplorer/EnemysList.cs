using UnityEngine;
using System.Collections.Generic;

public class EnemysList: MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList;
    public static List<GameObject> enemyPrefab = new List<GameObject>();
    public static int qtdEnemy;

    private int percentEnemySpaw = 100;
    private int minusPercent = 15; // Modificar posteriormente para dado de acordo para cada inimigo

    public void selectedEnemy()
    {
        qtdEnemy = 0;
        enemyPrefab?.Clear();
        for(int maxEnemy = 3; maxEnemy > 0; maxEnemy--) 
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
}