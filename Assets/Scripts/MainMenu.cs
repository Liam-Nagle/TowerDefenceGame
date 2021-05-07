using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public void selectButton(string scene)
    {
        //Needs to reference the object that called the selectButton method.
        //GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
        StartCoroutine(ClickDelay());
        _sceneControl.LoadScene(scene);
    }

    IEnumerator ClickDelay()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
