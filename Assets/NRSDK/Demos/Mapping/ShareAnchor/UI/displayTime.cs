using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayTime : MonoBehaviour
{
    public Text timeText; // Reference to the Text UI element

    // Update is called once per frame
    void Update()
    {
        timeText.text = System.DateTime.Now.ToString("HH:mm:ss"); // Update the text to the current time
    }
}
