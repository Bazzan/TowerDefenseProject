using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    private Transform target;

    [Header("General")]
    [SerializeField] private float range = 15f;


    [Header("Use Bullets (default)")]
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private GameObject bulletPrefab;
    private float fireCountdown = 0f;

    [Header("Use Laser")] //brackeys linerenderer i snakevideo
    [SerializeField] private bool useLaser = false;
    [SerializeField] private LineRenderer lineRenderer;

    [Header("Setup fields")]
    [SerializeField] private bool hasRotatingPart = false;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private Transform partToRotate;

    [SerializeField] private string enemyTag = "Enemy";
 
    [SerializeField] private Transform firePoint;

    void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        { 
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if( nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

	void Update () {
		if(target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }
            return;
        }

        if (hasRotatingPart)
        {
            LockOnTarget();
        }
        

        if (useLaser)
        {
            Laser();
        }else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }



        fireCountdown -= Time.deltaTime;

	}

    void LockOnTarget()
    {
        // Target Lock on bby PEWPEW
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 roation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, roation.y, 0f);
    }

    void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void Shoot()
    {
        Debug.Log("PEWPEW");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }


    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
