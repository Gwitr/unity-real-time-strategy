using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBehaviour : MonoBehaviour
{
    public delegate void DeleteKeyDown();

    public static List<DeleteKeyDown> deleteKeyDownCallbacks;

    void Awake() {
        if (deleteKeyDownCallbacks is null) 
        {
            deleteKeyDownCallbacks = new List<DeleteKeyDown>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            foreach (var callback in deleteKeyDownCallbacks) 
                callback();
        }
    }
}
