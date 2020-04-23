using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{

    public static List<GameObject> EnemiesAlive;


    //[SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private Text waveCountdownTimer;

    private int waveIndex = 0;
    private float countDown = 2f;
    private bool isSpawning = false; 

    private void Awake()
    {
        EnemiesAlive = new List<GameObject>();
    }


    void Update ()
    {
		if(countDown <= 0 && !isSpawning)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;

        }
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:0.0}", countDown) + " To next wave";
	}

    IEnumerator SpawnWave ()
    {
        isSpawning = true;
        Debug.Log("New wave inc");

        waveIndex++;
        PlayerStats.CurrentWave++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        isSpawning = false;

    }

    void SpawnEnemy()
    {
       GameObject enemy = ObjectPool.Instance.SpawnFromPool("Grunt", spawnPoint.position, spawnPoint.rotation);
       EnemyAttributes enemyAttributes= enemy.GetComponent<EnemyAttributes>();
        enemyAttributes.health = enemyAttributes.initHealth;
    }
}
