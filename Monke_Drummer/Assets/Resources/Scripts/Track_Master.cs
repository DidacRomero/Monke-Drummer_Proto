using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Track_Master : MonoBehaviour
{
    // Start is called before the first frame update
    List<Track_Selector> children;
    Track_Selector[] selectors;

    GameObject focus_image;

    [SerializeField]
    uint focus_child = 0;
    void Start()
    {
        focus_image = gameObject.GetComponentsInChildren<Transform>()[1].gameObject;
        //Transform t = gameObject.GetComponentsInChildren<Transform>()[0].gameObject;
        children = new List<Track_Selector>();
        selectors = gameObject.GetComponentsInChildren<Track_Selector>();

        for (int i = 0; i < selectors.Length; ++i)
            children.Add(selectors[i]);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Keyboard.current.downArrowKey.wasPressedThisFrame == true)
        {
            if (focus_child == (uint)children.Count - 1)
                focus_child = 0;
            else
                focus_child++;
        }
        if (Keyboard.current.upArrowKey.wasPressedThisFrame == true)
        {
            if (focus_child == 0)
                focus_child = (uint)children.Count - 1;
            else
                focus_child--;
        }

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame == true)
            children[(int)focus_child].ItemLeft();

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame == true)
            children[(int)focus_child].ItemRight();


        if (focus_image != null)
        {
            //focus_image.GetComponent<RectTransform>().anchoredPosition = children[(int)focus_child].GetComponent<RectTransform>().anchoredPosition;
            RectTransform r = focus_image.GetComponent<RectTransform>();
            r.anchoredPosition = children[(int)focus_child].GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
