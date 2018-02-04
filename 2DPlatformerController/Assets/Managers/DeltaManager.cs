using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaManager
{

    /// <summary>
    /// Multiplies Vector by a float to account for changes in framerates, thus smoothing out changes
    /// </summary>
    /// <param name="vect"></param>
    /// <returns></returns>
    public Vector2 GetDelta(Vector2 vect)
    {
        return vect * Time.deltaTime;
    }
}