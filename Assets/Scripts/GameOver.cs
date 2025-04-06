using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button retry;
    public Button mainMenu;
    public string sceneName;

    
    void Start()
    {
        if (retry != null)
            retry.onClick.AddListener(ReturnToPreviousScene);

        if (mainMenu != null)
            mainMenu.onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    void ReturnToPreviousScene()
    {
        if (!string.IsNullOrEmpty(SceneMemory.previousSceneName))
        {
            SceneManager.LoadScene(SceneMemory.previousSceneName);
        }
        else
        {
            Debug.Log("No hay escena anterior registrada.");
        }
    }
}
