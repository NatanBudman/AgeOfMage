using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBook : MonoBehaviour
{
    public float maxSpeed;
    public float SpeedRotate;
    public GameObject Book;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BookRotate();
    }

    void BookRotate() 
    {
        
        SpeedRotate += Time.deltaTime;
        SpeedRotate = Mathf.Clamp(SpeedRotate, 0, maxSpeed);
        Book.transform.Rotate(Book.transform.rotation.x, Book.transform.rotation.y,  SpeedRotate);
    }

}
