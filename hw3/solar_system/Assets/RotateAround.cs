using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform target;
    public float speed;
    private float rx; //法向量


    // Start is called before the first frame update
    void Start()
    {
        rx = Random.Range(-20, 20);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = new Vector3(rx, 100, 0);
        this.transform.RotateAround(target.position, axis, Time.deltaTime * speed);
    }
}
