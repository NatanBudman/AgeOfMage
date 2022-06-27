using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princesa_Boss : MonoBehaviour
{
    EnemyScript enemy;
    [SerializeField] Animator Animations;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform Bullet1PointShoot;
    [SerializeField] Transform Bullet2CanonPointShoot;
    [SerializeField] GameObject Bullet1;
    [SerializeField] GameObject Bullet2;
    [SerializeField] float fireForce;
    [SerializeField] float FrecuenceBullet1Shoot;
    [SerializeField] float CoolDownBullet1;
    [SerializeField] float CoolDownBullet2;
    [SerializeField] bool IsShootBullet2;
    [SerializeField] bool IsShootBullet1;
    float CurrentBullet1;
    float CurrentBullet2;
    public bool IsBullet2;
    public bool IsBullet1;
    float EnemeySpawning = 5;
    int count = 4;
    int countCanonShoot = 1;
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

    }
    void Mechanics()
    {
        CurrentBullet2 += Time.deltaTime;
        CurrentBullet1 += Time.deltaTime;
        else
        {
            IsShoot = true;
        }
        if (CurrentRifle >= CoolDownRifle)
        {
            IsRifle = true;
            CurrentRifle = 0;
        }

        if (CurrentCanon >= CoolDownCanon)
        {
            IsCanon = true;
            CurrentRifle = 0;
            IsRifle = false;
            countCanonShoot = 1;
            CurrentCanon = 0;
        }

    }
    void SpawnEnemy()
    {

        if (IsReload && count >= 0)
        {
            Instantiate(EnemySpawn[count], Spawn[count].transform.position, Quaternion.identity);
            count--;
        }

    }
    public void Fire()
    {
        if (IsShootRifle)
        {
            CurrentRifleBullets += Time.deltaTime;
            if (FrecunceRifleBullets <= CurrentRifleBullets)
            {
                GameObject CanonProjectile = Instantiate(BulletRifle, CanonPointShoot.position, Quaternion.identity);
                CanonProjectile.GetComponent<Rigidbody2D>().AddForce(CanonPointShoot.up * fireForce, ForceMode2D.Impulse);
                CurrentRifleBullets = 0;
            }
        }
        if (IsShootCanon && countCanonShoot > 0)
        {
            GameObject RifleProjectile = Instantiate(BulletCanon, RiflePointShoot.position, Quaternion.identity);
            RifleProjectile.GetComponent<Rigidbody2D>().AddForce(RiflePointShoot.up * fireForce, ForceMode2D.Impulse);
            countCanonShoot--;
        }

    }
}
