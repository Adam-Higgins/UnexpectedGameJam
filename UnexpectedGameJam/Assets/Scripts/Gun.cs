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
        for (int i = 0; i < 10; i++)
        {
            Debug.DrawRay(ray.origin, RotatePointAroundPivot(ray.direction, ray.origin, new Vector3(Random.Range(-0.5f,0.5f), Random.Range(-0.5f, 0.5f), 0)) * 100f, Color.red, 10f);
        }
        Debug.DrawRay(ray.origin, RotatePointAroundPivot(ray.direction,ray.origin, new Vector3(1f,1f,0)) * 100f , Color.red, 10f);
       // Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red, 10f);
      //  Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red, 10f);
      //  Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red, 10f);
     //   Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red, 10f);
      //  Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red, 10f);
        RaycastHit hitInfo;

        muzzleFlash.Play();

        if (Physics.Raycast(ray, out hitInfo,100))
        {
            Debug.Log("Hit!");
        }
    }
    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }
}
