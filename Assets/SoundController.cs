using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    private AudioSource audio;

    public float pitch = 1f;

    private void Awake() {
        // audio.pitch = pitch;
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        audio = GetComponent<AudioSource>();
    }

    public void ExecuteSound(AudioClip sound) {
        audio.PlayOneShot(sound);
    }

    // make isPlaying to check if audio source is playing
    public bool isPlaying() {
        return audio.isPlaying;
    }

}
