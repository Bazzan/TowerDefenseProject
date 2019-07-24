using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AoETower : MonoBehaviour
{
    bool gizmoStart;
    [SerializeField] LayerMask layerMask;


    [SerializeField] private float damageOverTime;
    


    private EnemyAttributes enemyAttributes;
    Collider[] hitColliders;

    private void Start()
    {
        gizmoStart = true;
    }

    private void FixedUpdate()
    {
        boxCollision();

        if(hitColliders.Length != 0)
        {
            damageEnemyCollider();
        }
    }
    private void damageEnemyCollider()
    {
        foreach (Collider collider in hitColliders)
        {
            DmgEnemy(collider.GetComponent<EnemyAttributes>());
            //collider.GetComponent<EnemyAttributes>().EnemyTakeDamage(damageOverTime * Time.deltaTime);
        }
    }

    private void boxCollision()
    {
        hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * 7.5f, Quaternion.identity, layerMask);
        Debug.Log(hitColliders.Length);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (gizmoStart)
        {
            Gizmos.DrawWireCube(transform.position, transform.localScale * 15);
        }
    }




    private void DmgEnemy(EnemyAttributes enemyAttributes)
    {

        enemyAttributes.EnemyTakeDamage(damageOverTime * Time.deltaTime);
    }

}
