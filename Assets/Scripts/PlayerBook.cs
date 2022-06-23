using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBook : MonoBehaviour
{
    public float maxSpeed;
    public float Speed;
    public GameObject Book;
    public bool Up = false;

    // Start is called before the first frame update
    void Update()
    {
        BookRotate();
        UpTransform();
    }

    void BookRotate()
    {
        Speed += Time.deltaTime;
        Speed = Mathf.Clamp(Speed, 0, maxSpeed);
        if (!Up)
        {
            Book.transform.Rotate(Book.transform.rotation.x, Book.transform.rotation.y, Speed);
        }
    }
    void UpTransform()
    {
        if (Up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Speed * Time.deltaTime);
            Book.transform.Rotate(0, 0, 0);
        }
    }
}
