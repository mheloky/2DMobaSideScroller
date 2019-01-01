using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThreadSyncronizer : MonoBehaviour
{
    public List<Action> Actions = new List<Action>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Actions.Count > 0)
        {
            lock (Actions)
            {
                for (int i = 0; i < Actions.Count; i++)
                {
                    Actions[i]();
                }
                Actions.Clear();
            }
        }
    }
}
