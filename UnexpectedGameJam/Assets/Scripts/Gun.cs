﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 2)]
    private float fireRate = 1;

    private Animator animator;

    [SerializeField]
    private Transform firePoint;


    public enum Weapon { Shotgun, Deagle, Bible };

    public Weapon currWeapon;

    public ParticleSystem muzzleFlashBlunder;

    public ParticleSystem muzzleFlashDeagle;

    public Image gunIcon;

    [SerializeField]
    [Range(1, 10)]
    private int damage;

    private float timer;

    public Sprite deagleSprite;
    public Sprite shotgunSprite;
    public Sprite bibleSprite;

    public GameObject Deagle;
    public GameObject Blunder;
    public GameObject Bible;

    void Start()
    {
        currWeapon = Weapon.Deagle;
        gunIcon.sprite = deagleSprite;

        Deagle.SetActive(true);
        Blunder.SetActive(false);

        animator = GetComponentInChildren<Animator>();

        ChangeGun(Weapon.Deagle);
    }


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

        muzzleFlashDeagle.Play();

        if (Physics.Raycast(ray, out hitInfo, 50))
        {
            // Debug.Log("Hit!");
            if (hitInfo.collider.tag == "Enemy")
            {
                hitInfo.collider.gameObject.GetComponent<EnemyHealth>().LoseHealth(25);
            }
        }
    }

    private void FireShotgun()
    {
        Ray[] shotgunRays = new Ray[10];
        RaycastHit[] shotgunHits = new RaycastHit[10];

        muzzleFlashBlunder.Play();

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
                //Debug.Log("Hit!");
                if (shotgunHits[i].collider.tag == "Enemy")
                {
                    shotgunHits[i].collider.gameObject.GetComponent<EnemyHealth>().LoseHealth(10);

                }
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
                gunIcon.sprite = shotgunSprite;

                animator.SetInteger("Gun", 1);
                Deagle.SetActive(false);
                Blunder.SetActive(true);
                break;
            case Weapon.Deagle:
                fireRate = 0.25f;
                currWeapon = Weapon.Deagle;
                gunIcon.sprite = deagleSprite;

                animator.SetInteger("Gun", 0);
                Deagle.SetActive(true);
                Blunder.SetActive(false);

                break;
            case Weapon.Bible:
                fireRate = 5.0f;
                currWeapon = Weapon.Bible;
                gunIcon.sprite = bibleSprite;

                break;
            default:
                break;
        }
    }

}