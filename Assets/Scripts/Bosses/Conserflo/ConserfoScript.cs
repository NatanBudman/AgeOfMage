using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConserfoScript : MonoBehaviour
{
    State state;
    HealthController health;
    EnemyScript enemy;
    [SerializeField] private Animator animation;
    [SerializeField] private GameObject granate;
    [SerializeField] private GameObject _waterAttack;
    [SerializeField] private GameObject Blood;
    [SerializeField] private Transform PointToShoot;
    [SerializeField] private Transform[] WaterPointToShoot;
    [SerializeField] private float CooldownBombarding;
    [SerializeField] private float CooldownCrazyBombarding;
    [SerializeField] private float DurationCrazyBombarding;
    [SerializeField] private float CoolDownTeleport;
    [SerializeField] private float CoolDownReload;
    [SerializeField]private GameObject[] walls;
    float CurrentTimeLysoformBombardment;
    float CurrentTimeCrazyLysoformBombardment;
    float CurrrentTimeDurationCrazyBombarding;
    float CurrentTimeTeleport;
    float CurrentTimeReload;

    public bool ShootLysoform;
    public bool GranateAnimationAttack;
    public bool ReloadAnimation;
    public bool BasicWaterAttack;

    float beforeCooldownBombarding;
    float bloodScale;
    float FireForce = 40;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        health = GetComponent<HealthController>();
        state = GetComponent<State>();
        Blood.SetActive(false);
        walls = GameObject.FindGameObjectsWithTag("TPWalls");
        beforeCooldownBombarding = CooldownBombarding;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTimeLysoformBombardment += Time.deltaTime;
        CurrentTimeCrazyLysoformBombardment += Time.deltaTime;

        enemy.chasePlayer = false;

        Mechanics();
    }
    void Mechanics() 
    {
        LysoformBombardment();
        CreateLysoform();
        Animations();
        Death();
        Reload();
        Teleport();
        BasicAttack();
    }
    void LysoformBombardment() 
    {
        if (CurrentTimeLysoformBombardment >= CooldownBombarding && !health.Death) 
        {
            
            GranateAnimationAttack = true;

            CurrentTimeLysoformBombardment = 0;
        }

        if (CurrentTimeCrazyLysoformBombardment > CooldownCrazyBombarding) 
        {
            CurrrentTimeDurationCrazyBombarding += Time.deltaTime;

            if (CurrrentTimeDurationCrazyBombarding <= DurationCrazyBombarding) 
            {
                CooldownBombarding = 1;
            }
            else 
            {
                CurrentTimeCrazyLysoformBombardment = 0;
            }
        }
        else if(CurrentTimeCrazyLysoformBombardment <= CooldownCrazyBombarding)
        {
            CurrrentTimeDurationCrazyBombarding = 0;
            CooldownBombarding = beforeCooldownBombarding;
        }
    }
    public void CreateLysoform() 
    {
        if (ShootLysoform) 
        {
            ShootLysoform = false;
            Instantiate(granate, PointToShoot.position, Quaternion.identity);
        }
    }
    void Teleport() 
    {
        CurrentTimeTeleport += Time.deltaTime;

        float Distance = Vector2.Distance(transform.position, walls[0].transform.position);
        int wall = 0;
        for (int i = 0; i < walls.Length; i++) 
        {
            float DistanceAux = Vector2.Distance(transform.position, walls[i].transform.position);
            if(DistanceAux < Distance) 
            {
                Distance = DistanceAux;
                wall = i;
            }
        }

        if (CurrentTimeTeleport > CoolDownTeleport) 
        {
            Vector2 objetive = new Vector2(walls[wall].transform.position.x, walls[wall].transform.position.y);
            Vector2 newPos = Vector2.MoveTowards(enemy.rb.position, objetive, state.Speed * Time.deltaTime);
            enemy.rb.MovePosition(newPos);
            if (Vector2.Distance(transform.position, walls[wall].transform.position) < 10) 
            {
                int Location = (int)Random.Range(0, walls.Length);
                if (Location != wall) 
                {
                    transform.position = walls[Location].transform.position;
                    CurrentTimeTeleport = 0;
                }
            }
        }
        if (CurrentTimeTeleport < CoolDownTeleport) 
        {
            if (Vector2.Distance(transform.position, enemy.player.transform.position) < 90)
            {
                enemy.chasePlayer = false;
            }
            else
            {
                enemy.chasePlayer = true;
            }
        }
    }
    void Reload() 
    {
        CurrentTimeReload += Time.deltaTime;

        if (ReloadAnimation) { CurrentTimeLysoformBombardment = 0; GranateAnimationAttack = false; }

        if (CurrentTimeReload >= CoolDownReload && !health.Death) 
        {
            ReloadAnimation = true;

            CurrentTimeReload = 0;
        }
        else
        {
            ReloadAnimation = false;

        }
    }
    public void BasicAttack() 
    {
        if (BasicWaterAttack) 
        {
            for (int i = 0; i < WaterPointToShoot.Length; i++) 
            {
                GameObject projectile = Instantiate(_waterAttack, WaterPointToShoot[i].transform.position, transform.rotation);
                projectile.GetComponent<Rigidbody2D>().AddForce(WaterPointToShoot[i].up * FireForce, ForceMode2D.Impulse);
                if (i >= WaterPointToShoot.Length) 
                {
                    i = 0;
                  
                }
            }
        }
    }
    void Animations() 
    {
        animation.SetBool("ShootGranate", GranateAnimationAttack);
        animation.SetBool("Reload", ReloadAnimation);
        animation.SetBool("Death", health.Death);
    }
    void Death() 
    {
        bloodScale = Mathf.Clamp(bloodScale, 0.1f, 1f);
        if (health.Death) 
        {
            bloodScale += Time.deltaTime;
            Blood.SetActive(true);
            Blood.transform.localScale = new Vector3(bloodScale, bloodScale, 1f);
        }
    }
}
