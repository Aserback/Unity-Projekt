using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttoncontroller : MonoBehaviour {

    public string buttontext;
    public string levelToLoad;

    //Einfügen der Optionen für die Positionierung der Buttons
    public float guiPlacementY1;
    public float guiPlacementX1;
    
    public float guiPlacementButtonSizeY1;
    public float guiPlacementButtonSizeX1;

    private void OnGUI()
    {
        //Anzeige der Buttons

        //"Spiel Starten" Button
        if (GUI.Button(new Rect(Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * guiPlacementButtonSizeX1, Screen.height * guiPlacementButtonSizeY1), buttontext))
        {
            Application.LoadLevel(levelToLoad);

        }

    }
}
