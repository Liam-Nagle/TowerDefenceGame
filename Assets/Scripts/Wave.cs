using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    public List<EnemyBlueprint> enemyWave;


    public Wave(List<EnemyBlueprint> EnemyBP)
    {
        enemyWave = EnemyBP;
    }
}
