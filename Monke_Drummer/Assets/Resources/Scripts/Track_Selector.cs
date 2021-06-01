using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Track_Selector : MonoBehaviour
{
    public string item1 = "";
    public string item2 = "";
    public string item3 = "";

    List<string> items_list;

    Text item_txt;

    [SerializeField]
    private uint item = 0;


    // Start is called before the first frame update
    void Start()
    {
        items_list = new List<string>();
        {
            items_list.Add(item1);
            items_list.Add(item2);
            items_list.Add(item3);
        }

        item_txt = GetComponentInChildren<Text>();  //Display text will always be the first child with a text component
    }

    // Update is called once per frame
    void Update()
    {
        
        if(item < items_list.Count)
        {
            item_txt.text = items_list[(int)item];
        }
    }

    public void ItemLeft()
    {
        if (item == 0)
            item = (uint)items_list.Count - 1;
        else
            item--;
    }

    public void ItemRight()
    {
        if (item == (uint)items_list.Count - 1)
            item = 0;
        else
            item++;
    }

}
