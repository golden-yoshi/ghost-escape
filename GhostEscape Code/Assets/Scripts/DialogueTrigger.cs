using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public GameObject panel;
	public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		panel.SetActive(true);
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

}
