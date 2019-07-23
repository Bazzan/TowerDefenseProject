using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            EventManager.MoveCubeEvent(true);
            Debug.Log("InputManager -> eventFire M");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            EventManager.MoveCubeEvent(false);
            Debug.Log("InputManager -> eventFire N");
        }
    }
}
