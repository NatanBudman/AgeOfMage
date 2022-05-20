using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfScript : MonoBehaviour
{
    HealthController health;
    EnemyScript enemy;
    [SerializeField]private Transform PointShoot;
    [SerializeField]private GameObject Bullet;
    [SerializeField]private float CoolwDownShoot;
    [SerializeField]private Animator animation;
    [SerializeField]private bool ShootBullet;
    [SerializeField]private bool ShootAnimation;
    float CurrentTimeShoot;
    [SerializeField]private float fireForce;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        health = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTimeShoot += Time.deltaTime;
        ShootElf();
        Animations();
    }

    void ShootElf() 
    {
        if (Vector2.Distance(transform.position, enemy.player.transform.position) <= enemy.RangeShoot) 
        {
            if (CurrentTimeShoot >= CoolwDownShoot && health.Death == false) 
            {
                ShootAnimation = true;

                CurrentTimeShoot = 0;

            }
            else 
            {
                ShootAnimation = false;

            }


        }
        if (ShootBullet)
            Shoot();
    }
    public void Shoot() 
    {
        GameObject projectile = Instantiate(Bullet, PointShoot.transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(PointShoot.up * fireForce, ForceMode2D.Impulse);
    }
    void Animations() 
    {
        animation.SetBool("Shoot", ShootAnimation);
    }
}
