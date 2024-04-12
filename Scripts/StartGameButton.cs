using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public int gameStartScene;
    
    public void StartGame()
    {   //play game 
        SceneManager.LoadScene(gameStartScene);
    }
}