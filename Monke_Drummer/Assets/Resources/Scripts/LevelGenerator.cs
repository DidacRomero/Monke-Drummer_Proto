using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    List<GameObject> chops;

    public int length = 10;
    // Start is called before the first frame update
    void Start()
    {
        chops = new List<GameObject>();
        PopulateChops();
        PopulateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopulateChops()
    {
        chops.Add(Resources.Load<GameObject>("Prefabs/LevelChops/Chop_1"));
        chops.Add(Resources.Load<GameObject>("Prefabs/LevelChops/Chop_2"));
        chops.Add(Resources.Load<GameObject>("Prefabs/LevelChops/Chop_3"));
        chops.Add(Resources.Load<GameObject>("Prefabs/LevelChops/Chop_4"));
    }

    public void PopulateLevel()
    {
        for (int i = 0; i < length; ++i)
        {
            GameObject c = chops[(int)Random.Range(0, chops.Count)];    //Since the random is non inclusive at end of range we won't go out of range
            Instantiate(c, new Vector3(i*20, 0,0), new Quaternion());
        }
    }
}
