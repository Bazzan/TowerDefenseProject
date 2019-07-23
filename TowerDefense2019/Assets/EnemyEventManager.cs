using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventManager : MonoBehaviour
{
    public delegate void EnemyEventDelegate(bool dir);    //define the method signature
    public static EnemyEventDelegate onEnemyEvent; //Define the event
    


}
