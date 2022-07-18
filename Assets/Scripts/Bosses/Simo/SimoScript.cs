using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimoScript : MonoBehaviour
{
    //[SerializeField] Room room;
    EnemyScript enemy;
    HealthController heathl;
    [SerializeField] Animator Animations;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform RiflePointShoot;
    [SerializeField] Transform CanonPointShoot;
    [SerializeField] GameObject BulletRifle;
    [SerializeField] GameObject BulletCanon;
    [SerializeField] GameObject[] EnemySpawn;
    [SerializeField] GameObject[] Spawn;
    [SerializeField] float fireForce;
    [SerializeField] float FrecunceRifleBullets;
    [SerializeField] float CoolDownRifle;
    [SerializeField] float CoolDownCanon;
    [SerializeField] float CoolDownReload;
    [SerializeField] bool IsShoot;
    [SerializeField] bool IsShootCanon;
    [SerializeField] bool IsShootRifle;
    [SerializeField] bool IsReload;
    float CurrentRifleBullets;
    float CurrentRifle;
    float CurrentCanon;
    float CurrentReload;
    public bool IsCanon;
    public bool IsRifle;
    float EnemeySpawning = 5;
    int count = 4;
    int countCanonShoot = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        for (int i = 0; i < Spawn.Length; i++) 
        {
            Spawn = GameObject.FindGameObjectsWithTag("EnemySpawn");
        }
        heathl = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        Mechanics();
        animations();
        if (IsShoot) 
        {
            Fire();
        }
        if (heathl.Death) 
        {
            GameManager.CompleteLevel3 = true;
            Room.IsDefeatBoss = true;
        }
    }
    void animations() 
    {
        Animations.SetBool("IsCanon", IsCanon);
        Animations.SetBool("IsRifle", IsRifle);
    }
    void Mechanics() 
    {
        CurrentCanon += Time.deltaTime;
        CurrentRifle += Time.deltaTime;
        CurrentReload += Time.deltaTime;
        if (CurrentReload > CoolDownReload)
        {
            IsReload = true;

        }
        else 
        {
            IsReload = false;
        }
        if (CurrentReload > 55) 
        {
            count = 4;
            CurrentReload = 0;
        }
        if (IsReload) 
        {
            SpawnEnemy();
            CurrentCanon = 0;
            CurrentRifle = 0;
            IsShoot = false;
            IsShoot = false;
            IsRifle = false;
        }
        else 
        {
            IsShoot = true;
        }
        if (CurrentRifle >= CoolDownRifle && !heathl.Death)
        {
            IsRifle = true;
            CurrentRifle = 0;
        }
     
        if (CurrentCanon >= CoolDownCanon && !heathl.Death) 
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
        if (IsShootRifle && !heathl.Death)
        {
            CurrentRifleBullets += Time.deltaTime;
            if (FrecunceRifleBullets <= CurrentRifleBullets) 
            {
                GameObject CanonProjectile = Instantiate(BulletRifle, CanonPointShoot.position, Quaternion.identity);
                CanonProjectile.GetComponent<Rigidbody2D>().AddForce(CanonPointShoot.up * fireForce, ForceMode2D.Impulse);
                CurrentRifleBullets = 0;
            }
        }
        if (IsShootCanon && countCanonShoot > 0 && !heathl.Death) 
        {
            GameObject RifleProjectile = Instantiate(BulletCanon, RiflePointShoot.position, Quaternion.identity);
            RifleProjectile.GetComponent<Rigidbody2D>().AddForce(RiflePointShoot.up * fireForce, ForceMode2D.Impulse);
            countCanonShoot--;
        }

    }
}
