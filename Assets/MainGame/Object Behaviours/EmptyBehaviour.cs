using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBehaviour : MonoBehaviour
{
    protected Player player;
    protected PlayField playField;

    void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();
        playField = GameObject.Find("PlayField").GetComponent<PlayField>();
        playField.Register(this);
        Init();
    }

    public virtual void GameTick() { 
        
    }

    public virtual void Init() {

    }
}
