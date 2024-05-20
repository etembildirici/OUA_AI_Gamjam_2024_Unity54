using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Rifle Things")]
    public Camera cam;
    public float damage = 10f;
    public float shootingRange = 100f;
    public float fireReload = 15;
    public Animator anim;
    public PlayerScript player;

    [Header("Rifle Ammunition and shooting")]
    private float nextShoot = 0f;
    private int maxAmmo = 50;
    private int mag = 5;
    private int presentAmmo;
    public float reloadingTime = 1.3f;
    private bool setReloading = false;

    [Header("Rifle Effects")]
    public ParticleSystem muzzleSpark;
    public GameObject impactEffect;

    [Header("Sounds and UI")]
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AudioSource audioSource;


    private AmmoCount ammoCount;


    private void Awake()
    {
        presentAmmo = maxAmmo;
        ammoCount = FindObjectOfType<AmmoCount>();
    }

    void Update()
    {
        if (setReloading)
        {
            return;
        }

        if(presentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextShoot)
        {
            anim.SetBool("FireWalk", true);
            anim.SetBool("Fire", true);
            anim.SetBool("Idle", false);
            nextShoot = Time.time + 1f/fireReload;  
            Shoot();
        }

        else
        {
            anim.SetBool("Fire", false);
            anim.SetBool("FireWalk", false);
            anim.SetBool("Idle", true);
        }
    }
    void Shoot()
    {
        audioSource.PlayOneShot(shootSound);

        if(mag == 0)
        {
            //ammo out
            anim.SetBool("Fire", false);
            audioSource.Stop();
            return;
        }

        presentAmmo--;

        if (presentAmmo == 0)
        {
            mag--;
        }

        AmmoCount.occurrence.UpdateAmmoText(presentAmmo);
        AmmoCount.occurrence.UpdateMagText(mag);
        

        muzzleSpark.Play();
        RaycastHit hitInfo;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo,shootingRange))
        {
            Debug.Log(hitInfo.transform.name);

            ObjectScript objects = hitInfo.transform.GetComponent<ObjectScript>();

            if (objects != null)
            {
                objects.objectHitDamage(damage);
                GameObject impact = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(impact, 1f);
            }
        }
    }
    IEnumerator Reload()
    {
        player.playerSpeed = 0f;
        setReloading = true;
        Debug.Log("reloading");
        anim.SetBool("Reloading", true);

        audioSource.PlayOneShot(reloadSound);

        yield return new WaitForSeconds(reloadingTime);

        anim.SetBool("Reloading", false);
        presentAmmo = maxAmmo;
        player.playerSpeed = 7f;
        setReloading = false;
    }
}
