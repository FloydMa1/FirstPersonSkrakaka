﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    //public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    [HideInInspector]
    public float targetX;
    public float targetY;
    public float targetZ;

    public GameObject particleObject;

    float timer;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    float effectsDisplayTime = 0.2f;


    void Awake()
    {
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            ToggleShootEffects(false);
        }
        Debug.DrawRay(transform.position, transform.forward, Color.blue);
    }

    private void ToggleShootEffects(bool on)
    {
        gunLine.enabled = on;
        gunLine.SetPosition(0, transform.position);

    }

    void Shoot()
    {
        timer = 0f;

        gunParticles.Stop();
        gunParticles.Play();

        ToggleShootEffects(true);
        RaycastHit shootHit;

        if (Physics.Raycast(transform.position, transform.forward, out shootHit, range))
        {
            print("Found an object - distance: " + shootHit.distance + " target x: " + shootHit.transform.position.x + " target y: " + shootHit.transform.position.y + " target z: " + shootHit.transform.position.z);
            gunLine.SetPosition(1, shootHit.point);

            targetX = shootHit.transform.position.x;
            targetY = shootHit.transform.position.y;
            targetZ = shootHit.transform.position.z;

            Instantiate(particleObject, shootHit.transform.position, Quaternion.identity);
        }
        else
        {
            gunLine.SetPosition(1, transform.position + transform.forward * range);
        }
    }
}
