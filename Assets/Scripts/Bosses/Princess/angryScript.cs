using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angryScript : MonoBehaviour
{

    public HealthController heatlh;
    public ParticleSystem angryEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (heatlh.currentLife <= 1199)
        {
            angryEffect.Play();
        }
    }
}
