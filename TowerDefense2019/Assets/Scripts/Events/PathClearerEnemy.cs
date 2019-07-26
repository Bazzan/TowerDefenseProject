using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PathClearerEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject tower;
    private float distance;
    private Collider[] towerColliders;
    [SerializeField] private LayerMask towerMask;
    PathIsBlockedListener pathIsBlockedListener;
    //private LineRenderer linerend;
    public Vector3 warpTo;

    private Vector3 colliderOffset = new Vector3(0, -2.6f , 0);

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        tower = BuildManager.LatestTowerBuilt;
        //linerend = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        agent.Warp(warpTo);
        pathIsBlockedListener = GetComponent<PathIsBlockedListener>();

    }

    private void Update()
    {
        //linerend.positionCount = agent.path.corners.Length;
        //linerend.SetPositions(agent.path.corners);
        //linerend.enabled = true;
        
        if (tower != null)
        {

            agent.SetDestination(tower.transform.position);
            Debug.Log(agent.path.status);

            distance = Vector3.Distance(tower.transform.position, gameObject.transform.position);
            if (distance < 5f)
            {
                DestroyTowers();

            }
        }
        else
        {
            tower = BuildManager.LatestTowerBuilt;

        }

    }


    private void DestroyTowers()
    {
        //towerColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * 2.5f, Quaternion.identity, towerMask);
        towerColliders = Physics.OverlapSphere(gameObject.transform.position + colliderOffset, 2.5f, towerMask);

        Debug.Log(towerColliders.Length);
        foreach (Collider towerCollider in towerColliders)
        {
            Destroy(towerCollider.gameObject);
        }
        Time.timeScale = 1;

        Destroy(gameObject);
        PathIsBlockedListener.PathClearerIsFired = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f);

    }


}
