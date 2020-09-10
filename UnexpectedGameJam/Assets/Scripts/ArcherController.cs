using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.LookAt(target);

        transform.LookAt(target, Vector3.left);
    }
}
