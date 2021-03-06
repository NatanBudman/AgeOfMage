using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class ProtectedZoneScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    float Transparencity;
    bool IsPlayerInZone;
   [SerializeField] bool IsEnemyInZone;
    public float SpeedBarLoad;
    [SerializeField]bool IsZoneLoad;
    [SerializeField] Image BarLoad;
    //[SerializeField] SpriteRenderer BarLoadSprite;
    public float BarAmount;
    [SerializeField] GameObject EnableNextObject;
    public float CurrentAmount = 0;
    public bool IsComplete;
    float MaxSpeed;
    float n;
    // Start is called before the first frame update
    void Start()
    {
        MaxSpeed = SpeedBarLoad;
        n = SpeedBarLoad - 1;
    }

    // Update is called once per frame
    void Update()
    {
        Transparencity = Mathf.Clamp(Transparencity, 0.09f, 1f);
        sprite.color = new Color(0, 109, 255, Transparencity);
        //BarLoadSprite.color = new Color(0, 109, 255, Transparencity);

        if (IsPlayerInZone) 
        {
            Transparencity += 0.3f * Time.deltaTime;
        }
        else if(!IsPlayerInZone && !IsComplete)
        {
            Transparencity -= 0.3f * Time.deltaTime;

        }

        if (IsZoneLoad && !IsComplete) 
        {
            CurrentAmount += SpeedBarLoad *Time.deltaTime;
        }
        else if(!IsZoneLoad && !IsComplete)
        {
            CurrentAmount -=  2f * Time.deltaTime;

        }

        if(CurrentAmount >= BarAmount) 
        {
            CurrentAmount = BarAmount;
            IsComplete = true;
        }
        if (IsComplete) 
        {
            EnableNextObject.SetActive(true);
        }
        if (IsEnemyInZone == true)
        {
            SpeedBarLoad = n;
        }
        else
        {
            SpeedBarLoad = MaxSpeed;
        }
        BarLoad.fillAmount = CurrentAmount / BarAmount;

        CurrentAmount = Mathf.Clamp(CurrentAmount, 0, BarAmount);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("PJ")) 
        {
            IsPlayerInZone = true;
            IsZoneLoad = true;
        }
        if (collision.CompareTag("Enemy") && collision.GetComponent<HealthController>().Death == false && collision.GetComponent<EnemyScript>())
        {
      
            IsEnemyInZone = true;
        }
        else if(collision.CompareTag("Enemy") && collision.GetComponent<HealthController>().Death == true && collision.GetComponent<EnemyScript>())
        {
            IsEnemyInZone = false;
        }

    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsPlayerInZone = false;
        IsZoneLoad = false;
        IsEnemyInZone = false;

    }
}
