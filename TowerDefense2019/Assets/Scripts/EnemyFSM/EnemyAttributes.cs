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

    private void Awake()
    {
        objectPool = ObjectPool.Instance;
    }


    public void DmgCastel()
    {
        PlayerStats.Lives--;

        ObjectPool.Instance.EnQueueInPool("Grunt", gameObject);
        //Debug.Log("DMGCastel.cs ");
        //objectPool.EnQueueInPool("Grunt", gameObject);
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
        ObjectPool.Instance.EnQueueInPool("Grunt", gameObject);

        gameObject.SetActive(false);
    }
}
