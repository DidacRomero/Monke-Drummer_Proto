using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI time_txt;

    float total_time = 0.0f;
    float seconds = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        time_txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        total_time += Time.deltaTime;

        if (seconds >= 60000.0f)
            seconds = 0.0f;

        seconds += Time.deltaTime;

        if (time_txt != null)
        time_txt.text = (int)total_time%60000.0f + ":" + total_time;
    }
}
