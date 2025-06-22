using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsWindow : MonoBehaviour
{
    [SerializeField] private List<Button> levelButtons;
    [SerializeField] private Button mainMenu;

    void Start()
    {
        foreach (Button btn in levelButtons)
        {
            if (btn != null)
            {
                string sceneName = btn.name; 
                btn.onClick.AddListener(() => ChangeScene(sceneName));
            }
        }

        if (mainMenu != null)
            mainMenu.onClick.AddListener(() => ChangeScene(mainMenu.name));
    }

    void ChangeScene(string changedScene)
    {
        SceneManager.LoadScene(changedScene);
    }
}
