using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private Animator animation;
    [SerializeField] private GameObject[] lights;
    public bool Open = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        animation.SetBool("Open", Open);

        for (int i = 0; i < lights.Length; i++) 
        {
            if (Open == false)
            {
                lights[i].SetActive(true);
            }
            else 
            {
                lights[i].SetActive(false);
            }
        }
        
    }
    
    public void AnimatedDoor()
    {
        Open = false;

    }
}
