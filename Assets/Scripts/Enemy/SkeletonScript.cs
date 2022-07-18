using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    HealthController health;
    EnemyScript enemy;
    Rigidbody2D rb;


    public BoxCollider2D SkeletonCollider;

    [SerializeField] private Animator animation;

    public Transform weapon;

    public GameObject Bullet;

    public float fireForce;

    public float coolwDownAttack;
    private float AttackCurrentTime;
    bool Attacking = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        enemy = GetComponent<EnemyScript>();
        health = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationsEnemy();
        attack();
        IfDeath();
    }
    void attack()
    {

 

        if (Vector2.Distance(transform.position, enemy.player.transform.position) <= enemy.RangeShoot)
        {
            AttackCurrentTime += Time.deltaTime;
        }
            if (coolwDownAttack <= AttackCurrentTime)
            {
                Fire();
                AttackCurrentTime = 0;
            }

        if (AttackCurrentTime <= coolwDownAttack - 1.5f )
        {
            Attacking = false;
        }
        else if(AttackCurrentTime <= coolwDownAttack - 0.1f)
        {
            Attacking = true;
        }

    }
    void IfDeath() 
    {
        if (health.Death) 
        {
         
            this.GetComponent<SkeletonScript>().enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
             Destroy(gameObject,6);
        }
    }
    void AnimationsEnemy()
    {

        animation.SetBool("Chase", enemy.chasePlayer);
        animation.SetBool("Attack", Attacking);
        animation.SetBool("Death", health.Death);


    }
    public void Fire()
    {
        Attacking = true;
        GameObject projectile = Instantiate(Bullet, weapon.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(weapon.up * fireForce, ForceMode2D.Impulse);
      
    }
}
