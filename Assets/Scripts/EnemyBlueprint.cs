using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueprint : MonoBehaviour
{
        public Enemy enemy;
        public int enemyCount;
        public float enemyRate;

    public void AddEnemy(Enemy Enemy, int Count, float Rate)
    {
        enemy = Enemy;
        enemyCount = Count;
        enemyRate = Rate;
    }
}
