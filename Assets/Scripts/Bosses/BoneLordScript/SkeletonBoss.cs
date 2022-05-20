using System.Collections;
using System.Collections.Generic;
using UnityEngine.Sprites;
using UnityEngine;

public class SkeletonBoss : MonoBehaviour
{
    HealthController health;
    PlayerController playerScript;
    EnemyScript enemy;
    // Start is called before the first frame update
    [SerializeField] private Animator animation; 
    [SerializeField] private GameObject Portals;
    [SerializeField]private float CoolDownSpawnEnemy;
    [SerializeField] private BoxCollider2D colliderAttack;
    private float CurrentTime;

    public GameObject Skeleton;
    public GameObject Gas;
    public Transform SpawnGas;

    public float RangeAttack;
    public float RangeGasAttack;

    private GameObject Player;

    bool Attack;
    bool Drink;
    bool Eructando;
    public  bool InstanciaGomito;
    private float CurrenTimeGas;
    [SerializeField]private float CoolDownGas;
    private float CurrenTimeAttack;
    [SerializeField] private float CoolDownAttack;

    public bool AttakingCollider;
    float currentGomito;
  
    void Start()
    {
        health = GetComponent<HealthController>();
        playerScript = FindObjectOfType<PlayerController>();
        Player = GameObject.FindGameObjectWithTag("PJ");
        enemy = GetComponent<EnemyScript>();
        colliderAttack.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Mechanics();
    }
    void Mechanics() 
    {
        Animation();
      
        SpawnGas.position = new Vector2(transform.position.x, transform.position.y);


        CurrenTimeAttack += Time.deltaTime;
        CurrentTime += Time.deltaTime;
        CurrenTimeGas += Time.deltaTime;

        if (CurrentTime >= CoolDownSpawnEnemy) 
        {
            CurrentTime = 0;
            GenerateSletons();
        }
        PortalToSpawnSkeletons();
        BossGummy();
        BossAttack();
        IfDeath();





        Debug.DrawLine(transform.position, Vector2.up * RangeGasAttack, color:Color.blue);

 
    }
    void BossGummy() 
    {
        // distancia de ataque
        if (Vector2.Distance(transform.position, Player.transform.position) < RangeGasAttack)
        {
            if (CurrenTimeGas >= CoolDownGas)
            {
                GasAttack();
             
                CurrenTimeGas = 0;
            }
        }

        if (InstanciaGomito)
        {
            Instantiate(Gas, SpawnGas.position, Quaternion.identity);
        }


      
    }
    void IfDeath()
    {
        if (health.Death)
            Destroy(gameObject);
    }
    void BossAttack() 
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < RangeAttack)
        {
            if (CurrenTimeAttack >= CoolDownAttack && CurrenTimeAttack <= CoolDownAttack + 2)
            {
                Attack = true;
                if (Attack)
                CurrenTimeAttack = 0;
            }
            else 
            {
                Attack = false;
                enemy.chasePlayer = true;
            }
        }
       


        if (AttakingCollider)
        {
            EnableColliderAttack();
        }
        else
        {
            DisableColliderAttack();
        }


    }
    public void EnableColliderAttack() 
    {
        colliderAttack.enabled = true;
    }
    public void DisableColliderAttack()
    {
        colliderAttack.enabled = false;
    }
    void PortalToSpawnSkeletons() 
    {
        if (CurrentTime == CoolDownSpawnEnemy - 1 ) 
        {
             Vector2 pos = new Vector2(transform.position.x, transform.position.y + 25);
             Instantiate(Portals, pos, Quaternion.identity);
             Vector2 pos2 = new Vector2(transform.position.x, transform.position.y -25);
             Instantiate(Portals, pos2, Quaternion.identity);
             Vector2 pos3 = new Vector2(transform.position.x - 25, transform.position.y);
             Instantiate(Portals, pos3, Quaternion.identity);
        }

        //if (CurrentTime >= CoolDownSpawnEnemy - 5) 
        //{
        //    Portals.color
        //}
    }
    void Animation() 
    {
        animation.SetBool("Attack", Attack);
        animation.SetBool("Eructando", Eructando);
        //animation.SetBool("Drink", Drink);
    }
    void GasAttack() 
    {
        animation.SetTrigger("Drink");
        Eructando = true;
        Drink = true;
       
    }
    void GenerateSletons() 
    {
       
        Vector2 pos = new Vector2 (transform.position.x,transform.position.y + 25);
        Instantiate(Skeleton, pos, Quaternion.identity);

        Vector2 pos2 = new Vector2(transform.position.x, transform.position.y - 25);
        Instantiate(Skeleton, pos2, Quaternion.identity);

        Vector2 pos3 = new Vector2(transform.position.x - 25, transform.position.y);
        Instantiate(Skeleton, pos3, Quaternion.identity);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PJ")
        {
            if (!playerScript.Invensibility)
            {
   
                collision.GetComponent<HealthController>().GetDamage(25);
                playerScript.Invensibility = true;
            }
        }
    }
    //private void OnCollisionEnter2D(Collision2D other)
    //{

    //    if (other.collider.tag == "PJ")
    //    {
    //        if (!playerScript.Invensibility)
    //        {
    //            other.collider.GetComponent<HealthController>().GetDamage(90);
    //            playerScript.Invensibility = true;
    //        }
    //    }
    //}
}
