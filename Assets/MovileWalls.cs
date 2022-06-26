using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovileWalls : MonoBehaviour
{
    [SerializeField] bool HorizontalMov;
    [SerializeField] bool VerticalMov;
    [SerializeField] float Speed;
    [SerializeField] Transform position1;
    [SerializeField] Transform position2;
    [SerializeField] Rigidbody2D _rb;
    bool changeDir = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HorizontalMov) 
        {
            if (changeDir) 
            {
                Vector2 objetive = new Vector2(position1.position.x, transform.position.y);
                Vector2 newPos = Vector2.MoveTowards(_rb.position, objetive, Speed * Time.deltaTime);
                _rb.MovePosition(newPos);
            }

                if(transform.position.x == position1.position.x) 
                {
                    changeDir = false;
                }

            if (!changeDir)
            {
                Vector2 objetive = new Vector2(position2.position.x, transform.position.y);
                Vector2 newPos = Vector2.MoveTowards(_rb.position, objetive, Speed * Time.deltaTime);
                _rb.MovePosition(newPos);

            }
                if (transform.position.x == position2.position.x)
                {
                    changeDir = true;
                }
        }
        if (VerticalMov) 
        {
            if (changeDir)
            {
                Vector2 objetive = new Vector2(transform.position.x, position1.position.y);
                Vector2 newPos = Vector2.MoveTowards(_rb.position, objetive, Speed * Time.deltaTime);
                _rb.MovePosition(newPos);
            }

            if (transform.position.y == position1.position.y)
            {
                changeDir = false;
            }

            if (!changeDir)
            {
                Vector2 objetive = new Vector2(transform.position.x, position2.position.y);
                Vector2 newPos = Vector2.MoveTowards(_rb.position, objetive, Speed * Time.deltaTime);
                _rb.MovePosition(newPos);

            }
            if (transform.position.y == position2.position.y)
            {
                changeDir = true;
            }
        }
    }
}
