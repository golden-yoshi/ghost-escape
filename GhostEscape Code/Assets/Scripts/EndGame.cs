using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    
    private Player playerScript;
    private GameObject playerObj;
    private Collider2D collider;
    
    // Start is called before the first frame update
    void Start() {
        collider = GetComponent<Collider2D>();

        playerObj = GameObject.FindWithTag("Player");
        playerScript = playerObj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            playerScript = other.gameObject.GetComponent<Player>();
            Application.LoadLevel("Level1");
        }
    }
}
