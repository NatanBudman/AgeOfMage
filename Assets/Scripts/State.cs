using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class State : MonoBehaviour
{
    HealthController heatl;
    EnemyGenerator generator;
    EnemyScript enemyScript;

    public Text PlayerState;

    public float MaxSpeed;
    public float Speed;

    public bool SlowState;

    float CurrentTime;
    float CurrentTimeEnchant;

    public bool ThisIsPlayer;

    public bool PlayerFire;
    bool Slowed;
    bool Enchanted = false;


    
    // Start is called before the first frame update
    void Start()
    {
        generator = FindObjectOfType<EnemyGenerator>();
        enemyScript = GetComponent<EnemyScript>();
        Speed = MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (ThisIsPlayer)
        {
            StatesSee();
        }
        SlowCondition();
        SpeedRecover();
    }
    void StatesSee() 
    {
     
        if (Speed < MaxSpeed) 
        {
            PlayerState.text = "Slowed";
            PlayerState.color = new Color(0, 0, 255);
        }
        if (!PlayerFire && Speed >= MaxSpeed)
        {
            PlayerState.text = "Normal";
        }
        if (PlayerFire && Speed <= MaxSpeed) 
        {
            PlayerState.text = "Normal";
        }
        if (PlayerState.text == "Normal")
        {
            //heatl.Element = "Null";
            PlayerState.color = new Color(255, 255, 255);
        }
    }

    void SlowCondition() 
    {
        if (Slowed == true)
        {
            CurrentTime += Time.deltaTime;
        }
        if (CurrentTime > 3)
        {
            Slowed = false;
            CurrentTime = 0;
        }
    
    }
    void SpeedRecover() 
    {
        if (Speed <= MaxSpeed)
        {
            Speed += Time.deltaTime;
        }
        if (Speed >= MaxSpeed)
        {
            Slowed = false;
            CurrentTime = 0;
            SlowState = false;
        }
    }

    public void Slow(int SpeedReduction)
    {
        if (ThisIsPlayer) 
        {
     
            Slowed = true;
        }

        CurrentTime += Time.deltaTime;

        Speed = SpeedReduction;
        Slowed = true;
        
    
    }

    //public void EnchantEnemy(float Duration,int goblin ) 
    //{
    //    int Enemy = generator.GoblinsInMap.Length + generator.SkeletonsInMap.Length;
    //    CurrentTimeEnchant += Time.deltaTime;

    //    if (CurrentTimeEnchant < Duration)
    //    {
           
    //       enemyScript.chasePlayer = false;
    //       Vector2 objetive = new Vector2(generator.GoblinsInMap[goblin].transform.position.x, generator.GoblinsInMap[goblin].transform.position.y);
    //       Vector2 newPos = Vector2.MoveTowards(enemyScript.rb.position, objetive, Speed * Time.deltaTime);
    //       enemyScript.rb.MovePosition(newPos);
            
    //    }
    //    else 
    //    {
    //        CurrentTimeEnchant = 0;
    //    }
    //}

   
}
