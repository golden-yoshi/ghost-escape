using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private string sceneName;
    void ChangeScene()
    {
        SceneManager.LoadScene("levelSelect");

        sceneName = SceneManager.GetActiveScene().name;
    }

    public void LoadLevelSelect()
    {
        Application.LoadLevel("levelSelect");

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
