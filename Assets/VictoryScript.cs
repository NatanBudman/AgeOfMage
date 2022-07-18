using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    [SerializeField] float TimeMenu;
    float currentTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= TimeMenu) 
        {
            LevelLoader.LoadLevel("Menu");
        }
    }
}
