using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
  public string levelToLoad;
  public string exitpoint;
  private PlayerController paladin;

  void Start() {
    // search the paladin object in the whole project and save it to this variable
    paladin = FindObjectOfType<PlayerController>();
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (PlayerController.PLAYER_NAME.Equals(other.gameObject.name)) {
      SceneManager.LoadScene(levelToLoad);
      paladin.startPoint = exitpoint;
    }
  }
}