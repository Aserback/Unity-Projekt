using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
  public GameObject dialogueBox;
  public Text dialogueText;
  public bool dialogueActive;

  public string[] dialogueLines;
  public int currentLine;

  void Update() {
    if (dialogueActive && Input.GetKeyDown(KeyCode.E)) {
      currentLine++;
      dialogueText.text = dialogueLines[currentLine];
    }

    if (currentLine >= dialogueLines.Length) {
      dialogueBox.SetActive(false);
      dialogueActive = false;
      currentLine = 0;
    }

  }

  public void ShowBox(string dialogue) {
    dialogueActive = true;
    dialogueBox.SetActive(true);
    dialogueText.text = dialogue;
  }

  public void ShowDialogue() {
    dialogueActive = true;
    dialogueBox.SetActive(true);
  }
}
