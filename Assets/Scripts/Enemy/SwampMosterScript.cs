using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampMosterScript : MonoBehaviour
{
    HealthController health;
    EnemyScript enemy;
    [SerializeField]private Animator animation;
    [SerializeField]private float _RangeAttack;
    [SerializeField]private float _CoolwDownAttack;
    [SerializeField]private BoxCollider2D AttackCollider;
 
    private float _CurrentTimeAttack;


    public bool Attack;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        health = GetComponent<HealthController>();

        AttackCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _CurrentTimeAttack += Time.deltaTime;
        Mechanics();
    }
    void Mechanics() 
    {
        Animation();
        MonsterAttack();
    }
    void MonsterAttack() 
    {
        if (Vector2.Distance(transform.position, enemy.player.transform.position) < _RangeAttack) 
        {
            if (_CurrentTimeAttack >= _CoolwDownAttack && health.Death == false) 
            {
                Attack = true;
                _CurrentTimeAttack = 0;
            }
        }
        if (Attack)
        {
            AttackCollider.enabled = true;
        }
        else 
        {
            AttackCollider.enabled = false;
        }
    }
    void Animation() 
    {
        animation.SetBool("Move", enemy.chasePlayer);
    }
}
