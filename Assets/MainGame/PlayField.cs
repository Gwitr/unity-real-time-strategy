using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayField : MonoBehaviour
{
    public float rows;
    public float columns;

    private List<EmptyBehaviour> objects;

    void Start() {
        Application.targetFrameRate = 60;
    }

    public void Register(EmptyBehaviour behaviour)
    {
        if (objects is null)
            objects = new List<EmptyBehaviour>();
        objects.Add(behaviour);
    }

    public void Unregister(EmptyBehaviour behaviour)
    {
        objects.Remove(behaviour);
    }

    void Update() {
        foreach (var child in objects) {
            child.GameTick();
        }
    }
}
