using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionModel
{
    public static Vector3 right_land = new Vector3(15, -4, 0);
    public static Vector3 left_land = new Vector3(-13, -4, 0);
    public static Vector3 river = new Vector3(1, -5.5f, 0);
    public static Vector3 left_boat = new Vector3(-4.5f, -3.8f, 0);
    public static Vector3 right_boat = new Vector3(6.5f, -3.8f, 0);
    public static Vector3[] roles = new Vector3[] {
        new Vector3(-0.2f, 0.7f, 0), new Vector3(-0.1f, 0.7f, 0), new Vector3(0, 0.7f, 0),
        new Vector3(0.1f, 0.7f,0), new Vector3(0.2f,0.7f, 0), new Vector3(0.3f, 0.7f,0)
    };

    public static Vector3[] boatRoles = new Vector3[] {
        new Vector3(-0.1f, 1.2f, 0), new Vector3(0.2f, 1.2f, 0)
    };
}
