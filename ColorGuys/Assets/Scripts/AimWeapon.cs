using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Transform player;
    [SerializeField] private Camera cam;
    [SerializeField] private float playerScaleMagnitude = 0.2f;
    public Vector3 aimDirection;

    private void Update()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        aimDirection = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;
        Vector3 playerLocalScale = new Vector3(playerScaleMagnitude, playerScaleMagnitude, playerScaleMagnitude);

        if (angle > 90f || angle < -90f)
        {
            playerLocalScale.x = -playerScaleMagnitude;
            localScale = Vector3.one * -1f;
            localScale.z = 1;
        }
        else
        {
            playerLocalScale.x = playerScaleMagnitude;
            localScale = Vector3.one;
            localScale.z = 1;
        }

        player.transform.localScale = playerLocalScale;
        transform.localScale = Vector3.Lerp(transform.localScale, localScale, 50 * Time.deltaTime);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 vector = cam.ScreenToWorldPoint(Input.mousePosition);
        vector.z = 0f;
        return vector;
    }
}
