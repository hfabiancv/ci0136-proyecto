using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerMovement playerMovement;

    public PlayerState(PlayerMovement playerMovement)
    {
        // get the player movement script
        this.playerMovement = playerMovement;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
