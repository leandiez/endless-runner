using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheSceneManager : MonoBehaviour
{
    SceneManager scenemanager;

    private void Start()
    {
        scenemanager = GetComponent<SceneManager>();
    }
    public void IrAlJuego()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}