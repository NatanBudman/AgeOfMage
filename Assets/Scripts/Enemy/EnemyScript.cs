using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyScript : MonoBehaviour
{
    HealthController heatlh;
    PlayerController playerScript;
  
    State state;
    public GameObject player;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;

    public GameObject[] DeathItems;
    [SerializeField] private BoxCollider2D[] Colliders;
    public float Damage;
    string TagName;
 

    public bool IsLongRange;

    public float RangeShoot;
  

    public bool chasePlayer = true;

    public bool Encantado;

    public bool death;

    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<State>();

        player = GameObject.FindGameObjectWithTag("PJ");

        playerScript = FindObjectOfType<PlayerController>();

        heatlh = GetComponent<HealthController>();

        rb = GetComponent<Rigidbody2D>();

        Colliders = GetComponentsInChildren<BoxCollider2D>();

 
    }

    // Update is called once per frame
    void Update()
    {
    
        Mechanics();
    }
    public void Mechanics() 
    {
        ChasePlayer();
        Death();
        if (Encantado == false)
        {
            SeePlayer(player);
        }
        //else if(Encantado == true && Skeleton)
        //{
        //    var ramdom = (int)Random.Range(0, generator.GoblinsInMap.Length);

        //    float distance = Vector2.Distance(this.transform.position, generator.GoblinsInMap[ramdom].transform.position);
        //    state.EnchantEnemy(5, ramdom);
        //    SeePlayer(generator.GoblinsInMap[ramdom]);
        //}
    }
    public void ChasePlayer() 
    {
       
        if (IsLongRange) 
        {
            // distancia de disparo
            if (Vector2.Distance(transform.position, player.transform.position) <= RangeShoot)
            {
                chasePlayer = false;
            }
            else 
            {
                chasePlayer = true;
            }
        }
        if (chasePlayer ) 
        {
            Vector2 objetive = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position,objetive,state.Speed * Time.deltaTime);
            rb.MovePosition(newPos);
        }
     

    }
   
    void SeePlayer(GameObject See) 
    {
        Vector2 lookDir = See.transform.position - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;

        rb.rotation = angle;
    }

    public void Death() 
    {
        var PosibilitySpawnItem = (int)Random.Range(0,5);
        var Item = (int)Random.Range(0,DeathItems.Length);
       if (heatlh.Death == true) 
        {
            for (int i = 0; i < Colliders.Length; i++) 
            {
                Colliders[i].enabled = false;
            }
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            sprite.sortingLayerName = "Default";
            sprite.sortingOrder = 3;
            death = true;
           
            if (PosibilitySpawnItem == 1) 
            {
                Instantiate(DeathItems[Item], transform.position, Quaternion.identity);
            }
            this.GetComponent<EnemyScript>().enabled = false;
           
        }

 
    }
    public void DestroyObject() 
    {
        Destroy(gameObject);
    }
    public void TakeHit(float Damage) 
    {
        heatlh.GetDamage(Damage);
        StartCoroutine(FlashRed());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.tag == "Bullets")
        //{
        //    StartCoroutine(FlashRed());
        //}
        if (other.collider.tag == "PJ")
        {
            if (!playerScript.Invensibility) 
            {
                other.collider.GetComponent<HealthController>().GetDamage(Damage);
                playerScript.Invensibility = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TagName = null;
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
 
}
