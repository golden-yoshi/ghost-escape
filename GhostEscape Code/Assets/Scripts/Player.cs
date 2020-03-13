using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    public float speed;
    public Vector2 playerPosition, playerDirection;
    
    public Animator animator;
    private GameControl gameControl;

    private SpriteRenderer spriteRenderer;
    private Sprite ghostSprite, possessionSprite;

    public bool ghostMode;
    public bool isObject;

    // public float health = 10;
    public int collectedKeys = 0;

    public bool tutorial;
    public GameObject tutorialGuide;

    public bool moveTutorial;
    public GameObject moveGuide;

    public Enemy enemy;
    public string enemyName;

    public GameObject currMoveObj = null;

    // Start is called before the first frame update
    void Start() {
		animator = GetComponent<Animator> ();
        spriteRenderer = GetComponent<SpriteRenderer> ();
        gameControl = gameObject.GetComponent<GameControl>();
        
        ghostSprite = Resources.Load<Sprite>("ghost-sprite-sheet_0");
        possessionSprite = Resources.Load<Sprite>("enemy_0");

        playerPosition = this.transform.position;
        //spriteRenderer.sprite = ghostSprite;

        ghostMode = true;
        isObject = false;


        tutorial = true;
        moveTutorial = true;

        //

    }

    // Update is called once per frame
    void Update() {

        // Disable movement if possessing large object e.g. Piano
        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("piano-possessed")) {
            GetInput();
            Move();
        }

        // drag object
        if (currMoveObj && Input.GetKey(KeyCode.O))
        {
            currMoveObj.transform.parent = transform;
            speed = 2;
            moveTutorial = false;
            moveGuide.SetActive(false);
        }
        else //if (currMoveObj && Input.GetKeyUp(KeyCode.E))
        {
            //currMoveObj.transform.parent = null;
            //currMoveObj.transform.DetachChildren();
            transform.DetachChildren();
            speed = 3;
        }

    }

    public void Move() {
        transform.Translate(playerDirection*speed*Time.deltaTime);
    }

    private void GetInput() {
        playerDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            playerDirection += Vector2.up;
            animator.SetTrigger ("TurnBack");
		} 
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            playerDirection += Vector2.left;
            animator.SetTrigger ("TurnLeft");
		} 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            playerDirection += Vector2.right;
            animator.SetTrigger ("TurnRight");
		} 
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            playerDirection += Vector2.down;
            animator.SetTrigger ("TurnFront");
		} 

    }

    public void Possess() {

        if (Input.GetKeyDown(KeyCode.P)) {
            
            //if(ghostMode == true){  //If currently in ghost mode
            
                //If 'behind' enemy
                    //change ghost sprite to Enemy sprite with colour indicator
                    // animator.SetTrigger ("Possess");
                    //GetComponent<SpriteRenderer>().sprite = possessionSprite;
                    
                    //'disable' enemy instance - set sprite, rigid body, collider, etc to inactive e.g. rigidbody.setActive(false)
                    // set 'mode' to physical mode
                    // inherit abilities of physical mode e.g. physical object interaction
                    // disable ghost abilities e.g. moving through walls
            // }
            // if (ghostMode == false){ //If currently in physical mode
                if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("enemy-possessed-walk")) {
                    animator.SetTrigger ("Possess");
                    ghostMode = true;
                } 

                //change enemy sprite to ghost sprite
                //spawn instance of that enemy next to player
                // disable physical abilities
                // enable ghost abilities
            //}
        }   
    }

    public bool getCurrentMode(){
        return ghostMode;
    }

    public int getCollectedKeys(){
        return collectedKeys;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // Collect key when in 'Physical mode'
        if (collision.CompareTag("key")) {
            if(ghostMode == false){
                Destroy(collision.gameObject);
                collectedKeys += 1;
            }
        }
        // Activate tutorial on first encounter
        if (collision.CompareTag("Enemy")) {
            if(tutorial == true){
                tutorialGuide.SetActive(true);
                enemy = collision.gameObject.GetComponent<Enemy>();
                enemyName = enemy.gameObject.name;
                Debug.Log(enemyName);
            }
        }

        // Show if object is movable
        if (collision.CompareTag("movableObj"))
        {
            if (ghostMode == false)
            {
                if (moveTutorial == true) {
                    moveGuide.SetActive(true);
                }
                currMoveObj = collision.gameObject;
                currMoveObj.GetComponent<SpriteRenderer>().material.color = new Color(0, 1, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("movableObj"))
        {
            if (currMoveObj == collision.gameObject)
                currMoveObj.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1);
            currMoveObj = null;
        }
    }

    // Currently unused...
    // public void TakeDamage(float dmg) {
    //     health -= dmg;

    //     if (health <= 0) {    
    //       Die();
    //     }
    // }

    public void Die() {
        Application.LoadLevel(Application.loadedLevel);
    }

}
