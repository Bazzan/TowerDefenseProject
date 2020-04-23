using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected Transform Target; //enemy target transform
    protected bool RepeatingUpdateTarget = false; //safty check for invokeRepeating
    protected EnemyAttributes enemyAttributes; //class where you can accesse health and other attributes from enemy target
    protected Collider[] enemiesInRange; //used to store enemies in range

    [Header("General")] //attribute for each type of tower to manipulate
    [SerializeField] protected float Range = 7.5f;
    [SerializeField] protected LayerMask layerMask;

    [Header("Use Bullets (default)")]
    [SerializeField] protected float FireRate = 1f;
    protected float FireCountdown = 0f;
    [SerializeField] protected Transform FirePoint;

    protected void UpdateTarget()
    {
        Debug.Log("updating targert");
        float shortestDistance = Mathf.Infinity;
        Collider nearestEnemy = null;

        enemiesInRange = Physics.OverlapSphere(transform.position, Range, layerMask);
        if (enemiesInRange.Length != 0)
        {
            foreach (Collider enemy in enemiesInRange)
            {
                //Vector3.Distance(transform.position, enemy.transform.position);


                float distanceToEnemy = SqredRange(transform.position, enemy.transform.position);


                Debug.Log(distanceToEnemy);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }


            }

            Target = nearestEnemy.transform;
            enemyAttributes = Target.GetComponent<EnemyAttributes>();


        }
        else
        {
            Debug.Log("list is empty");
        }
    }

    private float SqredRange(Vector3 pos1, Vector3 pos2)
    {
        return (pos1 - pos2).sqrMagnitude;
    }

    protected bool InRange()
    {
        if (Target == null)
        {
            return false;
        }

        Vector3 dist = Target.position - transform.position;


        return dist.sqrMagnitude < Range * Range;


    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}





//protected void LockOnTarget()
//{
//    // Target Lock on bby PEWPEW
//    Vector3 direction = target.position - transform.position;
//    Quaternion lookRotation = Quaternion.LookRotation(direction);
//    Vector3 roation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
//    partToRotate.rotation = Quaternion.Euler(0f, roation.y, 0f);
//}
