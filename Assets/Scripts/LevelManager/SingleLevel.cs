using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{
    private int currentLevel = 0;
    public int levelIndex;
    public void AddLevelsCompleted(int lvlCompleted)
    {
        currentLevel = lvlCompleted;
        if (currentLevel > 0)
        {
            PlayerPrefs.SetInt("Lv"+levelIndex, currentLevel);
        }
        Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, currentLevel));
    }
}
