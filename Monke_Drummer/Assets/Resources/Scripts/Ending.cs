using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    GameObject end_text;
    // Start is called before the first frame update
    void Start()
    {
        end_text = GameObject.Find("Ending_Text");

        if(end_text != null)
        {
            end_text.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            end_text.SetActive(true);
        }
    }

}
