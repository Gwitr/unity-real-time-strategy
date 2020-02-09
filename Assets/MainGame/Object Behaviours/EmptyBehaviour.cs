using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void GameTick() { 
    
    }

    public virtual void Init() {

    }
}
