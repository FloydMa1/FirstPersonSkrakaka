using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    //public int damagePerShot = 20;
    public float timeBetweenBullets = 0.5f;
    public float range = 100f;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    //int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    private GunAnimation gunAnim;
    float effectsDisplayTime = 0.2f;


    void Awake()
    {
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAnim = transform.parent.GetComponent<GunAnimation>();
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
        Debug.DrawRay(transform.position, shootRay.direction, Color.blue);
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

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        
        if (Physics.Raycast(shootRay, out shootHit, range))
        {
            
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
        
        gunAnim.Shoot(timeBetweenBullets);
    }
}
