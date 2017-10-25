using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
  public AudioSource playerDead;
  public AudioSource playerAttack1;
  public AudioSource playerAttack2;
  public AudioSource playerAttack3;
  public AudioSource playerAttack4;

  private static bool sfxmanExists;

  void Start() {
    if (!sfxmanExists) {
      sfxmanExists = true;
      DontDestroyOnLoad(transform.gameObject);
    } else {
      Destroy(gameObject);
    }
  }

}
