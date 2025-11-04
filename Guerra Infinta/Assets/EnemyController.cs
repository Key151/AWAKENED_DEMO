using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;

    private HashSet<string> defeatedEnemies = new HashSet<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void MarkEnemyDefeated(string enemyID)
    {
        defeatedEnemies.Add(enemyID);
    }

    public bool IsEnemyDefeated(string enemyID)
    {
        return defeatedEnemies.Contains(enemyID);
    }

    public HashSet<string> SetDefeatedEnemies()
    {
        return defeatedEnemies;
    }

    public void GetDefeatedEnemies(HashSet<string> enemy)
    {
        defeatedEnemies = enemy;
    }
}