using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;
    public bool dialogueActive;

    public string[] dialogueLines;
    public int currentLine;
	
	void Update ()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            currentLine++;
        }

        if(currentLine >= dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogueActive = false;
            currentLine = 0;
        }

        dText.text = dialogueLines[currentLine];
	}

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);
    }

}
