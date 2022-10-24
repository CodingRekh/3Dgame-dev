using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Transform : MonoBehaviour
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
        this.transform.position += Time.deltaTime * Vector3.right * v0;
        this.transform.position += Time.deltaTime * Time.deltaTime * Vector3.down * vt;
    }
}
