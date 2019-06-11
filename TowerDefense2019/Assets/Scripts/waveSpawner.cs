using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class waveSpawner : MonoBehaviour {

    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private Text waveCountdownTimer;

    private int waveIndex = 0;
    private float countDown = 2f;

	void Update ()
    {
		if(countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;

        }
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:00.00}", countDown);
	}

    IEnumerator SpawnWave ()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("New wave inc");
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
