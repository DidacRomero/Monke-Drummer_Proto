using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    List<GameObject> chops;

    GameObject final_collider;

    public int length = 10;
    // Start is called before the first frame update
    void Start()
    {
        final_collider = GameObject.Find("FinalCollider");

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
        chops.Add(Resources.Load<GameObject>("Prefabs/LevelChops/Chop_5"));
        chops.Add(Resources.Load<GameObject>("Prefabs/LevelChops/Chop_6"));
        chops.Add(Resources.Load<GameObject>("Prefabs/LevelChops/Chop_7"));
        chops.Add(Resources.Load<GameObject>("Prefabs/LevelChops/Chop_8"));

    }

    public void PopulateLevel()
    {

        GameObject c1 = chops[0];    //Since the random is non inclusive at end of range we won't go out of range
        Instantiate(c1, new Vector3(0, 0, 0), new Quaternion());

        for (int i = 1; i < length; ++i)
        {
            GameObject c = chops[(int)Random.Range(0, chops.Count)];    //Since the random is non inclusive at end of range we won't go out of range
            Instantiate(c, new Vector3(i*20, 0,0), new Quaternion());
        }

        //Place Final Collider
        if (final_collider != null)
            final_collider.transform.position = new Vector3(20 * (length -1), final_collider.transform.position.y, final_collider.transform.position.z);
    }
}
