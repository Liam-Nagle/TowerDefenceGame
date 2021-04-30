using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private SceneControl _sceneControl;

    void Start()
    {
        _sceneControl = GameObject.Find("SceneControl").GetComponent<SceneControl>();
    }

    void Update()
    {
        
    }

    public void selectButton(int id)
    {
        if (id == 1)
        {
            _sceneControl.LoadScene("Level1");
        }
        else if (id == 2)
        {
            _sceneControl.LoadScene("OptionsMenu");
        }
        else if (id == 3)
        {
            _sceneControl.LoadScene("Exit");
        }
    }
}
