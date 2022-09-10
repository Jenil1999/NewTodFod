using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float GameSpeed = 1f;

    [SerializeField] int PointsOnDestroyBlock = 50;
    [SerializeField] int CurrentScore = 0;
    [SerializeField] TextMeshProUGUI ScoreBoard;

    private void Awake()
    {
        int gamestatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gamestatusCount > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        ScoreBoard.text = CurrentScore.ToString();
    }
    private void Update()
    {
        Time.timeScale = GameSpeed;
    }
    public void ScoreUpdate()
    {
        CurrentScore = CurrentScore + PointsOnDestroyBlock;
        ScoreBoard.text = CurrentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
