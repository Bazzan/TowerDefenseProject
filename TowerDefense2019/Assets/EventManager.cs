using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void GameManagerDelegate(bool dir);    //define the method signature
    public static event GameManagerDelegate onGameManagerEvent; //Define the event

    public static void MoveCubeEvent(bool dir)
    {
        if(onGameManagerEvent != null)
        {
            onGameManagerEvent(dir);
        }
    }

}
