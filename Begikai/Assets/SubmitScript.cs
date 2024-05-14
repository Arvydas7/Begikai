using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitScript : MonoBehaviour
{
    public InputField nameInputField;
    public HighscoreTable highscoreTable; // Reference to the HighscoreTable script

    private int savedScore;

    //public void SubmitScore(int score)
    //{
    //    string jsonString = PlayerPrefs.GetString("highscoreTable");
    //    highscoreTable.Highscores highscores = JsonUtility.FromJson<highscoreTable.Highscores>(jsonString);
    //    highscoreTable.highscoreEntryList = highscoreTable.highscores.highscoreEntryList;

    //    for (int i = 0; i < highscoreTable.highscores.highscoreEntryList.Count; i++)
    //    {
    //        for (int j = i + 1; j < highscoreTable.highscores.highscoreEntryList.Count; j++)
    //        {
    //            if (highscoreTable.highscores.highscoreEntryList[j].score > highscoreTable.highscores.highscoreEntryList[i].score)
    //            {
    //                highscoreTable.HighscoreEntry tmp = highscoreTable.highscores.highscoreEntryList[i];
    //                highscoreTable.highscores.highscoreEntryList[i] = highscoreTable.highscores.highscoreEntryList[j];
    //                highscoreTable.highscores.highscoreEntryList[j] = tmp;
    //            }
    //        }
    //    }
    //    if (highscoreTable.IsHighscore(score))
    //    {
    //        gameObject.SetActive(true);
    //        savedScore = score;
    //    }
    //}

    public void SubmitScore(int score)
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        HighscoreTable.Highscores highscores = JsonUtility.FromJson<HighscoreTable.Highscores>(jsonString);

        List<HighscoreTable.HighscoreEntry> highscoreEntryList = highscores.highscoreEntryList;

        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    HighscoreTable.HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }
        bool isHighscore = false;

        if (highscoreEntryList.Count < 10 || score > highscoreEntryList[highscoreEntryList.Count - 1].score)
        {
            isHighscore = true;
        }

        if (isHighscore)
        {
            // Score qualifies to be in the high score list
            gameObject.SetActive(true);
            savedScore = score;
        }
    }


    public void SubmitScore1()
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        HighscoreTable.Highscores highscores = JsonUtility.FromJson<HighscoreTable.Highscores>(jsonString);

        List<HighscoreTable.HighscoreEntry> highscoreEntryList = highscores.highscoreEntryList;

        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    HighscoreTable.HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }

        string playerName = nameInputField.text;
        highscoreTable.AddHighscoreEntry(savedScore, playerName);
        UpdateUI();
    }


    private void UpdateUI()
    {
        gameObject.SetActive(false);
        //highscoreTable.Awake();
        //highscoreTable.UpdateHighscoreUI();
    }
}

