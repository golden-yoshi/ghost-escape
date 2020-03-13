using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public float score;
    public Text timeText, keyText;

    private Player playerScript;
    private GameObject playerObj;

    //Not a good fix...
    public GameObject exit;

    // Start is called before the first frame update
    void Start() {
        playerObj = GameObject.FindWithTag("Player");
        playerScript = playerObj.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        score = score + Time.deltaTime;
        timeText.text = "Time: " + score.ToString();

        keyText.text = "Keys collected: " + playerScript.getCollectedKeys().ToString() + "/3";
        if(playerScript.getCollectedKeys() == 3){
            exit.SetActive(true);
        }

        if(SceneManager.GetActiveScene().name != "TutorialMap"){
            playerScript.tutorial = false;
        }

    }

    /*
    public void openLevel1() {
        Application.LoadLevel("TutorialMap");
    }

    public void openLevel2() {
        Application.LoadLevel("Level1");
    }

    public void openLevel3() {
        //Application.LoadLevel("Level3");
    }

    public void openLevel4()
    {

    }


    public void openLevel5()
    {

    }

    public void exitGame () {
        Application.Quit();
    }

    */

}
