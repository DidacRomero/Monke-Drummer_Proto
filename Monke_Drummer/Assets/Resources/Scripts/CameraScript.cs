using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject tgt;
    private void Awake()
    {
        tgt = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tgt != null)
        {
            this.transform.position = new Vector3(tgt.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}
