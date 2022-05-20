using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public Button Continue_Buttom;
    public GameObject Opcion;
    // Start is called before the first frame update
    void Start()
    {
        Opcion.SetActive(false);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Level") >= 1 )
        {
            Continue_Buttom.interactable = true;
        }
        else 
        {
            Continue_Buttom.interactable = false;
        }
    }
    public void Continue() 
    {
        SceneManager.LoadScene("Level1");
    }
    void DaleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
    public void StarCampaing() 
    {
        DaleteSave();
        SceneManager.LoadScene("StoryBoard");
    }
    public void Exit() 
    {
        Application.Quit();
    }
    public void EnableOpcion() 
    {
        if (Opcion.activeSelf == true)
        {
            Opcion.SetActive(false);
        }
        else 
        {
            Opcion.SetActive(true);
        }
    }
   
}
