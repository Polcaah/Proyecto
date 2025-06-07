using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    [SerializeField] GameObject finishCollision;
    [SerializeField] GameObject finishMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finishMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelsWindow");
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
