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
                if ((hit_go.name == "Plane") || (hit_go.name == "Selector")) {
                    if (hit_go.name == "Selector") {
                        hit_go = GameObject.Find("Plane");
                    }
                    UnityEngine.Object pPrefab = Resources.Load(GameObject.Find("Player").GetComponent<Player>().object_chosen);
                    GameObject pNewObject = (GameObject)GameObject.Instantiate(pPrefab, transform.position, Quaternion.Euler(90.0f, 0.0f, 0.0f));
                    if (GameObject.Find("Player").GetComponent<Player>().money < pNewObject.GetComponent<BaseObject>().cost) {
                        Destroy(pNewObject);
                    } else {
                        pNewObject.transform.parent = GameObject.Find("Objects").transform;
                        GameObject.Find("Player").GetComponent<Player>().money -= pNewObject.GetComponent<BaseObject>().cost;
                    }
                } else {
                    BaseObject x = hit_go.GetComponent<BaseObject>();
                    while (x is null)
                    {
                        if (hit_go.transform.parent is null)
                        {
                            break;
                        }
                        hit_go = hit_go.transform.parent.gameObject;
                        x = hit_go.GetComponent<BaseObject>();
                    }
                    if (x is object)
                    {
                        x.selected = !x.selected;
                    }
                }
            }
        }
    }
}