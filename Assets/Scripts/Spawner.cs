using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class Spawner : MonoBehaviour
{

    List<Wave> waves = new List<Wave>();
    public Transform spawnPoint;
    public Enemy Enemy1;
    public Enemy Enemy2;

    private List<EnemyBlueprint> enemies = new List<EnemyBlueprint>();
    private int waveIndex = 0;
    private int Difficulty = 1;
    private float timer = 0.0f;
    private bool spawn = true;
    public static int EnemiesAlive;

    public Text wavesText;

    private void Start()
    {
        //Adds 1 Enemy to enemies list
        waveIndex = 1;
        //Start defines wave 1 then update defines more waves? or again from a file SOMEHOW
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (EnemiesAlive > 0)
        {
            return;
        } else if(spawn)
        {
            Debug.Log(waveIndex);
            enemies.Clear();
            spawn = false;
            enemies.Add(new EnemyBlueprint(Enemy1, enemiesPerWave(), 10, 1));
            enemies.Add(new EnemyBlueprint(Enemy2, enemiesPerWave(), 10, 1));
            StartCoroutine(SpawnWave());
            raiseDifficulty();
            waveIndex++;
        }

        //        if (countdown <= 0f)
        //        {
        //
        //            countdown = timeBetweenWaves;
        //            return;
        //        }

        //        countdown -= Time.deltaTime;

        //        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //        waveCountdownText.text = string.Format("{0:00.00}", countdown);

        //        //wavesText.text = (waveIndex + 1) + "/" + waves.Length;

    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Spawning Wave");
        for (int y = 0; y < enemies.Count; y++)
        {
            Debug.Log("Spawning Enemy");
            yield return new WaitUntil(() => canSpawn(enemies[y].GetSpawnTime()));
            Debug.Log("Spawn Time");
            for (int i = 0; i < enemies[y].GetCount(); i++)
            {
                Debug.Log(timer);
                SpawnEnemy(enemies[y].GetEnemy());
                yield return new WaitForSeconds(1f / enemies[y].GetRate());
            }

        }
        timer = 0.0f;
        spawn = true;
    }

    void nextWave()
    {
        if(EnemiesAlive <= 0)
        {
            waveIndex++;
        }
    }

    private bool canSpawn(float spawnTime)
    {
        if(spawnTime <= timer)
        {
            return true;
        } else
        {
            return false;
        }
    }

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
