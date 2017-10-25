using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{

  private MusicController theMC;
  public int newTrack;
  public bool switchOnStart;

  void Start() {
    theMC = FindObjectOfType<MusicController>();

    if (switchOnStart == true) {
      theMC.SwitchTrack(newTrack);
      gameObject.SetActive(false);
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.name == "Paladin") {
      theMC = FindObjectOfType<MusicController>();
      gameObject.SetActive(false);
    }
  }
}
