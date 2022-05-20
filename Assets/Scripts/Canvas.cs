using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    GameManager manager;

    public GameObject Pause;
    //Room room;
    //EnemyGenerator generator;

    //public Image[] Boss1StoryBoard;
    //public Image[] Boss2StoryBoard;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        //room = FindObjectOfType<Room>();
        //generator = FindObjectOfType<EnemyGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        MenuPause();
    }
    void MenuPause() 
    {
        if (manager.GamePuase)
        {
            Pause.SetActive(true);
        }
        else if(!manager.GamePuase ) 
        {
            Pause.SetActive(false);
        }
    }
         
    //void StoryBoardBoss()
    //{
    //    //if(room.Levels == 1 && generator.BossInMap.Length == 1)
    //    //{

    //    //}
    //}


}
