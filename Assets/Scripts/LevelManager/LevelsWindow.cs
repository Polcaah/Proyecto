using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsWindow : MonoBehaviour
{
    public Button level_1; 
    public Button level_2;
    public Button level_3;
    public Button level_4;
    public Button level_5;
    public Button level_6;
    public Button level_7;
    public Button level_8;
    public Button mainMenu;

    void Start()
    {
        if (level_1 != null)
            level_1.onClick.AddListener( () => ChangeScene(level_1.name));
        if (level_2 != null)
            level_2.onClick.AddListener(() => ChangeScene(level_2.name));
        if (level_3 != null)
            level_3.onClick.AddListener(() => ChangeScene(level_3.name));
        if (level_4 != null)
            level_4.onClick.AddListener(() => ChangeScene(level_4.name));
        if (level_5 != null)
            level_5.onClick.AddListener(() => ChangeScene(level_5.name));
        if (level_6 != null)
            level_6.onClick.AddListener(() => ChangeScene(level_6.name));
        if (level_7 != null)
            level_7.onClick.AddListener(() => ChangeScene(level_7.name));
        if (level_8 != null)
            level_8.onClick.AddListener(() => ChangeScene(level_8.name));
        if (mainMenu != null)
            mainMenu.onClick.AddListener(() => ChangeScene(mainMenu.name));
    }

    void ChangeScene(string changedScene)
    {
        SceneManager.LoadScene(changedScene);
    }
}
