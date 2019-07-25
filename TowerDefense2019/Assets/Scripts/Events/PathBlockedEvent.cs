using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBlockedEvent : MonoBehaviour
{

    public delegate void PathIsBlockedDelegate();    //define the method signature
    public static event PathIsBlockedDelegate onPathIsBlockedEvent; //Define the event

    public static void PathIsBlockedEvent()
    {
        if (onPathIsBlockedEvent != null)
        {
            onPathIsBlockedEvent();
        }
    }



}
