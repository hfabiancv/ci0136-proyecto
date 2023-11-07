using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(PlayerMovement playerMovement) : base(playerMovement) { }

    public override void Enter()
    {

    }

    public override void Update()
    {
        // Get player input
        float x = playerMovement.x;
        float y = playerMovement.y;
        // Move the character
        if (x != 0 || y != 0)
        {
            // Transition to MovingState
            playerMovement.ChangeState(new MovingState(playerMovement));
        }
    }

    public override void Exit()
    {
    }
}


