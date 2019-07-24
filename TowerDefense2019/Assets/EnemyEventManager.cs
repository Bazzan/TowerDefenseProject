using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventManager : MonoBehaviour
{
    public delegate void EnemyEventDelegate(GameObject enemy);    //define the method signature
    public static EnemyEventDelegate onEnemyEvent; //Define the event
    
    public static void EnemyDmgCastelEvent(GameObject enemy)
    {
        if(onEnemyEvent != null)
        {
            onEnemyEvent(enemy);
        }
    }

}
