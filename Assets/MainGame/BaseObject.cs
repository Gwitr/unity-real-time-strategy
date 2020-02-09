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
            select_changed = true;
        }
    }

    public float cost = 0.0f;
    public int size_x = 1;
    public int size_y = 1;
    public float hp = 0.0f;

    private bool select_changed = false;
    private bool selected_private = false;

    // Start is called before the first frame update
    void Start() {
        GetComponent<MeshRenderer>().enabled = false;
        transform.Find("Selector").localScale = new Vector3(size_x + 0.2f, size_y + 0.2f, 0.0f);
    }

    // Update is called once per frame
    void Update() {
        if (select_changed) {
            if (selected_private) {
                gameObject.transform.Find("Selector").gameObject.GetComponent<MeshRenderer>().enabled = true;
            } else {
                gameObject.transform.Find("Selector").gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            select_changed = false;
        }

        if (Input.GetKeyDown(KeyCode.Delete)) {
            if (selected_private) {
                GameObject.Find("Player").GetComponent<Player>().money += cost;
                Destroy(this.gameObject);
            }
        }
    }
}