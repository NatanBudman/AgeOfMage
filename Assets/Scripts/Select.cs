using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Select : MonoBehaviour
{
    GameManager manager;
    Room room;
    public Transform[] Selected;
    [SerializeField] GameObject Options;
    public Image SelectPosition;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        room = GetComponent<Room>();
        index = 0;
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectPositiom();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && index > 0)
        {
            index--;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && index < Selected.Length)
        {
            index++;
        }
        if (index > Selected.Length)
        {
            index = 0;
        }
        if (index < 0)
        {
            index = Selected.Length;
        }
        SelectOpcions();
    }
    void SelectPositiom()
    {
        if (index < Selected.Length && index >= 0)
        {
            SelectPosition.transform.position = Selected[index].transform.position;

        }
    }

    public void PauseEnable() 
    {
        index = 0;
        if (index == 0 && Options.activeSelf == false) 
        {
            manager.IsGamePause(false);
        }
    }
    public void OptionsEnable() 
    {
        index = 1;
        if (index == 1 && Options.activeSelf == false)
        {
            Options.SetActive(true);
        }
    }
    public void ExitMenu() 
    {
        index = 2;
        if (index == 2 && Options.activeSelf == false)
        {
            SceneManager.LoadScene("Menu");
        }
    }
    void SelectOpcions() 
    {
        switch (index) 
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Return))
                    manager.IsGamePause(false);
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Return))
                    Options.SetActive(true);
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Return)) 
                    SceneManager.LoadScene("Menu");
                break;
        }
    }
}
