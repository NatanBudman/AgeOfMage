using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Text Interface;
    private TimeManager timemanager;
    private bool EscobazoAnim;

    //public Camera sceneCamera;
    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = .5f, dashCooldown = 1f;
    private float dashTime = 0.5f;

    private Coroutine dashing;

    private float dashCounter;
    private float dashCoolCounter;

    //[SerializeField] private Camera Maincamera;
    public Rigidbody2D rb;


    public bool TakeLifePotion;
    public bool TakeManaPotion;

    private Vector2 moveDirection;
    private Vector2 mousePosition;

    public Weapon weapon;

    int Spell = 1;


    public int SpellPower = 1;

    public bool Invensibility = false;
    float CoolwdownInvensibility = 0;
    string TagName;

    bool PlayerBurning = false;

    public bool hasEarth;
    public bool hasHeal;
    private void Awake()
    {
        Interface.gameObject.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.Space) && dashing == null && Mana.CurrentMana >= 10)
        {
            dashing = StartCoroutine(DashCoroutine());
            Mana.CurrentMana -= 10;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            weapon.Melee();
            EscobazoAnim = true;
        }
        else
        {
            EscobazoAnim = false;
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        animation.SetFloat("Y", moveY);
        animation.SetFloat("X", moveX);
        animation.SetBool("IsAttacking", EscobazoAnim);

        if (Input.GetMouseButtonDown(0) && Mana.CurrentMana >= Weapon.SpellCost && !game.GamePuase)
        {
            weapon.Fire();
            Mana.CurrentMana -= Weapon.SpellCost;

        }
        moveDirection = new Vector2(moveX, moveY);

        //mousePosition = camera;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    private IEnumerator DashCoroutine()
    {
        var endOfFrame = new WaitForEndOfFrame();

        for (float timer = 0; timer < dashTime; timer += Time.deltaTime)
        {
            rb.MovePosition(transform.position - (transform.up * (dashSpeed * Time.deltaTime)));

            yield return endOfFrame;
        }

        dashing = null;
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

        if (On == true)
        {
            Invensibility = true;

        }
        else if (On == false)
        {
            Invensibility = false;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        TagName = collision.gameObject.tag;
        if (TagName == "Enemy" && collision.GetComponent<HealthController>().Death == true)
        {
            Interface.gameObject.transform.position = collision.GetComponent<EnemyScript>().gameObject.transform.position;
            Interface.gameObject.transform.rotation = new Quaternion(0,0,0f,0f);
            Interface.gameObject.SetActive(true);
            Interface.text = "F";
        }
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
            TakeLifePotion = true;

        }
        if (TagName == "ManaPotion")
        {
            TakeManaPotion = true;
            Mana.CurrentMana += 50;
        }
        if (TagName == "Gold")
        {
            int Gold = Random.Range(1, 5);
            GameManager.GetGold(Gold);

        }

    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        Interface.gameObject.SetActive(false);
        
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
