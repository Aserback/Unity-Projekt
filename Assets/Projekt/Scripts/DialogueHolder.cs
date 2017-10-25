using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
  private DialogueManager dialogueManager;
  public string[] dialogueLines;

  void Start() {
    dialogueManager = FindObjectOfType<DialogueManager>();
  }

  void OnTriggerStay2D(Collider2D other) {
    if (PlayerController.PLAYER_NAME.Equals(other.gameObject.name) && Input.GetKeyUp(KeyCode.E)) {
      if (!dialogueManager.dialogueActive) {
        dialogueManager.dialogueLines = dialogueLines;
        dialogueManager.currentLine = 0;
        dialogueManager.ShowDialogue();
      }
    }
  }
}
