using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected Transform Target;
    protected bool RepeatingUpdateTarget = false;
    protected EnemyAttributes enemyAttributes;

    [Header("General")]
    [SerializeField] protected float Range = 15f;


    [Header("Use Bullets (default)")]
    [SerializeField] protected float FireRate = 1f;
    protected float FireCountdown = 0f;

    //[Header("Use Laser")] //brackeys linerenderer i snakevideo
    //[SerializeField] private bool useLaser = false;
    //[SerializeField] private LineRenderer lineRenderer;

    //[Header("Setup fields")]
    //[SerializeField] protected bool hasRotatingPart = false;
    //[SerializeField] protected float turnSpeed = 10f;
    //[SerializeField] protected Transform partToRotate;

    [SerializeField] protected string EnemyTag = "Enemy";

    [SerializeField] protected Transform FirePoint;

    private WaveSpawner waveSpawner;

    //   void Start ()
    //   {
    //       InvokeRepeating("UpdateTarget", 0f, 0.5f);
    //}

    private void Awake()
    {
        waveSpawner = GetComponent<WaveSpawner>();
    }

    protected void UpdateTarget()
    {
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);


        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in WaveSpawner.EnemiesAlive)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= Range)
        {
            Target = nearestEnemy.transform;
            enemyAttributes = Target.GetComponent<EnemyAttributes>();
        }
        //else
        //{
        //    target = null;
        //}

    }

    protected bool InRange()
    {
        if (Target == null)
        {
            return false;
        }

        Vector3 dist = Target.position - transform.position;
        float distSqr = dist.sqrMagnitude;

        return distSqr < Range * Range;


    }


    //void Update () {
    //	if(target == null)
    //       {
    //           if (useLaser)
    //           {
    //               if (lineRenderer.enabled)
    //               {
    //                   lineRenderer.enabled = false;
    //               }
    //           }
    //           return;
    //       }

    //       if (hasRotatingPart) for tower with rotating parts
    //       {
    //           LockOnTarget();
    //       }


    //       if (useLaser)
    //       {
    //           Laser();
    //       }else
    //       {
    //           if (fireCountdown <= 0f)
    //           {
    //               Shoot();
    //               fireCountdown = 1f / fireRate;
    //           }
    //       }



    //       fireCountdown -= Time.deltaTime;

    //}

    //protected void LockOnTarget()
    //{
    //    // Target Lock on bby PEWPEW
    //    Vector3 direction = target.position - transform.position;
    //    Quaternion lookRotation = Quaternion.LookRotation(direction);
    //    Vector3 roation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
    //    partToRotate.rotation = Quaternion.Euler(0f, roation.y, 0f);
    //}






    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
