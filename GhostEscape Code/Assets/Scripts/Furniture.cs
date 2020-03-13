using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    private Player playerScript;
    private GameObject playerObj;
    
    SpriteRenderer spriteRenderer;
    private Collider2D collider;

    bool possessable;

    // Start is called before the first frame update
    void Start() {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer> ();

        playerObj = GameObject.FindWithTag("Player");
        playerScript = playerObj.GetComponent<Player>();

        possessable = false;
    }

    // Update is called once per frame
    void Update() {
        DetectPlayer();
    }

    public void DetectPlayer(){
        if(playerScript.getCurrentMode() == false){
            if(!playerScript.isObject){
                collider.enabled = true;
            }
        } else {
            collider.enabled = false;
        }
    }

}
