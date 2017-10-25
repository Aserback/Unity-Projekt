using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    private DialogueManager dialogueManager;
    public string[] dialogueLines;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Paladin" && Input.GetKeyUp(KeyCode.E))
        {
            if (!dialogueManager.dialogueActive)
            {
                dialogueManager.dialogueLines = dialogueLines;
                dialogueManager.currentLine = 0;
                dialogueManager.ShowDialogue();
            }
        }
    }
}
