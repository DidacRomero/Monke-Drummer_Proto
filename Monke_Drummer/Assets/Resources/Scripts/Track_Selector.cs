using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Track_Selector : MonoBehaviour
{
    public string item0 = "";
    public string item1 = "";
    public string item2 = "";
    public string item3 = "";

    List<string> items_list;

    Text item_txt;

    public uint default_item = 0;

    [SerializeField]
    private uint item = 0;

    [FMODUnity.EventRef]
    public string TrackEvent = "";

    FMOD.Studio.EventInstance track;

    float initial_time;
    float Timer = 0.0f;
    bool timerset = false;


    // Start is called before the first frame update
    void Start()
    {
        items_list = new List<string>();
        {
            if(item0 != "")
            items_list.Add(item0);

            if (item1 != "")
                items_list.Add(item1);

            if (item2 != "")
                items_list.Add(item2);

            if (item3 != "")
                items_list.Add(item3);
        }

        item_txt = GetComponentInChildren<Text>();  //Display text will always be the first child with a text component

        if (TrackEvent != "")
        {
            track = FMODUnity.RuntimeManager.CreateInstance(TrackEvent);
            track.setParameterByName("Harmony", 0);
            track.start();
            initial_time = Time.realtimeSinceStartup;
            track.release();
        }
        //Debug.Log("Velocity: " + vel);
    }

    // Update is called once per frame
    void Update()
    {
        if(item < items_list.Count)
        {
            item_txt.text = items_list[(int)item];
        }
        if(timerset == false)
        {
            Timer += Time.realtimeSinceStartup - initial_time;
            timerset = true;
        }

        Timer += Time.deltaTime;


        if (Timer >= 11.8f/*0.75 * 15*/)
        {
            track.setParameterByName("Harmony", item);
            Timer = 0;
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

    private void OnDestroy()
    {
        track.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

}
