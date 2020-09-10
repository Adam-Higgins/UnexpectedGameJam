using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    public GameObject target;
    private bool targetLocked;

    public float fireTimer;
    private bool shotReady;
    public GameObject arrow;

    void Update()
    {
        if (targetLocked)
        {
            transform.LookAt(target.transform);
            transform.Rotate(0, 90, 0);
        }

        if (shotReady)
        {
            shoot();
        }

    }

    void shoot()
    {
        Transform _arrow = Instantiate(arrow.transform, transform.position, Quaternion.identity);
        _arrow.transform.rotation = transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            targetLocked = true;
        }
    }
}
