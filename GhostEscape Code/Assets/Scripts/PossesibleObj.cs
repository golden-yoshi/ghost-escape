using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossesibleObj : MonoBehaviour
{

    private Player player;
    private GameObject playerObj;
    
    SpriteRenderer spriteRenderer;
    private Collider2D collider;

    public bool possessable;

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
                ReleasePiano();
            }
            if(player.animator.GetCurrentAnimatorStateInfo(0).IsName("doll-possessed")){
                ReleaseDoll();
            }
        }
    }

    public void Possess(){
        player.myAudioSource.PlayOneShot(player.possessSound);
        if (player.inRangeEnemy == false){
            
            if(this.CompareTag("piano")){
                player.animator.SetTrigger ("PossessDistractor");
                player.transform.position = GameObject.Find(player.objName).transform.position;
            }

            if(this.CompareTag("doll")){
                player.animator.SetTrigger ("PossessHider");
                player.transform.position = GameObject.Find(player.objName).transform.position;
            }
            // Player is in 'Physical mode':
            player.ghostMode = false;
            possessable = false;
            player.isObject = true;

            // Possessed enemy is 'inactive':
            spriteRenderer.enabled = false;
            collider.enabled = false;
            this.collider.enabled = false;

            //Tutorial complete:
            player.tutorial = false;
            player.tutorialGuide.SetActive(false);
        }
    }

    public void ReleasePiano(){
        player.animator.SetTrigger ("PossessDistractor");
        player.ghostMode = true;
        player.isObject = false;

        GameObject.Find(player.objName).transform.position = player.transform.position;

        spriteRenderer.color = new Color(1f, 1f, 1f);
        spriteRenderer.enabled = true;
        collider.enabled = true;
    }

    public void ReleaseDoll(){
        player.myAudioSource.PlayOneShot(player.possessSound);
        player.animator.SetTrigger ("PossessHider");
        player.ghostMode = true;
        player.isObject = false;

        GameObject.Find(player.objName).transform.position = player.transform.position;

        spriteRenderer.color = new Color(1f, 1f, 1f);
        spriteRenderer.enabled = true;
        collider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            player = other.gameObject.GetComponent<Player>();
            if(player.getCurrentMode() == true){
                possessable = true;
                if(this.CompareTag("piano")){
                    spriteRenderer.color = new Color(173f/255f, 1f, 166f/255f);
                } else if(this.CompareTag("doll")){
                    spriteRenderer.color = new Color(173f/255f, 1f, 166f/255f);
                }
                player.objName = this.name;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player") {
            player = other.gameObject.GetComponent<Player>();
            if(player.getCurrentMode() == true){
                possessable = false;
                spriteRenderer.color = new Color(1f, 1f, 1f);
                player.tutorialGuide.SetActive(false);
            }
        }
    }
}
