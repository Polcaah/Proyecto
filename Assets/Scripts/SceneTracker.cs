using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    void Awake()
    {
        // Asegúrate de que no haya duplicados
        if (FindObjectsOfType<SceneTracker>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Solo actualiza si no venimos del primer arranque
        if (SceneMemory.previousSceneName != scene.name)
        {
            SceneMemory.previousSceneName = SceneManager.GetActiveScene().name;
        }
    }
}
