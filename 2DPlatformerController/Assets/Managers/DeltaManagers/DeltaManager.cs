using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaManager: IDeltaManager
{
    public Vector2 GetDelta(Vector2 vect)
    {
        return vect * Time.deltaTime;
    }
}