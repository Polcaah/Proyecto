using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton; 
    public Button exitButton; 
    public string sceneName; 

    void Start()
    {
        if (startButton != null)
            startButton.onClick.AddListener(ChangeScene);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
