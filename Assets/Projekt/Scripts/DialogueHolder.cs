using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    
    private DialogueManager dMan;

    public string[] dialogueLines;

	// Use this for initialization
	void Start ()
    {
        dMan = FindObjectOfType<DialogueManager>();
	}

    void OnTriggerStay2D(Collider2D other)
    {
            if (other.gameObject.name == "Paladin" && Input.GetKeyUp(KeyCode.E))
            {
                if (!dMan.dialogueActive)
                {
                    dMan.dialogueLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }
            }
    }
}
