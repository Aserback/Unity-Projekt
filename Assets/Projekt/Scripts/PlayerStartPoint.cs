using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    // Zur Übergabe des Spielers und der Kamera an andere Szenen
    private PlayerController thePlayer;
    private CameraController theCamera;

    public string pointName;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;

            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
    }
}