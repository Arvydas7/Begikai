//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HighscoreTable : MonoBehaviour
//{
//    private Transform entryContainer;
//    private Transform entryTemplate;

//    private void Awake()
//    {
//        entryContainer = transform.Find("highscoreEntryContainer");
//        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

//        entryTemplate.gameObject.SetActive(false);

//        float templateHeight = 30f;
//        for(int i = 0; i<10;i++)
//        {
//            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
//            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
//            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
//            entryTransform.gameObject.SetActive(true);
//        }
//    }
//}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Net.Mime.MediaTypeNames;

public class HighscoreTable : MonoBehaviour
{
    [SerializeField] private InputField nameInputField;
    //[SerializeField] private GameOverScript gameOverScript;


    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    //private int savedScore;

    public void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        if (entryContainer == null)
        {
            UnityEngine.Debug.LogError("Highscore entry container not found!");
            return;
        }

        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        if (entryTemplate == null)
        {
            UnityEngine.Debug.LogError("Highscore entry template not found!");
            return;
        }

        entryTemplate.gameObject.SetActive(false);

        //SetupHighscoreTable();

        //AddHighscoreEntry(45, "NWW");
        //AddHighscoreEntry(57, "NAW");
        //AddHighscoreEntry(84, "NQW");

        //highscoreEntryList = new List<HighscoreEntry>()
        //{
        //    new HighscoreEntry{score = 98, name = "ABC"},
        //    new HighscoreEntry{score = 78, name = "SBC"},
        //    new HighscoreEntry{score = 92, name = "KKC"},
        //    new HighscoreEntry{score = 12, name = "MMM"},
        //    new HighscoreEntry{score = 75, name = "ABA"},
        //    new HighscoreEntry{score = 36, name = "ABB"},
        //    new HighscoreEntry{score = 87, name = "ACS"},
        //    new HighscoreEntry{score = 56, name = "JON"},

        //};

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        highscoreEntryList = highscores.highscoreEntryList;

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }


        highscoreEntryTransformList = new List<Transform>();
        //foreach(HighscoreEntry highscoreEntry in highscoreEntryList)
        for (int i = 0; i < Mathf.Min(highscoreEntryList.Count, 10); i++)
        {
            CreateHighscoreEntryTransform(highscoreEntryList[i], entryContainer, highscoreEntryTransformList);
        }



    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 80f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank.ToString(); break;

            case 1: rankString = "1"; break;
            case 2: rankString = "2"; break;
            case 3: rankString = "3"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;

        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);


    }

    public void SetupHighscoreTable()
    {
        // Retrieve the highscore entries from PlayerPrefs
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Sort the highscore entries by score
        highscores.highscoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));

        // Limit the number of highscore entries (if desired)
        int maxEntries = 10;
        if (highscores.highscoreEntryList.Count > maxEntries)
        {
            highscores.highscoreEntryList = highscores.highscoreEntryList.GetRange(0, maxEntries);
        }

        // Update the UI to display the highscore entries
        //UpdateHighscoreUI(highscores);

        // Save the updated highscore entries back to PlayerPrefs
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    public void AddHighscoreEntry(int score, string name)
    {
        Awake();
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

        SetupHighscoreTable();
    }

    [System.Serializable]
    public class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    public class HighscoreEntry
    {
        public int score;
        public string name;
    }



    //public void SubmitScore(int score)
    //{
    //    //int score = CalculateScore();
    //    EnsureHighscoreListInitialized();

    //    if (IsHighscore(score))
    //    {
    //        gameObject.SetActive(true);
    //        savedScore = score;
    //        //string playerName = nameInputField.text;
    //        //AddHighscoreEntry(score, playerName);
    //        //UpdateUI();
    //    }
    //}

    //public void SubmitScore1()
    //{
    //    //int score = CalculateScore();
    //    EnsureHighscoreListInitialized();



    //        //gameObject.SetActive(true);
    //        string playerName = nameInputField.text;
    //        AddHighscoreEntry(savedScore, playerName);
    //        UpdateUI();

    //}

    //// Method to calculate the score using GameOverScript logic
    //private int CalculateScore()
    //{
    //    string scoreString = gameOverScript.pointsText.text;
    //    int score;
    //    if (int.TryParse(scoreString, out score))
    //    {
    //        return score;
    //    }
    //    else
    //    {
    //        UnityEngine.Debug.LogError("Failed to parse score from text: " + scoreString);
    //        return 0;
    //    }
    //}

    //// Method to check if the score is in the top 10
    public bool IsHighscore(int score)
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        highscoreEntryList = highscores.highscoreEntryList;

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        //EnsureHighscoreListInitialized();
        return highscores.highscoreEntryList.Count < 10 || score > highscores.highscoreEntryList[highscoreEntryList.Count - 1].score;
    }

    //// Method to update the UI after submitting the score
    //private void UpdateUI()
    //{
    //    gameObject.SetActive(false);
    //    // Refresh UI to reflect changes in the highscores table
    //    // For example, you might want to call CreateHighscoreEntryTransform again
    //}

    //private void EnsureHighscoreListInitialized()
    //{
    //    if (highscoreEntryList == null)
    //    {
    //        string jsonString = PlayerPrefs.GetString("highscoreTable");
    //        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
    //        highscoreEntryList = highscores.highscoreEntryList ?? new List<HighscoreEntry>();
    //    }
    //}


}


