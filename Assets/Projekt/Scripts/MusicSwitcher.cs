using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
  private MusicController musicManager;
  public int newTrack;
  public bool switchOnStart;

  void Start() {
    musicManager = FindObjectOfType<MusicController>();

    if (switchOnStart) {
      musicManager.SwitchTrack(newTrack);
      gameObject.SetActive(false);
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (PlayerController.PLAYER_NAME.Equals(other.gameObject.name)) {
      musicManager = FindObjectOfType<MusicController>();
      gameObject.SetActive(false);
    }
  }
}
