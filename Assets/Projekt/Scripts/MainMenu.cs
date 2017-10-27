using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
// An Main Camera angefügt
public class MainMenu : MonoBehaviour
{
  public string levelToLoad;

  //Einfügen der gewünschten Texturen
  public Texture backgroundTexture1;
  public Texture backgroundTexture2;

  //Einfügen der Optionen für die Positionierung der Überschrift

  public float guiPlacementTitleY1;
  public float guiPlacementTitleX1;

  //Einfügen der Optionen für die Größe der Überschrift

  public float guiPlacementTitleSizeY1;
  public float guiPlacementTitleSizeX1;

  //Einfügen der Optionen für die Positionierung der Buttons
  public float guiPlacementY1;
  public float guiPlacementY2;
  public float guiPlacementY3;

  public float guiPlacementX1;
  public float guiPlacementX2;
  public float guiPlacementX3;

  //Einfügen der Optionen für die Größe der Buttons

  public float guiPlacementButtonSizeY1;
  public float guiPlacementButtonSizeY2;
  public float guiPlacementButtonSizeY3;

  public float guiPlacementButtonSizeX1;
  public float guiPlacementButtonSizeX2;
  public float guiPlacementButtonSizeX3;

  public string startGameCommand;
  public string startGameText;
  public string controlsCommand;
  public string controlsText;
  public string creditsCommand;
  public string creditsText;

  private void OnGUI() {

    //Anzeigen des Hintergrunds
    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture1);
    GUI.DrawTexture(new Rect(Screen.width * guiPlacementTitleX1, Screen.height * guiPlacementTitleY1, Screen.width * guiPlacementTitleSizeX1, Screen.height * guiPlacementTitleSizeY1), backgroundTexture2);

    //Anzeige der Buttonsa

    //"Spiel Starten" Button
    if (GUI.Button(new Rect(Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * guiPlacementButtonSizeX1, Screen.height * guiPlacementButtonSizeY1), startGameText)) {
      SceneManager.LoadScene(startGameCommand);
    }

    //"Steuerung" Button
    if (GUI.Button(new Rect(Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * guiPlacementButtonSizeX2, Screen.height * guiPlacementButtonSizeY2), controlsText)) {
      SceneManager.LoadScene(controlsCommand);
    }

    //"Credit" Button
    if (GUI.Button(new Rect(Screen.width * guiPlacementX3, Screen.height * guiPlacementY3, Screen.width * guiPlacementButtonSizeX3, Screen.height * guiPlacementButtonSizeY3), creditsText)) {
      SceneManager.LoadScene(creditsCommand);
    }
  }
}
