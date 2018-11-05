using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhysicsObject {

    #region Properties
    public float maxSpeed = 7;
    public float JumpSpeed = 7;
    SpriteRenderer TheSpriteRenderer
    {
        get;
        set;
    }
    #endregion

    private void Awake()
    {
        TheSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void ExecutePerFrame()
    {
        ExecuteJumpLogic();
        ExecuteFlipSpriteLogic();
    }

    #region Helper Methods
    void ExecuteJumpLogic()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && ThePhysicsObjectStatus.isGrounded)
        {
            Velocity.y = JumpSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            Velocity.y = Velocity.y > 0 ? Velocity.y * .5f : Velocity.y;
        }
    }

    void ExecuteFlipSpriteLogic()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        if (move.x < 0f)
        {

            TheSpriteRenderer.flipX = true;
        }
        if (move.x > .0f)
        {

            TheSpriteRenderer.flipX = false;
        }

        targetVelocity = move * maxSpeed;
    }
    #endregion
    // Update is called once per frame

}
