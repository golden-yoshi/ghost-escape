using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void LoadTutorial()
    {
        Application.LoadLevel("TutorialMap");
    }

    public void LoadLevel1()
    {
        Application.LoadLevel("Level1");

    }

}
