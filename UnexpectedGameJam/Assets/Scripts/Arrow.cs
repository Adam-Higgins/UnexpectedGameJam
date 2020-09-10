﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float movementSpeed;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);               
    }
}
