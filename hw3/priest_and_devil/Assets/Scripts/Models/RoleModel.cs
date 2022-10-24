using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleModel
{
    public GameObject role;
    public bool isPriest;
    public int tag;
    public bool isRight;
    public bool isInBoat;

    public RoleModel(Vector3 position, bool isPriest, int tag)
    {
        this.isPriest = isPriest;
        this.tag = tag;

        isRight = false;
        isInBoat = false;

        role = GameObject.Instantiate(Resources.Load("Prefabs/" + (isPriest ? "priest" : "devil"), typeof(GameObject))) as GameObject;
        role.transform.localScale = new Vector3(1, 1, 1);
        role.transform.position = position;
        role.name = "role" + tag;

        role.AddComponent<Click>();
        role.AddComponent<BoxCollider>();
    }
}
