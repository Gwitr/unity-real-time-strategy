using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float money;

    private GameObject canvas;
    private Text money_label;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        money_label = canvas.transform.Find("Amount of money").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        money_label.text = "Money: " + ((int) money).ToString() + "G";
    }
}
