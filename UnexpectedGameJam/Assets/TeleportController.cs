using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public GameObject target;
    private bool targetLocked;
    public GameObject Jumper;
    public GameObject ArrowSpawnPoint;

    public float fireTimer;
    public bool shotReady;
    private bool canShoot = false;
    public GameObject arrow;

    void Start()
    {
        shotReady = false;
    }

    void Update()
    {
        if (targetLocked)
        {
            Jumper.transform.LookAt(target.transform);
            Jumper.transform.Rotate(0, 90, 0);
        }
        if (canShoot)
        {
            if (shotReady)
            {
                shoot();
            }
        }

    }


    void shoot()
    {
        Transform _arrow = Instantiate(arrow.transform, transform.position, Quaternion.identity);
        _arrow.transform.rotation = ArrowSpawnPoint.transform.rotation;
        shotReady = false;
        StartCoroutine(fireRate());
    }

    IEnumerator fireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        shotReady = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            targetLocked = true;
            shotReady = true;
            canShoot = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            targetLocked = false;
            StopCoroutine(fireRate());
            canShoot = false;
        }
    }
}