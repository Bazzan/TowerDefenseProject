using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] private Text currentWaveText;



    private void OnEnable()
    {
        currentWaveText.text = PlayerStats.CurrentWave.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void GoToMenu()
    {
        Debug.Log("go To menu");
    }

}
