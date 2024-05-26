using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public GameOverScript GameOverScript;
    public SubmitScript Submit;
    int savedScore;
    [SerializeField] public TextMeshProUGUI scoreUI;

    private bool isGameOver = false;

    private void OnGUI()
    {
        scoreUI.text = betterScore();
    }

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public float currentScore = 0f;

    public bool isPlaying = true;

    private void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;

        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            GameOverScript.Setup(betterScore());
            savedScore = betterScore1();
            
            currentScore = 0;
            Submit.SubmitScore(savedScore);
            isPlaying = false;
            isGameOver = true;
            //Submit.SubmitScore(savedScore);
        }
    }

    public string betterScore()
    {
        return "Score:" + Mathf.RoundToInt(currentScore).ToString();
    }

    public int betterScore1()
    {
        return  Mathf.RoundToInt(currentScore);
    }
}
















//public class GameManager : MonoBehaviour
//{
//    public GameOverScript GameOverScript;
//    [SerializeField] public TextMeshProUGUI scoreUI;

//    public enum PlayerState
//    {
//        Alive,
//        Dead
//    }

//    private bool isGameOver = false;

//    public PlayerState player1State = PlayerState.Alive;
//    public PlayerState player2State = PlayerState.Alive;

//    private void OnGUI()
//    {
//        scoreUI.text = betterScore();
//    }

//    public static GameManager Instance;

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//    }

//    public float currentScore = 0f;

//    public bool isPlaying = true;

//    private void Update()
//    {
//        if (isPlaying)
//        {
//            currentScore += Time.deltaTime;
//            UnityEngine.Debug.Log("" + currentScore);


//            Check if any player is dead
//            if (player1State == PlayerState.Dead || player2State == PlayerState.Dead)
//            {
//                GameOver();
//            }
//        }
//    }

//    private void Update()
//    {
//        if (isPlaying && (player1State == PlayerState.Alive || player2State == PlayerState.Alive))
//        {
//            currentScore += Time.deltaTime;
//            Debug.Log("" + currentScore);

//            // Check if any player is dead
//            if (player1State == PlayerState.Dead || player2State == PlayerState.Dead)
//            {
//                GameOver();
//            }
//        }
//    }


//    public void PlayerDied(int playerNumber)
//    {
//        if (playerNumber == 1)
//        {
//            player1State = PlayerState.Dead;
//        }
//        else if (playerNumber == 2)
//        {
//            player2State = PlayerState.Dead;
//        }
//    }

//    public void GameOver()
//    {
//        if (!isGameOver)
//        {
//            GameOverScript.Setup(betterScore());
//            currentScore = 0;
//            isPlaying = false;
//            isGameOver = true;
//        }
//    }

//    public string betterScore()
//    {
//        return "Score:" + Mathf.RoundToInt(currentScore).ToString();
//    }
//}
