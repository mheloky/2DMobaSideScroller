using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Physics;
public class PhysicsObject : MonoBehaviour {

    #region Properties
    public Vector2 Velocity;
  
    protected Rigidbody2D rigidbody2D
    {
        get;
        set;
    }
    public GravityManager gravityManager
    {
        get;
        set;
    }
    
    #endregion


    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravityManager = new GravityManager(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
       
        gravityManager.ApplyGravityWithCollision(this, rigidbody2D);
   
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

}
