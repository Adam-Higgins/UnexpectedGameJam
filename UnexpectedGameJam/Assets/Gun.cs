using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 2)]
    private float fireRate = 1;

    [SerializeField]
    private Transform firePoint;

    public ParticleSystem muzzleFlash;

    [SerializeField]
    [Range(1,10)]
    private int damage;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetMouseButtonDown(0))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red, 10f);
        //Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        muzzleFlash.Play();

        if (Physics.Raycast(ray, out hitInfo,100))
        {
            Debug.Log("Hit!");
        }
    }
}
