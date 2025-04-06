using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsWindow : MonoBehaviour
{
    public Button level_1; 
    public Button level_2; 
    public string sceneName_1;
    public string sceneName_2;
    void Start()
    {
        if (level_1 != null)
            level_1.onClick.AddListener( () => ChangeScene(sceneName_1));

        if (level_2 != null)
            level_2.onClick.AddListener( () => ChangeScene(sceneName_2));
    }

    void ChangeScene(string changedScene)
    {
        SceneManager.LoadScene(changedScene);
    }
}
