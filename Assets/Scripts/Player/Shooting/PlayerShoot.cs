using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    //public int damagePerShot = 20;
    public float timeBetweenBullets = 1.2f;
    public float range = 100f;

    [HideInInspector]
    public float targetX;
    public float targetY;
    public float targetZ;

    public GameObject particleHit;
    public GameObject particleMiss;

    float timer;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    private GunAnimation gunAnim;
    private GunSound gunSound;
    float effectsDisplayTime = 0.2f;


    void Awake()
    {
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAnim = transform.parent.GetComponent<GunAnimation>();
        gunSound = GetComponent<GunSound>();
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

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out shootHit, range))
        {
            gunLine.SetPosition(1, shootHit.point);

            targetX = Mathf.Ceil(shootHit.transform.position.x);
            targetY = Mathf.Ceil(shootHit.transform.position.y);
            targetZ = Mathf.Ceil(shootHit.transform.position.z);

            StartCoroutine(Doquery());
            if (shootHit.collider.tag == "Target")
            {
                var a = Instantiate(particleHit, shootHit.point, Quaternion.identity);
                Destroy(a, 4);
            }
            else
            {
                var b = Instantiate(particleMiss, shootHit.point, Quaternion.identity);
                Destroy(b, 4);
            }
        }
        else
        {
            gunLine.SetPosition(1, transform.position + transform.forward * range);
        }
        
        gunAnim.Shoot(timeBetweenBullets);
        gunSound.PlaySound();

        
    }
    IEnumerator Doquery()
    {
        WWW request = new WWW("http://22355.hosts.ma-cloud.nl/bewijzenmap/p2.1/GPR/moan.php?t_x=" + targetX + "&t_y="+ targetY +"&t_z="+ targetZ +"&p_id=1");
        yield return request;
    }
}
