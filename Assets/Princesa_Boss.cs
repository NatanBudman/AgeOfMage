using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princesa_Boss : MonoBehaviour
{
    HealthController health;

    // Start is called before the first frame update
    void Start()
    {
    
        health = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (health.Death) 
        {
            Room.IsDefeatBoss = true;
        }
    }

}
