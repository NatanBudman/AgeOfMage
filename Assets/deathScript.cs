using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScript : MonoBehaviour
{
    HealthController heatlh;

    // Start is called before the first frame update
    void Start()
    {
        heatlh = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (heatlh.Death)
        {
            Room.IsDefeatBoss = true;
        }
    }
}
