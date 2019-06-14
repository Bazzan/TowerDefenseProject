using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] public float speed = 10f;
    [SerializeField] public float health = 100;
    [SerializeField] public int value = 50;

    [Header("VFX")]
    [SerializeField] public GameObject deathEffect;

    ObjectPool objectPool;

    private void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }


    public void DmgCastel()
    {
        PlayerStats.Lives--;

        objectPool.EnQueueInPool("Grunt", transform.gameObject);
    }

    public void EnemyTakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        gameObject.SetActive(false);
        objectPool.EnQueueInPool("Grunt", gameObject);
    }
}
