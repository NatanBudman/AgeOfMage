using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    HealthController health;
    EnemyScript enemy;
    public Animator animation;
    public bool Attacking;
    public BoxCollider2D AttackCollider;
    [SerializeField] private bool AttackColliderEnable;
    public GameObject[] SlimesInstantiate;
    [SerializeField] private float RangeAttack;
    [SerializeField] private float CoolwDownAttack;
    [SerializeField] private bool MiniSlime;
    float currenTimeAttack;

    [SerializeField] private GameObject Parent;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        health = GetComponent<HealthController>();
        Parent = GameObject.FindGameObjectWithTag("SlimeParent");
    }

    // Update is called once per frame
    void Update()
    {
        currenTimeAttack += Time.deltaTime;
        Attack();
        BeDivided();
        Animations();
    }
    void Attack() 
    {
        if (Vector2.Distance(enemy.player.transform.position, transform.position) < RangeAttack) 
        {
            if (currenTimeAttack > CoolwDownAttack && !health.Death) 
            {
                Attacking = true;
                currenTimeAttack = 0;
            }
        }
        if (AttackColliderEnable && AttackCollider != null)
        {
            AttackCollider.enabled = true;
        }
        else if(!AttackColliderEnable && AttackCollider != null)
        {
            AttackCollider.enabled = false;

        }
    }
    void Animations() 
    {
        animation.SetBool("Attacking", Attacking);
    }
    void BeDivided() 
    {
  
        if (health.Death) 
        {
            if (!MiniSlime) 
            {
                SlimesInstantiate[0].SetActive(true);
                SlimesInstantiate[1].SetActive(true);
                SlimesInstantiate[0].transform.SetParent(Parent.transform);
                SlimesInstantiate[1].transform.SetParent(Parent.transform);
                Destroy(gameObject);
            }
        }
    }
}
