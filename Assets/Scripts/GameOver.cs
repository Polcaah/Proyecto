using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button mainMenu;
    public string sceneName;
    void Start()
    {
        if (mainMenu != null)
        {
            mainMenu.onClick.AddListener(ChangeScene);
        }
           
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
