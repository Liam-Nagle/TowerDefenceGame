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
    private GameState _gameState;
    private UI _UI;
    public static int EnemiesAlive;

    public Text wavesText;

    private void Start()
    {
        waveIndex = 1;
        _gameState = GetComponent<GameState>();
        _UI = GetComponent<UI>();
    }
        private void Update()
    {
        timer += Time.deltaTime;

        if (EnemiesAlive > 0)
        {
            return;
        } else if(spawn)
        {
            _gameState.wave = waveIndex;
            enemies.Clear();
            spawn = false;
            enemies.Add(new EnemyBlueprint(Enemy1, enemiesPerWave(), 1, 1));
            enemies.Add(new EnemyBlueprint(Enemy2, enemiesPerWave(), 1, 1));
            StartCoroutine(SpawnWave());
            raiseDifficulty();
            waveIndex++;
            _UI.UpdateWave();
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

    //IEnumerator SpawnWave2(List<Wave> waves)
    //{
    //    for(int i = 0; i < waveIndex; i++)
    //    {
    //        waves[];
    //    }
    //}

    IEnumerator SpawnWave()
    {
        for (int y = 0; y < enemies.Count; y++)
        {
            yield return new WaitUntil(() => canSpawn(enemies[y].GetSpawnTime()));
            for (int i = 0; i < enemies[y].GetCount(); i++)
            {
                SpawnEnemy(enemies[y].GetEnemy());
                yield return new WaitForSeconds(1f / enemies[y].GetRate());
            }

        }
        timer = 0.0f;
        spawn = true;
    }

    //Checks all enemies are dead before advancing to the next wave
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

    //Creates a clone of that enemies prefab, increments enemies alive count
    void SpawnEnemy(Enemy enemy)
    {
        Instantiate(enemy, spawnPoint);
        EnemiesAlive++;
    }

    //Future formula to determine enemies per wave, design to be procedural but not currently in use
    int enemiesPerWave()
    {
        int rsp = (int)((0.15 * waveIndex) * (24 + 6 * (Difficulty - 1)));
        return rsp;
    }

    //Increase difficulty as wave increases, not in use
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
