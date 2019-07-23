using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCube : MonoBehaviour
{

    private void OnEnable()
    {
        EventManager.onGameManagerEvent += MoveUp;
    }

    private void OnDisable()
    {
        EventManager.onGameManagerEvent -= MoveUp;
    }

    private void MoveUp(bool dir)
    {
        if (dir == true)
            transform.position += transform.up;
        else
            transform.position -= transform.up;
    }
}
