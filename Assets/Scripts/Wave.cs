using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
        public EnemyBlueprint[] enemyWave;


    public void AddWave(EnemyBlueprint[] EnemyBP)
    {
        enemyWave = EnemyBP;
    }
}
