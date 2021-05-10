using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject cam;

    List<GameObject> children;

    public int width = 200;

    [SerializeField]
    private int total_width = 0;
    private int iterations = 0;

    private void Awake()
    {
        string s = "Main Camera";
        cam = GameObject.Find(s);

        if (cam == null)
            Debug.Log("Main Camera:" + s + " was not found");

        Transform[] ts = gameObject.GetComponentsInChildren<Transform>();
        children = new List<GameObject>();
        if(ts != null)
        {
            foreach(Transform t in ts)
            {
                children.Add(t.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (cam != null)
        {

            this.transform.position = cam.transform.position;

            //total_width = iterations * width;

            //for (int i = 0; i < children.Count; ++i)
            //{
            //    if(cam.transform.position.x >= total_width)
            //    {
            //        children[i].transform.position = new Vector3(total_width, children[i].transform.position.y, children[i].transform.position.z);
            //        iterations++;
            //    }
            //}
           
        }
    }
}
