using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameSolo()
    {
        SceneManager.LoadSceneAsync("Solo Play");
    }

    public void PlayGameDuo()
    {
        SceneManager.LoadSceneAsync("Duo Play");
    }
}
