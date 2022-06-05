using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    [SerializeField] private Transform PosMove;
    [SerializeField] private GameObject DropPoint;
    [SerializeField] private GameObject Gas;
    [SerializeField] private float FireForce;
    [SerializeField] private Rigidbody2D rb;
    
    GameObject Player;
    float ScaleMaX;
    float ScaleMaxY;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PJ");

        DropPoint.transform.position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 objetive = new Vector2(DropPoint.transform.position.x, DropPoint.transform.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, objetive, FireForce * Time.deltaTime);
        rb.MovePosition(newPos);
        DropScale();
        hitsFloor();

    }
    void hitsFloor() 
    {
        if (DropPoint.transform.position == transform.position) 
        {
            Instantiate(Gas, transform.position, Quaternion.identity);
            Destroy(DropPoint);
            Destroy(gameObject);
        }
    }
    void DropScale() 
    {
        ScaleMaX = DropPoint.transform.position.x - transform.position.x;
        
        ScaleMaX = Mathf.Clamp(ScaleMaX,2f, 10f);
     
        Vector3 newScale = new Vector3(ScaleMaX, ScaleMaX, 1f);
        DropPoint.transform.localScale = newScale;
    }
}
