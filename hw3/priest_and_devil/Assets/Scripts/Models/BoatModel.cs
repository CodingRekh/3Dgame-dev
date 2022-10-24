using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatModel
{
    public GameObject boat;
    public RoleModel[] roles;
    public bool isRight;
    public int priestNum, devilNum;

    public BoatModel(Vector3 position)
    {
        priestNum = 0;
        devilNum = 0;
        roles = new RoleModel[2];

        boat = GameObject.Instantiate(Resources.Load("Prefabs/boat", typeof(GameObject))) as GameObject;
        boat.name = "boat";
        boat.transform.position = position;
        boat.transform.localScale = new Vector3(4, (float)1.5, 3);

        boat.AddComponent<BoxCollider>();
        boat.AddComponent<Click>();

        isRight = false;
    }
}
