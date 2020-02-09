using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    void Start() {
        
    }

    void Update() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f)) {
            transform.position = new Vector3(
                Mathf.Floor((hit.point.x + 0.5f) / 1.0f) * 1.0f, 
                0.01f, 
                Mathf.Floor((hit.point.z + 0.5f) / 1.0f) * 1.0f
            );

            if (Input.GetMouseButtonDown(0)) {
                GameObject hit_go = hit.transform.gameObject;
                BaseObject x = hit_go.GetComponent<BaseObject>();
                while (x is null) {
                    if (hit_go.transform.parent is null) {
                        break;
                    }
                    hit_go = hit_go.transform.parent.gameObject;
                    x = hit_go.GetComponent<BaseObject>();
                }
                if (x is object) {
                    x.selected = !x.selected;
                }
            }
        }
    }
}