using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{
    private int currentLevels = 0;
    public int levelIndex;
    public void AddLevelsCompleted(int lvlCompleted)
    {
        currentLevels = lvlCompleted;
        if (currentLevels > PlayerPrefs.GetInt("Lv"+ levelIndex))
        {
            PlayerPrefs.SetInt("Lv"+levelIndex, currentLevels);
        }
    }
}
