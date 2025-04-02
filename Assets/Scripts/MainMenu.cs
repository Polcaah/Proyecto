using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton; // Botón para cambiar de escena
    public Button exitButton; // Botón para salir del juego
    public string sceneName; // Nombre de la escena a la que quieres cambiar

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
