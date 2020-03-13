using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Collider2D enemyRange;
    Vector2 enemyPosition;

    private Player player;
    private GameObject playerObj;

    bool possessable;

    private Patrol patrol;

    // Start is called before the first frame update
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        enemyRange = GetComponent<Collider2D> ();
        //enemyPosition = GetComponent<Transform> ();

        possessable = false;

        playerObj = GameObject.FindWithTag("Player");
        player = playerObj.GetComponent<Player>();

        patrol = GetComponent<Patrol> ();
    }

    // Update is called once per frame
    void Update() {
        
        if (Input.GetKeyDown(KeyCode.P)) {
            if(possessable == true){
                Possess();
            } 
            if(player.animator.GetCurrentAnimatorStateInfo(0).IsName("enemy-possessed-walk")){
                Release();
            }
        }
    }

    public void Possess(){
        player.animator.SetTrigger ("Possess");
        // Player is in 'Physical mode':
        player.ghostMode = false;
        possessable = false;

        // Possessed enemy is 'inactive':
        spriteRenderer.enabled = false;
        enemyRange.enabled = false;
        patrol.Speed = 0;
        player.transform.position = GameObject.Find(player.enemyName).transform.position;

        //Tutorial complete:
        player.tutorial = false;
        player.tutorialGuide.SetActive(false);
    }

    public void Release(){
        player.animator.SetTrigger ("Possess");
        player.ghostMode = true;

        //Change enemy position to players position
        GameObject.Find(player.enemyName).transform.position = player.transform.position;

        spriteRenderer.color = new Color(1f, 1f, 1f);
        spriteRenderer.enabled = true;
        enemyRange.enabled = true;
        StartCoroutine(StunDelay());
    }

    private IEnumerator StunDelay() {
        yield return new WaitForSeconds(3);
        patrol.Speed = 3;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            player = other.gameObject.GetComponent<Player>();
            if(player.getCurrentMode() == true){
                // Debug.Log("In range");
                possessable = true;
                spriteRenderer.color = new Color(173f/255f, 1f, 166f/255f);
                player.enemyName = this.name;
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
