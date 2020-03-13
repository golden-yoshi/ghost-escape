using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpage : MonoBehaviour
{


    public void next()
    {
        Application.LoadLevel("TutorialMap");
    }

    public void LoadLevel1()
    {
        Application.LoadLevel("Level1");

    }

    public void next2()
    {
        Application.LoadLevel("Level2");

    }
    public void next3()
    {
        Application.LoadLevel("Level3");
    }

    public void next4()
    {
        Application.LoadLevel("Level4");
    }
    public void next5()
    {
     Application.LoadLevel("Level5");
    }
    public void levelSelect()
    { 
    Application.LoadLevel("levelSelect");
    }
    public void replay()
    { 
    Application.LoadLevel("TutorialMap");
    }
    public void replay1()
    {
        Application.LoadLevel("Level1");
    }
    public void replay2()
    {
        Application.LoadLevel("Level2");
    }
    public void replay3()
    {
        Application.LoadLevel("Level3");
    }
    public void replay4()
    {
        Application.LoadLevel("Level4");
    }
    public void replay5()
    {
        Application.LoadLevel("Level5");
    }
}

