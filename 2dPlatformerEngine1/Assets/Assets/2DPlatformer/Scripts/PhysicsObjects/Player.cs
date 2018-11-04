using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhysicsObject {

    public float maxSpeed = 7;
    public float JumpSpeed = 7;


    protected override void ComputeVelocity()
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

        targetVelocity = move * maxSpeed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
