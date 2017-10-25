using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcherCredits : MonoBehaviour
{
  public GameObject followTarget; // Zur Übergabe eines GameObjects z.B der Spieler
  private Vector3 targetPosition; // Vector3 zur Übergabe der x,y,z Koordinaten

  private MusicController musicController;
  public int newTrack;
  public bool switchOnStart;

  void Start() {
    targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
    musicController = FindObjectOfType<MusicController>();

    if (switchOnStart) {
      musicController.SwitchTrack(newTrack);
      gameObject.SetActive(false);
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (PlayerController.PLAYER_NAME.Equals(other.gameObject.name)) {
      musicController = FindObjectOfType<MusicController>();
      gameObject.SetActive(false);
    }
  }
}
