using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorialScript : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float Speed;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpellShoot();
    }
    private void FixedUpdate()
    {
        Move();

    }
    void SpellShoot() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Normal();
        }
    }
    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY);

        //mousePosition = camera;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rb.velocity = moveDirection * Speed;

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = aimAngle;
    }
}
