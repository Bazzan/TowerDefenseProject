using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPath : MonoBehaviour {



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("endPath");
            other.GetComponent<EnemyAttributes>().DmgCastel();
        }
    }
}
