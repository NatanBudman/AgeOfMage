using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 0f, endAngle = 90f;

    public GameObject bullet;

    private Vector2 bulletMoveDirection;


    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject projectile = Instantiate(bullet);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.GetComponent<bulletBoss>().SetMoveDirection(bulDir);
            angle += angleStep;

        }
    }
}
