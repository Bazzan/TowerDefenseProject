using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : Tower
{
    [SerializeField] private GameObject bombPrefab; // projectile prefab

    [Header("Part To Rotate")]// variables that is used to rotate top part of tower
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private Transform partToRotate;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
        RepeatingUpdateTarget = true;

    }

    private void Update()
    {
        if(Target == null && !RepeatingUpdateTarget)
        {
            InvokeRepeating("UpdateTarget", 0, 0.5f);
            RepeatingUpdateTarget = true;
        }
        else
        {

            if (InRange())
            {
                CancelInvoke();
                RepeatingUpdateTarget = false;

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
        Vector3 dirToTarget = (partToRotate.transform.position -Target.transform.position ).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dirToTarget.x, 0f, dirToTarget.z));
        partToRotate.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

    }

}
