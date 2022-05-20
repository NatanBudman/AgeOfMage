using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class PlayerController : MonoBehaviour
{
    BarraDeVida Mana;
    HealthController health;
    Room level;
    State state;
    GameManager game;
    public Animator animation;
    private TimeManager timemanager;

    //public Camera sceneCamera;
    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    //[SerializeField] private Camera Maincamera;
    public Rigidbody2D rb;


    private Vector2 moveDirection;
    private Vector2 mousePosition;

    public Weapon weapon;

    int Spell = 1;

   

    public int SpellPower = 1;

    public bool Invensibility = false;
    float CoolwdownInvensibility = 0;
    string TagName;

    bool PlayerBurning = false;
    // Start is called before the first frame update
    private void Awake()
    {
   
    }
    void Start()
    {
      
        Mana = FindObjectOfType<BarraDeVida>();
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        StartCoroutine(time());
        state = GetComponent<State>();
        level = FindObjectOfType<Room>();
        health = GetComponent<HealthController>();
        game = FindObjectOfType<GameManager>();
        //enemy = GetComponent<EnemyScript>() ;

        transform.position = game.SpawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        StatesEnable();
        PlayerMechanics();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }


        //if (Input.GetKeyDown(KeyCode.Q) && Mana.CurrentMana >= 50) //Stop Time when Q is pressed
        //{
        //    Mana.CurrentMana -= 50;
        //    timemanager.StopTime();
        //}
        //if (Input.GetKeyDown(KeyCode.E) && timemanager.TimeIsStopped)  //Continue Time when E is pressed
        //{
        //    timemanager.ContinueTime();

        //}

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        animation.SetFloat("Y", moveY);
        animation.SetFloat("X", moveX);

        if (Input.GetMouseButtonDown(0) && Mana.CurrentMana >= Weapon.SpellCost)
        {
            weapon.Fire();
            Mana.CurrentMana -= Weapon.SpellCost;

        }

        //if (Input.GetMouseButtonDown(1) && Mana.CurrentMana >= weapon.SpellCost)
        //{
        //    weapon.Fire2();
        //    Mana.CurrentMana -= weapon.SpellCost;
        //}

        //if (Input.GetKeyDown(KeyCode.K) && Mana.CurrentMana >= weapon.SpellCost)
        //{
        //    weapon.Fire3();
        //    Mana.CurrentMana -= weapon.SpellCost;
        //}

        moveDirection = new Vector2(moveX, moveY);

        //mousePosition = camera;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    void Move()
    {
        rb.velocity = moveDirection * state.Speed;

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = aimAngle;
    }
    // PlayerMechanics Guarda todas las habiliadades y mecanicas del palyer
    void PlayerMechanics() 
    {
        ProcessInput();
        InvensibilityOff();
        death();
        Dash();
    }
    void Dash() 
    {
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = state.Speed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
    void death() 
    {
        if (health.Death == true) 
        {
            transform.position = game.SpawnPoint.position;
            SceneManager.LoadScene("Lose");
            health.currentLife = health.MaxLife;
        }
    }

    void StatesEnable() 
    {
        // estado  quemado
        if (health.burningState) 
        {
            health.burning(5, 10);
        }

        
    }
    void InvensibilityOff() 
    {
        if (Invensibility == true)
        {
            CoolwdownInvensibility += Time.deltaTime;
            if (CoolwdownInvensibility > 3)
            {
                InvensibilityOn(false);

            }
        }
        if (Invensibility == false)
        {
            CoolwdownInvensibility = 0;
        }
    }
    void InvensibilityOn(bool On) 
    {
      
        if (On == true ) 
        {
            Invensibility = true;
            
        }else if (On == false) 
        {
            Invensibility = false;
        }

  
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TagName = collision.gameObject.tag;

        if (Invensibility == false)
        {

            if (TagName == "EnemyBullets")
            {
                health.GetDamage(25);
                InvensibilityOn(true);
            }
        }

        if (TagName == "PocionHealth") 
        {
            health.CureLife(25);
        }
        if (TagName == "ManaPotion")
        {
            Mana.CurrentMana += 50;
        }

    }

    IEnumerator time()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (Mana.CurrentMana < Mana.MaxMana)
            {
                Mana.CurrentMana += 1f;
            }
        }
    }
}
