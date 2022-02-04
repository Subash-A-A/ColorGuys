using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Camera cam;

    private void Update()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;

        if (angle > 90f || angle < -90f)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        transform.localScale = Vector3.Lerp(transform.localScale, localScale, 25f * Time.deltaTime);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 vector = cam.ScreenToWorldPoint(Input.mousePosition);
        vector.z = 0f;
        return vector;
    }
}