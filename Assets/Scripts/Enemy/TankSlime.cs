using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSlime : MonoBehaviour
{
    HealthController health;
    EnemyScript enemy;
    public Animator animation;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform BulletPoint;
    [SerializeField] private bool IsShooting;
    [SerializeField] private bool IsIntanciateBullet;
    [SerializeField] private float CoolDownShoot;

    float CurrenTimeShoot;
    float fireForce = 32;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        health = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrenTimeShoot += Time.deltaTime;
        Shoot();
        Bullets();
        animations();
    }
    void Shoot() 
    {
        if(Vector2.Distance(enemy.player.transform.position,transform.position) < enemy.RangeShoot) 
        {
            if(CurrenTimeShoot > CoolDownShoot && !health.Death) 
            {
                IsShooting = true;
                CurrenTimeShoot = 0;
            }
        }
    }
    void animations() 
    {
        animation.SetBool("Shooting", IsShooting);
    }
    public void Bullets() 
    {
        if (IsIntanciateBullet && !health.Death) 
        {
            GameObject projectile = Instantiate(Bullet, BulletPoint.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(BulletPoint.up * fireForce, ForceMode2D.Impulse);
        }
    }
}
