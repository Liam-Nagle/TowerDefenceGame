using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class Spawner : MonoBehaviour
{

    Wave[] waves;
    public Transform spawnPoint;
    public Enemy Enemy1;
    public Enemy Enemy2;

    private EnemyBlueprint[] enemies;
    private int waveIndex = 0;
    private int Difficulty;
    public static int EnemiesAlive;

    public float timeBetweenWaves = 5f;
    public float countdown = 2f;

    public Text waveCountdownText;
    public Text wavesText;

    private void Start()
    {
        //HARD CODE 100 WAVES?
        //OR PULL FROM A FILE THAT HAS 100 WAVES IN THEN CREATE A FUNCTION IN UPDATE THAT CREATES INFINITE WAVES?
    }

    private void Update()
    {
        if(EnemiesAlive <= 0)
        {
            //SPAWN NEXT WAVE  
        }

//        //for (int i = 0; i < 2; i++)
//        //{
//        //    StartCoroutine(SpawnEnemy(enemies2[i], 10, 10));
//        //}

//        //for (int i = 0; i < waveIndex; i++)
//        //{
//        //    enemies[i].AddEnemy(Enemy1, waveIndex * 8, waveIndex * 2);
//        //}


//        if (EnemiesAlive > 0)
//        {
//            return;
//        }

//        if (countdown <= 0f)
//        {
//x
//            countdown = timeBetweenWaves;
//            return;
//        }

//        countdown -= Time.deltaTime;

//        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

//        waveCountdownText.text = string.Format("{0:00.00}", countdown);

//        //wavesText.text = (waveIndex + 1) + "/" + waves.Length;

    }

    //IEnumerator SpawnWave()
    //{
    //    //Wave wave = waves[waveIndex];
    //    //for (int y = 0; y < wave1Enemies.Length; y++)
    //    //{
    //    //    EnemyBlueprint eb = wave1Enemies[y];
    //    //    for (int a = 0; a < wave.waveCount; a++)
    //    //    {
    //    //        yield return new WaitForSeconds(1f / wave.waveRate);

    //    //        for (int i = 0; i < eb.enemyCount; i++)
    //    //        {
    //    //            SpawnEnemy(eb.enemy);
    //    //            yield return new WaitForSeconds(1f / eb.enemyRate);
    //    //        }
    //    //    }
    //    //}
    //    //waveIndex++;
    //}

    void SpawnEnemy(Enemy enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

    int enemiesPerWave()
    {
        int rsp = (int)((0.15 * waveIndex) * (24 + 6 * (Difficulty - 1)));
        return rsp;
    }

    void raiseDifficulty()
    {
        if (waveIndex / Difficulty == 1)
        {
            Difficulty++;
        } else
        {
            return;
        }
    }
}
