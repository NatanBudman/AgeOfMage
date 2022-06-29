using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princesa_Boss : MonoBehaviour
{
    EnemyScript enemy;
    [SerializeField] Animator Animations;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform BulletPointShoot;
    [SerializeField] GameObject Bullet1;
    [SerializeField] GameObject Bullet2;
    [SerializeField] float fireForce;
    [SerializeField] float fireForceBullet2;
    [SerializeField] float FrecuenceBullet1Shoot;
    [SerializeField] float CoolDownBullet1;
    [SerializeField] float CoolDownBullet2;
    [SerializeField] bool IsShootBullet2;
    [SerializeField] bool IsShootBullet1;
    float CurrentBullet1Bullets;
    float CurrentBullet1;
    float CurrentBullet2;
    public bool IsBullet2;
    public bool IsBullet1;
    int countBullet2Shoot = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Mechanics();
        animations();
        Fire();
    }
    void animations()
    {
        Animations.SetBool("Ataque1", IsBullet1);
    }
    void Mechanics()
    {
        CurrentBullet2 += Time.deltaTime;
        CurrentBullet1 += Time.deltaTime;

        if (CurrentBullet1 >= CoolDownBullet1)
        {
            IsBullet1 = true;
            CurrentBullet1 = 0;
        }

        if (CurrentBullet2 >= CoolDownBullet2)
        {
            IsBullet2 = true;
            CurrentBullet1 = 0;
            IsBullet1 = false;
            countBullet2Shoot = 1;
            CurrentBullet2 = 0;
        }

    }
    public void Fire()
    {
        if (IsShootBullet1)
        {
            CurrentBullet1Bullets += Time.deltaTime;
            if (FrecuenceBullet1Shoot <= CurrentBullet1Bullets)
            {
                GameObject CanonProjectile = Instantiate(Bullet1, BulletPointShoot.position, Quaternion.identity);
                CanonProjectile.GetComponent<Rigidbody2D>().AddForce(BulletPointShoot.up * fireForce, ForceMode2D.Impulse);
                CurrentBullet1Bullets = 0;
            }
        }
        if (IsShootBullet2 && countBullet2Shoot > 0)
        {
            GameObject RifleProjectile = Instantiate(Bullet2, BulletPointShoot.position, Quaternion.identity);
            RifleProjectile.GetComponent<Rigidbody2D>().AddForce(BulletPointShoot.up * fireForce, ForceMode2D.Impulse);
            countBullet2Shoot--;
        }

    }
}
