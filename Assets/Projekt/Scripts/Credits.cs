using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// An Main Camera angefügt
public class Credits : MonoBehaviour
{
  public string levelToLoad;
  public string buttonText;

  //Einfügen der Optionen für die Positionierung der Buttons
  public float guiPlacementY1;
  public float guiPlacementX1;

  //Einfügen der Optionen für die Größe der Buttons

  public float guiPlacementButtonSizeY1;
  public float guiPlacementButtonSizeX1;

  private void OnGUI() {
    //Anzeige der Buttons

    //"Spiel Starten" Button
    if (GUI.Button(new Rect(Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * guiPlacementButtonSizeX1, Screen.height * guiPlacementButtonSizeY1), buttonText)) {
      SceneManager.LoadScene(levelToLoad);
    }
  }
}
