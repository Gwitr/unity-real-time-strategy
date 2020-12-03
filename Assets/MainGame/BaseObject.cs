using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    public bool selected {
        get {
            return selected_private;
        }
        set {
            selected_private = value;
            OnSelectChanged();
        }
    }

    public float cost = 0.0f;
    public int sizeX = 1;
    public int sizeY = 1;
    public float hp = 0.0f;

    private bool selected_private = false;

    // Start is called before the first frame update
    void Start() {
        GetComponent<MeshRenderer>().enabled = false;
        transform.Find("Selector").localScale = new Vector3(sizeX + 0.2f, sizeY + 0.2f, 0.0f);
        GlobalBehaviour.deleteKeyDownCallbacks.Add(OnDeleteKeyPressed);
    }

    void Update() {
        
    }

    private void OnDestroy()
    {
        GlobalBehaviour.deleteKeyDownCallbacks.Remove(OnDeleteKeyPressed);
    }

    private void OnDeleteKeyPressed() 
    {
        if (selected_private)
        {
            GameObject.Find("Player").GetComponent<Player>().money += cost;
            Destroy(this.gameObject);
        }
    }

    private void OnSelectChanged() {
        if (selected_private)
        {
            gameObject.transform.Find("Selector").gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            gameObject.transform.Find("Selector").gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}