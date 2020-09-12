using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    public GameObject target;
    private bool targetLocked;
    public GameObject Archer;
    public GameObject ArrowSpawnPoint;

    public float fireTimer;
    float timer = 0.0f;
    public bool shotReady = false;
    private bool canShoot = false;
    public GameObject arrow;
    public Animator animator;

    void Start()
    {
        shotReady = false;
    }

    void Update()
    {
        timer += Time.deltaTime * 0.1f;
        if (targetLocked)
        {
            Archer.transform.LookAt(target.transform);
            ArrowSpawnPoint.transform.LookAt(target.transform);
            Archer.transform.Rotate(0, 90, 0);
        }
        if (canShoot)
        {
            if (shotReady)
            {
                shoot();
            }
        }
        fireRate();

    }


    void shoot()
    {
        Transform _arrow = Instantiate(arrow.transform, ArrowSpawnPoint.transform.position, Quaternion.identity);
        _arrow.transform.rotation = ArrowSpawnPoint.transform.rotation;
        shotReady = false;
    }

    void fireRate()
    {
        //yield return new WaitForSeconds(fireTimer);
       if (timer > fireTimer)
        {
            shotReady = true;
            timer = 0.0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            targetLocked = true;
            shotReady = true;
            canShoot = true;
            animator.SetBool("Fire", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetLocked = false;
            canShoot = false;
            animator.SetBool("Fire", false);
        }
    }
}