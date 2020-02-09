using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public float speed;
    public float scrollspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, (Input.GetKey(KeyCode.Q) ? 1 : 0) * scrollspeed * Time.deltaTime + (Input.GetKey(KeyCode.E) ? -1 : 0) * scrollspeed * Time.deltaTime));
        transform.position += new Vector3(Input.GetAxis("Horizontal") * transform.position.y * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * transform.position.y * speed * Time.deltaTime);
    }
}
