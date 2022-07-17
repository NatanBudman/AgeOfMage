using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasBoss : MonoBehaviour
{
    PlayerController playerScript;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private BoxCollider2D collider;
    private float Transparency = 0.3f;
    public bool GasHabiliti = true;


    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerController>();
        sprite.color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {

        collider.transform.position = this.transform.position;
        if (GasHabiliti ) 
        {
            Timer += Time.deltaTime;
            Transparency += Time.deltaTime;

            if (Timer >= 8) 
            {
                GasHabiliti = false;
                Timer = 0;
            }
       
        }
        else if (!GasHabiliti)
        {
            Transparency -= Time.deltaTime;

            if (Transparency <= 0) 
            {
                Destroy(gameObject);
            }
        }

        sprite.color = new Color(255, 255, 255, Transparency);
    }

    //private void OnCollisionStay2D(Collision2D other)
    //{

    //    if (other.collider.tag == "PJ")
    //    {
    //        if (!playerScript.Invensibility)
    //        {
    //            other.collider.GetComponent<HealthController>().GetDamage(12);
    //            playerScript.Invensibility = true;
    //        }
    //    }
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PJ")
        {
            //if (!playerScript.Invensibility)
            //{
            //collision.GetComponent<State>().Slow(15);if
            if (collision.GetComponent<HealthController>().DurationBurning <= 0) 
            {
               collision.GetComponent<HealthController>().DurationBurning = 1;
            }
            //playerScript.Invensibility = true;
            //}
        }

        if (collision.gameObject.GetComponent<Elements>().SpellElement == "Agua" && collision.gameObject.GetComponent<EnemyScript>() == null && collision.tag != "EnemyBullets") 
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PJ") 
        {
                if (collision.GetComponent<HealthController>() != null)
                   collision.GetComponent<HealthController>().DurationBurning = 0;
        }
    }

}
