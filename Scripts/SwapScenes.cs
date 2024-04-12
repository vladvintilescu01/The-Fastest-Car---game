using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    void Update()
    {   
        if (SceneManager.GetActiveScene().name == "SampleScene" ||
            SceneManager.GetActiveScene().name == "SampleScene2")
            // pause the current music when we are in the race and change music
            DoNotDestroy.instance.GetComponent<AudioSource>().Pause();
      
        if (SceneManager.GetActiveScene().name == "Winner" || 
            SceneManager.GetActiveScene().name == "Loser" ||
            SceneManager.GetActiveScene().name == "Winner_Yellow" ||
            SceneManager.GetActiveScene().name == "Loser_Yellow")
            // play again when we are back to main menu
            DoNotDestroy.instance.GetComponent<AudioSource>().Play();
    }
}