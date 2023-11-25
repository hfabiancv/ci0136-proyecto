using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    private AudioSource audio;

    private void Awake() {
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
}
