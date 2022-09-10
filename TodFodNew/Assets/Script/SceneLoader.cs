using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void NextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(CurrentSceneIndex + 1);

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start");
        FindObjectOfType<GameStatus>().ResetGame();
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
