using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : Tower
{
    [SerializeField] private GameObject bombPrefab;


    [Header("Part To Rotate")]
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private Transform partToRotate;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    private void Update()
    {
        if(Target == null)
        {
            InvokeRepeating("UpdateTarget", 0, 0.5f);
        }
        else
        {
            if (InRange())
            {
                CancelInvoke();
                LockOnTarget();
                if (FireCountdown <= 0)
                {
                    Shoot();
                    FireCountdown = FireRate;
                }
            }
            else
            {
                Target = null;
            }
        }
        FireCountdown -= Time.deltaTime;
    }





    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bombPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(Target);
        }


    }


    private void LockOnTarget()
    {
        Vector3 dirToPlayer = (partToRotate.transform.position -Target.transform.position ).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dirToPlayer.x, 0f, dirToPlayer.z));
        partToRotate.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

    }

}
