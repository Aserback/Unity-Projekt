using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
  // Zur Übergabe des Spielers und der Kamera an andere Szenen
  private PlayerController player;
  private CameraController playerCamera;

  public string pointName;

  void Start() {
    player = FindObjectOfType<PlayerController>();

    if (pointName.Equals(player.startPoint)) {
      player.transform.position = transform.position;

      playerCamera = FindObjectOfType<CameraController>();
      playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y, playerCamera.transform.position.z);
    }
  }
}