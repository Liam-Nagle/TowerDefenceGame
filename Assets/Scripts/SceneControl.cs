using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UnloadAll()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            SceneManager.UnloadSceneAsync(i);
        }
    }

    public void LoadScene(string sceneName)
    {
        var _currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneName);
        SceneManager.UnloadSceneAsync(_currentScene);
    }
}
