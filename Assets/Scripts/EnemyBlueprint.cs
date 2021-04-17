using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueprint
{
    private Enemy enemy;
    private int enemyCount;
    private float enemyRate;
    private float timeToSpawnAt;


    public EnemyBlueprint(Enemy Enemy, int Count, float Rate, float spawnTime)
    {
        enemy = Enemy;
        enemyCount = Count;
        enemyRate = Rate;
        timeToSpawnAt = spawnTime;
    }

    public Enemy GetEnemy()
    {
        return enemy;
    }

    public int GetCount()
    {
        return enemyCount;
    }

    public float GetRate()
    {
        return enemyRate;
    }

    public float GetSpawnTime()
    {
        return timeToSpawnAt;
    }
}
