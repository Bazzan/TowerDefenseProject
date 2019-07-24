using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPath : MonoBehaviour {

    private GameObject enemy;

    private void OnEnable()
    {
        EnemyEventManager.onEnemyEvent += DmgCastel;
    }
    private void OnDisable()
    {
        EnemyEventManager.onEnemyEvent -= DmgCastel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("endPath + fireEvent");
            enemy = other.gameObject;
            EnemyEventManager.EnemyDmgCastelEvent(enemy);
        }
    }

    private void DmgCastel(GameObject enemy)
    {
        PlayerStats.Lives--;

        ObjectPool.Instance.EnQueueInPool("Grunt", enemy);
    }
}
