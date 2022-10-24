using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Vector : MonoBehaviour
{

    public float v0 = 3.0f; //初速度
    public float a = 1.0f; //加速度
    private float vt; //纵向速度

    // Start is called before the first frame update
    void Start()
    {
        vt = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        vt += a;
        Vector3 v = new Vector3(Time.deltaTime * v0, -Time.deltaTime * vt, 0);
        transform.position += v;
    }
}
