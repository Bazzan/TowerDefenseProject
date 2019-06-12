using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTower : Tower
{

    [SerializeField] private LineRenderer lineRenderer;


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
            }
            else
            {
                Target = null;
            }
        }

        



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
