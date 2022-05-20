using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneTalking : MonoBehaviour
{
    public Animator animation;
    public static bool IsTalkingBone;
    public static bool Standart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animation.SetBool("Talking", IsTalkingBone);
      
    }
}
