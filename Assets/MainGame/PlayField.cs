using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayField : MonoBehaviour
{
    public float rows;
    public float columns;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        foreach (Transform child in GameObject.Find("Objects").transform) {
            child.gameObject.GetComponent<EmptyBehaviour>().GameTick();
        }
    }
}
