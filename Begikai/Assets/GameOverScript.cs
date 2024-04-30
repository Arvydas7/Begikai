using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text pointsText;

    //Setup
    public void Setup(string score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Solo Play");
    }

    public void RestartDuoButton()
    {
        SceneManager.LoadScene("Duo Play");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
