using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    public Image unlockImage;

    private void Update()
    {
        UpdateLevelImage();
    }

    private void UpdateLevelImage()
    {
        if (!unlocked)
        {
            unlockImage.gameObject.SetActive(true);
        }
        else
        {
            unlockImage.gameObject.SetActive(false);
        }
    }
    public void PressSelection(string levelName)
    {
        if (unlocked)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
