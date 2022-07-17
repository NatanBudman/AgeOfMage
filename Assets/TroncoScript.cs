using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class TroncoScript : MonoBehaviour
{
    [SerializeField] GameObject TroncoTirado;
    [SerializeField] float life;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0) 
        {
            TroncoTirado.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.collider.GetComponent<Elements>().SpellElement == "Fuego") 
        //{
        //    life = 0;
        //}
        if (collision.collider.CompareTag("EnemyBullets") || collision.collider.CompareTag("Bullets"))
        {
            life--;
            Destroy(collision.collider.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullets")) 
        {
            life--;
            Destroy(collision.gameObject);

        }
    }
}
