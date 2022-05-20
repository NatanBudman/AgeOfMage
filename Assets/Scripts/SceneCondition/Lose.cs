using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public Image Ilumination;

    float transparency = 0;
    void Start()
    {
        Ilumination.color = new Color(255, 255, 255, transparency);
    }
    void Update()
    {
        Ilumination.color = new Color(255, 255, 255, transparency);
        transparency += 0.3f * Time.deltaTime;
    }
    public void Restart() 
    {
        SceneManager.LoadScene("Level1");
    }
    public void Exit() 
    {
        Application.Quit();
    } 
}
