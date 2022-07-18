using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    // Start is called before the first frame update

    EnemyScript enemy;
   

    [SerializeField] private GameObject GoblinBlood;

    [SerializeField] private Animator animation;

    [SerializeField] private Collider2D attackCollider;
    [SerializeField] private Collider2D colliders;

    public float RangeAttack;
    public float coolwDownAttack;
    private float AttackCurrentTime;
    float BloodScale = 0;
    bool Attacking = false;
    void Start()
    {

        enemy = GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        BloodScale = Mathf.Clamp(BloodScale,0,1);
        if (!enemy.death) 
        {
            attack();
        }
            AnimationsEnemy();
        deathGoblin();
    }
    void attack()
    {
        AttackCurrentTime += Time.deltaTime;

        if (Vector2.Distance(transform.position, enemy.player.transform.position) <= RangeAttack)
        {

            if (coolwDownAttack <= AttackCurrentTime)
            {
                Attacking = true;
                animation.SetTrigger("Attack");
                enemy.chasePlayer = false;
                AttackCurrentTime = 0;
            }
            else 
            {
                enemy.chasePlayer = true;
            }
        }
        else
        {
            Attacking = false;
        }

        if (!Attacking)
        {
            attackCollider.enabled = false;
        }
        else 
        {
            attackCollider.enabled = true;
        }
    }
    void deathGoblin() 
    {
        if (enemy.death == true) 
        {
            BloodScale += Time.deltaTime;
            GoblinBlood.SetActive(true);
            GoblinBlood.transform.localScale = new Vector3( BloodScale,BloodScale) ;
          
        }
    }
    void AnimationsEnemy()
    {
        if (!enemy.death) 
        {
            animation.SetBool("Chase", enemy.chasePlayer);
        }
        animation.SetBool("Death", enemy.death);

    }
}
