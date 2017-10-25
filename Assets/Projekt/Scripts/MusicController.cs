using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static bool mcExists;

    public AudioSource[] musicTracks;
    public int currentTrack;
    public bool musicCanPlay;

    void Start()
    {
        if (mcExists)
        {
            Destroy(gameObject);
        }
        else
        {
            mcExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (musicCanPlay)
        {
            if (!musicTracks[currentTrack].isPlaying)
                musicTracks[currentTrack].Play();
        }
        else
            musicTracks[currentTrack].Stop();
    }

    public void SwitchTrack(int newTrack)
    {
        musicTracks[currentTrack].Stop();
        currentTrack = newTrack;
        musicTracks[currentTrack].Play();
    }

}
