using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : Tower
{
    [SerializeField] private GameObject bombPrefab;


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
                if(FireCountdown <= 0)
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

}
