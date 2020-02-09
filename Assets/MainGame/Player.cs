using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float money;

    private GameObject canvas;
    private Text money_label;
    private Text object_chosen_label;
    public string object_chosen;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        money_label = canvas.transform.Find("Amount of money").gameObject.GetComponent<Text>();
        object_chosen_label = canvas.transform.Find("Object to create").gameObject.GetComponent<Text>();

        object_chosen = "Farma";
    }

    // Update is called once per frame
    void Update()
    {
        money_label.text = "Money: " + ((int) money).ToString() + "G";
        object_chosen_label.text = object_chosen;
    }
}
