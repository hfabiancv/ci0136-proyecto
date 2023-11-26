using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    [SerializeField] private AnimatedDoor[] doors;
    [SerializeField] private WaveSpawner waveSpawner;
    // Start is called before the first frame update
    void Start()
    {
        waveSpawner.OnBattleOver += WaveSpawner_OnBattleOver;
        waveSpawner.OnBattleStarted += WaveSpawner_OnBattleStarted;
    }

    private void WaveSpawner_OnBattleStarted(object sender, System.EventArgs e)
    {
        // Close all doors
        foreach (AnimatedDoor door in doors)
        {
            door.Close();
        }
    }

    private void WaveSpawner_OnBattleOver(object sender, System.EventArgs e)
    {
        // Open all doors
        foreach (AnimatedDoor door in doors)
        {
            door.Open();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
