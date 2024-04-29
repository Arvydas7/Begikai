using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreUI;

    private void OnGUI(){
        scoreUI.text = betterScore();
    }

    public static GameManager Instance;

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }
    }

    public float currentScore = 0f;

    public bool isPlaying = true;

    private void Update(){
        if(isPlaying){
            currentScore += Time.deltaTime;
            Debug.Log("" + currentScore);
        }
    }
    
    public void GameOver(){
        currentScore = 0;
        isPlaying = false;
    }

    public string betterScore (){
        return "Score:" + Mathf.RoundToInt(currentScore).ToString();
    }
}
