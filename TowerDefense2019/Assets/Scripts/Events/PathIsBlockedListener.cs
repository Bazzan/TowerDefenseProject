using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathIsBlockedListener : MonoBehaviour
{
    [SerializeField] private GameObject pathClearerPrefab;
    [SerializeField] private Transform start;
    public static bool PathClearerIsFired = false;

    private void OnEnable()
    {

        PathBlockedEvent.onPathIsBlockedEvent += ClearPath;
    }

    private void OnDisable()
    {
        PathBlockedEvent.onPathIsBlockedEvent -= ClearPath;
    }



    private void ClearPath()
    {
        Time.timeScale = 0.1f;
        Instantiate(pathClearerPrefab, start.position, Quaternion.identity);
    }

    public void PathIsCleared()
    {
        Time.timeScale = 1;
    }


}
