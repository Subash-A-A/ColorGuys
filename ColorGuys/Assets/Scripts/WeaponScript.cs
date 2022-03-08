using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] Transform AttackPoint;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] KeyCode ShootKey;

    private void Update()
    {
        if (Input.GetKey(ShootKey))
        {
            Instantiate(BulletPrefab, AttackPoint.position, Quaternion.identity);
        }
    }
}
