using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    State state;
    public float MaxLife;
    public float currentLife;

    public  float burningTime;

    public bool burningState;

    public bool Death = false;

    float CooldownPerSeconds;
    float TimePerSecond;
    public  float DamageReduction = 0;
    public float DamageIncrement = 0;

    public float DurationBurning;
    public string Element;
    string SpellElement;
    float currentSpell;
    float DamagePerSeconds;
    bool TimeDamage;
    // Start is called before the first frame update
    void Start()
    {
        state = FindObjectOfType<State>();
        currentLife = MaxLife;
    }

    private void Update()
    {
        Revive();
        IfDeath();
        DeathAction();
        Burning();
        ReductionElements();
    }

    void DeathAction() 
    {
        if (currentLife <= 0)
        {
            Death = true;
        }
    }
    public void GetDamage(float damage) 
    {
        ReductionElements();
        currentLife -= damage + DamageIncrement - DamageReduction * damage / 100;
    }
    void ReductionElements() 
    {
        // Toma el elemento del ataque y verifica la diferencia de daño
        if (SpellElement != "Null") 
        {
            currentSpell += Time.deltaTime;
            if (currentSpell > 1.5f) 
            {
                SpellElement = "Null";
                currentSpell = 0;
            }
        }
        if (Element == "" || SpellElement == "") 
        {
            Element = "Null";
            SpellElement = "Null";
        }
        if (Element == "Null" || SpellElement == "Null") 
        {
            DamageReduction = 0;
            DamageIncrement = 0;
        }
        if (SpellElement == "Tierra")
        {
            if (Element == "Aguas")
            {
                DamageReduction = 15;
            }
            if (Element == "Aire")
            {
                DamageReduction = 15;
            }
            if (Element == "Fuego")
            {
                DamageReduction = 30;
            }
        }
        if (SpellElement == "Aire")
        {
            if (Element == "Aguas")
            {
                DamageReduction = 10;
            }
            if (Element == "Tierra")
            {
                DamageReduction = 15;
            }

            if (Element == "Fuego")
            {
                DamageReduction = 0;
            }
        }
        if (SpellElement == "Fuego")
        {
            if (Element == "Aguas")
            {
                DamageReduction = 30;
            }
            if (Element == "Tierra")
            {
                DamageReduction = 15;
            }

            if (Element == "Aire")
            {
                DamageReduction = 0;
            }
        }
        if (SpellElement == "Agua")
        {
            if (Element == "Fuego")
            {
                DamageIncrement = 15;
            }
            if (Element == "Tierra")
            {
                DamageReduction = 30;
            }

            if (Element == "Aire")
            {
                DamageReduction = 10;
            }
        }

        if (SpellElement == "Agua" || Element == "Agua")
        {
            DurationBurning = 0;
        }
        if (SpellElement == "Fuego") 
        {
            DurationBurning = 2;
         
        }
    }
    void Revive() 
    {
         if (currentLife >= 1)
        {
            Death = false;
        }
        if( currentLife >= MaxLife) 
        {
            currentLife = MaxLife;
        }
    }
    void IfDeath() 
    {
        
        if (Death) 
        {
            Destroy(gameObject, 10);
        }
    }
    public void CureLife(float Cure) 
    {
        currentLife += Cure;
    }
    public void burning(float TakingDamagePerSeconds, float Duration) 
    {
        DurationBurning = Duration;
        DamagePerSeconds = TakingDamagePerSeconds;
       // if (state.ThisIsPlayer) 
       // {
       //     Element = "Fuego";
       //     state.PlayerState.text = "Burning";
       //     state.PlayerFire = true;
       //     state.PlayerState.color = new Color(255, 0, 0);
       // }


        // TimePerSecond += Time.deltaTime;
        //burningTime = (int)TimePerSecond;

        // if (burningTime < DurationBurning)
        // {
        //     state.PlayerFire = true;
        //     burningState = true;
        //     currentLife -= DamagePerSeconds;
        // }
        // else 
        // {
        //     state.PlayerFire = false;
        //     burningState = false;
        // }


    }
    private void Burning() 
    {
        if (state.ThisIsPlayer && burningTime < DurationBurning)
        {
            Element = "Fuego";
            state.PlayerState.text = "Burning";
            state.PlayerFire = true;
            state.PlayerState.color = new Color(255, 0, 0);
        }

  

        if (burningTime < DurationBurning)
        {
            TimePerSecond += Time.deltaTime;
            burningTime = (int)TimePerSecond;
            //DamagePerSeconds = 1;
            if (burningTime / 2 == 0 )
            {
                TimeDamage = true;
                if (TimeDamage == true) 
                {
                    StartCoroutine(GetDamangePerSeconds());
                    TimeDamage = false;
            
                }
                if (!TimeDamage)
                {
                    DamagePerSeconds = 0f;
                    StopCoroutine(GetDamangePerSeconds());
                }
            }
          

            //StopCoroutine(GetDamangePerSeconds());
            state.PlayerFire = true;
            burningState = true;
            
        }
        else
        {
            StopCoroutine(GetDamangePerSeconds());
            TimePerSecond = 0;
            DurationBurning = 0;
            burningTime = 0;
            state.PlayerFire = false;
            burningState = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        //Element = collision.collider.gameObject.GetComponent<Elements>().SpellElement;
        if (collision.collider.GetComponent<Elements>() != null)
        {
            SpellElement = collision.collider.GetComponent<Elements>().SpellElement;
        }
     
        
        if(SpellElement == "" || SpellElement == "Null") 
        {
            SpellElement = "Null";
        }
        
    }
    public IEnumerator GetDamangePerSeconds()
    {
        DamagePerSeconds = 0.1f;
        currentLife -= DamagePerSeconds;
        yield return new WaitForSeconds(0.001f);
       

    }
}
