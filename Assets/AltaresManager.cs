using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltaresManager : MonoBehaviour
{
    [SerializeField] Room Room4;
    [SerializeField]AltarScript[] Altares;

    int finalAltar;
    // Start is called before the first frame update
    void Start()
    {
        finalAltar = Altares.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Altares[0].IsComplete && Altares[0].gameObject.activeSelf == true) 
        {
            Room4.CompleteRoom = true;
        }
    }
}
