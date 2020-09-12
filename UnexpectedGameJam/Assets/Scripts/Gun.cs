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


    public enum Weapon { Shotgun, Deagle, Bible };

    public Weapon currWeapon = Weapon.Deagle;

    public ParticleSystem muzzleFlash;

    [SerializeField]
    [Range(1, 10)]
    private int damage;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (currWeapon)
            {
                case Weapon.Deagle:
                    ChangeGun(Weapon.Shotgun);
                    break;
                case Weapon.Shotgun:
                    ChangeGun(Weapon.Bible);
                    break;
                case Weapon.Bible:
                    ChangeGun(Weapon.Deagle);
                    break;
                default:
                    break;
            }
        }
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
        switch (currWeapon)
        {
            case Weapon.Shotgun:
                FireShotgun();
                break;
            case Weapon.Deagle:
                FireDeagle();
                break;
            case Weapon.Bible:
                FireBible();
                break;
            default:
                break;
        }
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }

    private void FireDeagle()
    {
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red, 10f);

        RaycastHit hitInfo;

        muzzleFlash.Play();

        if (Physics.Raycast(ray, out hitInfo, 50))
        {
            Debug.Log("Hit!");
        }
    }

    private void FireShotgun()
    {
        Ray[] shotgunRays = new Ray[10];
        RaycastHit[] shotgunHits = new RaycastHit[10];

        muzzleFlash.Play();

        shotgunRays[0] = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        for (int i = 1; i < 10; i++)
        {
            shotgunRays[i] = new Ray(shotgunRays[0].origin, RotatePointAroundPivot(shotgunRays[0].direction, shotgunRays[0].origin, new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0)) * 5f);
            Debug.DrawRay(shotgunRays[i].origin, shotgunRays[i].direction * 5f, Color.red, 10f);
        }
        for (int i = 1; i < 10; i++)
        {
            if (Physics.Raycast(shotgunRays[i], out shotgunHits[i], 8f))
            {
                Debug.Log("Hit!");
            }
        }

    }

    private void FireBible()
    {

    }

    private void ChangeGun(Weapon newWeapon)
    {
        switch (newWeapon)
        {
            case Weapon.Shotgun:
                fireRate = 1.5f;
                currWeapon = Weapon.Shotgun;
                break;
            case Weapon.Deagle:
                fireRate = 0.25f;
                currWeapon = Weapon.Deagle;
                break;
            case Weapon.Bible:
                fireRate = 5.0f;
                currWeapon = Weapon.Bible;
                break;
            default:
                break;
        }
    }

}