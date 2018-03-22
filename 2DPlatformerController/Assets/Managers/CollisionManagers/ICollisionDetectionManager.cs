using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionDetectionManager
{
    void Detect(Rigidbody2D rigidBody, Vector2 moveVector, Vector2 velocity, float shellRadius, bool yMovement, bool detectComponentsOnSameTeam);
}