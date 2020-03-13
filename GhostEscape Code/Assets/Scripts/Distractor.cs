using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractor : MonoBehaviour
{

    private Player player;
    private GameObject playerObj;
    
    SpriteRenderer spriteRenderer;
    private Collider2D collider;

    bool possessable;

    // Start is called before the first frame update
    void Start() {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer> ();

        playerObj = GameObject.FindWithTag("Player");
        player = playerObj.GetComponent<Player>();
    }

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.P)) {
            if(possessable == true){
                Possess();
            } 
            if(player.animator.GetCurrentAnimatorStateInfo(0).IsName("piano-possessed")){
                Release();
            }
        }
    }

    public void Possess(){
        player.animator.SetTrigger ("PossessDistractor");
        // Player is in 'Physical mode':
        player.ghostMode = false;
        possessable = false;
        player.isObject = true;

        // Possessed enemy is 'inactive':
        player.transform.position = GameObject.Find("piano").transform.position;
        spriteRenderer.enabled = false;
        collider.enabled = false;
        this.collider.enabled = false;

        //Tutorial complete:
        player.tutorial = false;
        player.tutorialGuide.SetActive(false);
    }

    public void Release(){
        player.animator.SetTrigger ("PossessDistractor");
        player.ghostMode = true;
        player.isObject = false;

        spriteRenderer.color = new Color(1f, 1f, 1f);
        spriteRenderer.enabled = true;
        collider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            player = other.gameObject.GetComponent<Player>();
            if(player.getCurrentMode() == true){
                possessable = true;
                spriteRenderer.color = new Color(173f/255f, 1f, 166f/255f);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player") {
            player = other.gameObject.GetComponent<Player>();
            if(player.getCurrentMode() == true){
                possessable = false;
                spriteRenderer.color = new Color(1f, 1f, 1f);
                //player.tutorialGuide.SetActive(false);
            }
        }
    }
}
