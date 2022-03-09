using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] Transform AttackPoint;
    [SerializeField] KeyCode ShootKey = KeyCode.Mouse0;
    [SerializeField] GameObject Bullet;
    [SerializeField] float bulletSpeed = 12f;
    [SerializeField] LayerMask Shootable;

    [SerializeField] bool FullAuto = false;

    private AimWeapon aimWeapon;

    private void Update()
    {
        if (FullAuto ? (Input.GetKey(ShootKey)) : (Input.GetKeyDown(ShootKey)))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(Bullet, AttackPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = currentBullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = AttackPoint.right * bulletSpeed;
    }
}
