﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
  public static bool mcExists;
  public AudioSource[] musicTracks;
  public int currentTrack;
  public bool musicCanPlay;

  void Start() {
    if (!mcExists) {
      mcExists = true;
      DontDestroyOnLoad(transform.gameObject);
    } else {
      Destroy(gameObject);
    }
  }

  void Update() {
    if (musicCanPlay) {
      if (!musicTracks[currentTrack].isPlaying) {
        musicTracks[currentTrack].Play();
      }
    }
  }

  public void SwitchTrack(int newTrack) {
    musicTracks[currentTrack].Stop();
    currentTrack = newTrack;
    musicTracks[currentTrack].Play();
  }
}
