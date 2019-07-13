using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTower : Tower
{

    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float damageOverTime = 30f;
    [SerializeField] private float slowPercent = 0.5f;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
        RepeatingUpdateTarget = true;
    }

    void Update()
    {



        if(Target == null && !RepeatingUpdateTarget)
        {
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
            InvokeRepeating("UpdateTarget", 0, 0.5f);
            RepeatingUpdateTarget = true;
        }
        else
        {
            if (InRange())
            {
                CancelInvoke();
                RepeatingUpdateTarget = false;
                Laser();

                DoDamage();
                SlowEnemy();

            }
            else
            {
                if(Target != null)
                {
                    enemyAttributes.SetStartSpeed();
                    Target = null;
                }
                
            }
        }

        



    }

    private void SlowEnemy()
    {
        enemyAttributes.SlowMovment(slowPercent);
    }

    private void DoDamage()
    {
        enemyAttributes.EnemyTakeDamage(damageOverTime * Time.deltaTime);
    }

    protected void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, FirePoint.position);
        lineRenderer.SetPosition(1, Target.position);
    }
}
