using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

    float gravityModifier = 1f;
    protected Vector2 Velocity
    {
        get;
        set;
    }
    protected Rigidbody2D rb2d
    {
        get;
        set;
    }

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        Vector2 deltaPosition = Velocity * Time.deltaTime;
        Vector2 move = Vector2.up * deltaPosition.y;
        Movement(move);
    }

    void Movement(Vector2 move)
    {
        rb2d.position += move;
    }
}
