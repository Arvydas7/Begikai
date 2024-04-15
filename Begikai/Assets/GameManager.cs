using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }
    }

    public float currentScore = 0f;

    public bool isPlaying = false;

    private void Update(){
        if(isPlaying){
            currentScore += Time.deltaTime;
            Debug.Log("" + currentScore);
        }
    }

    public void GameOver(){
        currentScore = 0;
    }

    public string betterScore (){
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
