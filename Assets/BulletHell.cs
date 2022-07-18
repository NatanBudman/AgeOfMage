using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 5;

    [SerializeField]
    private int bulletsIfAngryAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    public GameObject bullet;
    public GameObject parent;

    private Vector2 bulletMoveDirection;

    public HealthController heatlh;
    void Start()
    {
        InvokeRepeating("Fire", 0f, 5);
    }

    private void Update()
    {
        if (heatlh.Death)
        {
            Room.IsDefeatBoss = true;
        }
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;


        if (heatlh.currentLife <= 500)
        {
            for (int i = 0; i < bulletsIfAngryAmount + 1; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject projectile = Instantiate(bullet, transform.position, transform.rotation, parent.transform);
                projectile.transform.position = transform.position;
                projectile.transform.rotation = transform.rotation;
                projectile.GetComponent<bulletBoss>().SetMoveDirection(bulDir);
                angle += angleStep;

            }
        }
        else
        {
            for (int i = 0; i < bulletsAmount + 1; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 80f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 80f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject projectile = Instantiate(bullet, transform.position, transform.rotation, parent.transform);
                projectile.transform.position = transform.position;
                projectile.transform.rotation = transform.rotation;
                projectile.GetComponent<bulletBoss>().SetMoveDirection(bulDir);
                angle += angleStep;

            }
        }
    }
}
