using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator> ();
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnTriggerEnter2D(Collider2D other){
    //     if (other.name == "Player") { 
    //         animator.enabled = true;
    //     }
    // }

    // void OnTriggerExit2D(Collider2D target){
	// 	if (other.name == "Player") { 
    //         // open door animation
    //     }
	// }
}
