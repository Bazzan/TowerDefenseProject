using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : Tower
{
    [SerializeField] private GameObject bulletPrefab;

    //private Queue<GameObject> arrowQueue;


    //private void Awake()
    //{
    //    arrowQueue = new Queue<GameObject>();
    //    for (int i = 0; i < 3; i++)
    //    {
    //        GameObject bulletGO = Instantiate(bulletPrefab, transform);
    //        arrowQueue.Enqueue(bulletGO);
    //    }

    //}
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
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(Target);
        }
        if(Target.GetComponent<EnemyAttributes>().health <= 0)
        {
            Target = null;
        }


    }
}
