using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{

    private Grunt grunt;

    [Header("Attributes")]

    private float MaxSpeed;
    [SerializeField] public float health = 100;
    [SerializeField] public int value = 50;


    [Header("VFX")]
    [SerializeField] public GameObject deathEffect;

    ObjectPool objectPool;

    



    private void Awake()
    {
        objectPool = ObjectPool.Instance;
        grunt = GetComponent<Grunt>();
        MaxSpeed = grunt.Agent.speed;
    }


    #region slowMovement
    public void SlowMovment(float slowPercent)
    {
        grunt.Agent.speed = MaxSpeed * (slowPercent);
    }
    public void SetStartSpeed()
    {
        grunt.Agent.speed = MaxSpeed;
    }
    #endregion


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

    //public void DmgCastel()
    //{
    //    PlayerStats.Lives--;

    //    ObjectPool.Instance.EnQueueInPool("Grunt", gameObject);
    //Debug.Log("DMGCastel.cs ");
    //objectPool.EnQueueInPool("Grunt", gameObject);
    //}
}
