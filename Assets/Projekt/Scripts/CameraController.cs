using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

  public GameObject followTarget; // Zur Übergabe eines GameObjects z.B der Spieler
  private Vector3 targetPosition; // Vector3 zur Übergabe der x,y,z Koordinaten
  public float moveSpeed;
  private static bool cameraExists;

  // Überprüfung ob eine Kamera schon existiert beim übernehmen in andere Szenen und wenn ja wird die neue gelöscht
  void Start() {
    DontDestroyOnLoad(transform.gameObject);

    if (!cameraExists) {
      cameraExists = true;
      DontDestroyOnLoad(transform.gameObject);
    } else {
      Destroy(gameObject);
    }
  }

  void Update() {
    // Übergabe der neuen Position der Kamera bzw. dass sie dem angegebenen Objekt folgt. 
    targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
    // Kleine Verzögerung eingebaut damit die Kamera beim folgen organischer wirkt
    transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
  }
}