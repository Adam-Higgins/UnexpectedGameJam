﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public int Timer = 500;
    public int Choice;
    public float[] Position;
    public int height;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer - 1;

        if (Timer == 0)
        {
            Move();
        }

    }

    void Move()
    {
        Choice = Random.Range(0, 4);
        Debug.Log("Yup");
        Timer = 500;
        transform.position = new Vector3(Position[Choice], height, -Position[Choice]);
    }
}
