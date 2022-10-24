using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandModel
{
    public GameObject land;
    public int priestNum, devilNum;

    public LandModel(string name, Vector3 position)
    {
        priestNum = 0;
        devilNum = 0;

        land = GameObject.Instantiate(Resources.Load("Prefabs/land", typeof(GameObject))) as GameObject;
        land.name = name;
        land.transform.position = position;
        land.transform.localScale = new Vector3(13, 5, 3);
    }
}
