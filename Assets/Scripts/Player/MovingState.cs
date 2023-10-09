using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : PlayerState
{
    public MovingState(PlayerMovement playerMovement) : base(playerMovement) { }

    public override void Enter()
    {
    }

    public override void Update()
    {
        float x = playerMovement.x;
        float y = playerMovement.y;

        // Move the character
        playerMovement.MoveCharacter(x, y);

        if (x == 0 && y == 0)
        {
            // Transition to IdleState
            playerMovement.ChangeState(new IdleState(playerMovement));
        }
    }

    public override void Exit()
    {
    }
}
