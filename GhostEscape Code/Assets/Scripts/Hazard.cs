using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    private Player player;
    private Enemy enemy;
    // Start is called before the first frame update
    void Start() {
        //enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "Player") {
            player = other.gameObject.GetComponent<Player>();
            //Only kill player if in ghost mode
            if(player.getCurrentMode() == true){
                Destroy (other.gameObject);
                player.Die();
                // Create 'dying' effect
                //If in hazard for 3+ seconds
            }
            // if(player.getCurrentMode() == false){
            //     enemy.Release();
            // }
        }
    }

    void OnTriggerExit2D(Collider2D other){
       
    }
}
