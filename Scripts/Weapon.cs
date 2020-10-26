using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;
    private AudioSource shootSFX;

    void Start()
    {
        shootSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        shootSFX.Play();
    }
}
