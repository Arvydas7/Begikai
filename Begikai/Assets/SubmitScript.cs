using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitScript : MonoBehaviour
{
    public InputField nameInputField;
    public HighscoreTable highscoreTable; // Reference to the HighscoreTable script

    private int savedScore;

    public void SubmitScore(int score)
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");

        // Check if the jsonString is empty or null
        if (string.IsNullOrEmpty(jsonString))
        {
            jsonString = "{\"highscoreEntryList\":[]}";
        }

        HighscoreTable.Highscores highscores = JsonUtility.FromJson<HighscoreTable.Highscores>(jsonString);

        // Check if highscores is null
        if (highscores == null)
        {
            highscores = new HighscoreTable.Highscores();
            highscores.highscoreEntryList = new List<HighscoreTable.HighscoreEntry>();
        }

        List<HighscoreTable.HighscoreEntry> highscoreEntryList = highscores.highscoreEntryList;

        // Check if highscoreEntryList is null
        if (highscoreEntryList == null)
        {
            highscoreEntryList = new List<HighscoreTable.HighscoreEntry>();
        }

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

        if (string.IsNullOrEmpty(jsonString))
        {
            jsonString = "{\"highscoreEntryList\":[]}";
        }

        HighscoreTable.Highscores highscores = JsonUtility.FromJson<HighscoreTable.Highscores>(jsonString);

        if (highscores == null)
        {
            highscores = new HighscoreTable.Highscores();
            highscores.highscoreEntryList = new List<HighscoreTable.HighscoreEntry>();
        }

        List<HighscoreTable.HighscoreEntry> highscoreEntryList = highscores.highscoreEntryList;

        if (highscoreEntryList == null)
        {
            highscoreEntryList = new List<HighscoreTable.HighscoreEntry>();
        }

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
    }
}
