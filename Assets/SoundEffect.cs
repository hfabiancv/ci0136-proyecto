using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip stepAudio;
    
    private void Start() {
        SoundController.instance.ExecuteSound(stepAudio);
        //stepAudio = GetComponent<AudioSource>();
    }
}
