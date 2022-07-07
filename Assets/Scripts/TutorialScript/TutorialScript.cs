using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] HealthController enemy;
    [SerializeField] GameObject[] ItemsToActivate;
    [SerializeField] bool IsCompleteFirstObjetive;
    [SerializeField] bool IsCompleteSecondObjetive;
    [SerializeField] bool IsCompleteThreeObjetive;
    [SerializeField] bool IsCompleteFourObjetive;
    [SerializeField] bool IsCompleteFiveObjetive;
    bool W = false;
    bool S = false;
    bool D = false;
    bool A = false;
    bool Shoot = false;
    int count = 0;
    float currenTimeThreeObjetive;
    float currenTimeFourObjetive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        firstObjetive();
        SecondtObjetive();
        ThreeObjetive();
        FourObjetive();
        FiveObjetive();
        SixObjetive();
    }
    private void firstObjetive()
    {
        if (IsCompleteFirstObjetive) 
        {
            ItemsToActivate[0].SetActive(false);
            ItemsToActivate[1].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.W)) { W = true; }
        if (Input.GetKeyDown(KeyCode.A)) { A = true; }
        if (Input.GetKeyDown(KeyCode.S)) { S = true; }
        if (Input.GetKeyDown(KeyCode.D)) { D = true; }
        if(W == true && S == true && D == true && A == true) 
        {
            IsCompleteFirstObjetive = true;
        }

    }
    private void SecondtObjetive() 
    {
        if (IsCompleteSecondObjetive)
        {
            ItemsToActivate[1].SetActive(false);
            ItemsToActivate[2].SetActive(true);
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            count++;
        }
        if (count >= 5) 
        {
            IsCompleteSecondObjetive = true;
        }
    }
    private void ThreeObjetive() 
    {
        if (IsCompleteSecondObjetive == true && IsCompleteThreeObjetive == false) 
        {
            currenTimeThreeObjetive += Time.deltaTime;
        }
        if (currenTimeThreeObjetive >= 8) 
        {
            IsCompleteThreeObjetive = true;
        }
        if (IsCompleteThreeObjetive) 
        {
            ItemsToActivate[2].SetActive(false);
            ItemsToActivate[3].SetActive(true);
        }
    }
    private void FourObjetive() 
    {
        if (IsCompleteFourObjetive) 
        {
            ItemsToActivate[3].SetActive(false);
            ItemsToActivate[4].SetActive(true);
        }
        if (IsCompleteThreeObjetive == true && IsCompleteFourObjetive == false) 
        {
            currenTimeFourObjetive += Time.deltaTime;
        }
        if (currenTimeFourObjetive > 5) 
        {
            IsCompleteFourObjetive = true;
        }
    }
    private void FiveObjetive() 
    {
        if (IsCompleteFiveObjetive) 
        {
            ItemsToActivate[5].SetActive(true);
        }
        if (IsCompleteFiveObjetive == false) 
        {
            if (enemy.Death == true) 
            {
                IsCompleteFiveObjetive = true;
            }
        }
    }
    private void SixObjetive() 
    {
        if (enemy == null) 
        {
            LevelLoader.LoadLevel("Menu");
        }
    }
}
