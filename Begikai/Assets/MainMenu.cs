using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGameSolo()
    {
        SceneManager.LoadSceneAsync("Solo Play");
    }

    public void PlayGameDuo()
    {
        SceneManager.LoadSceneAsync("Duo Play");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
