using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Wine : MonoBehaviour
{
    [SerializeField] int life = 2;
    [SerializeField] GameObject wine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var Gold = Random.Range(1, 3);
        if (life <= 0) 
        {
            GameManager.PlayerGold += Gold;
            wine.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.GetComponent<Elements>().SpellElement == "Fuego" && collision.collider.GetComponent<Elements>() != null)
        //{
        //    life = 0;
        //}
        if (collision.collider.CompareTag("EnemyBullets") || collision.collider.CompareTag("Bullets"))
        {
            life--;
            Destroy(collision.collider.gameObject);
        }
    }

}
