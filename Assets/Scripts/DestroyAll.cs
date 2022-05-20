using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{

    public float TimeToDestroy;
    private void Start()
    {

        Destroy(gameObject, TimeToDestroy);
    }

    private void Update()
    {
      
          
        
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PJ") || collision.gameObject.CompareTag("Wall")) 
        {
            Destroy(gameObject);
        }
    }
}
