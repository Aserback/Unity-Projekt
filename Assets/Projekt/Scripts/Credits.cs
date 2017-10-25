using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// An Main Camera angefügt
public class Credits : MonoBehaviour
{
    public string levelToLoad;
    public string buttonText;

    public float guiPlacementY1;
    public float guiPlacementX1;
    
    public float guiPlacementButtonSizeY1;
    public float guiPlacementButtonSizeX1;

    private void OnGUI()
    {
        //"Spiel Starten" Button
        if (GUI.Button(new Rect(Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * guiPlacementButtonSizeX1, Screen.height * guiPlacementButtonSizeY1), buttonText))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

}
