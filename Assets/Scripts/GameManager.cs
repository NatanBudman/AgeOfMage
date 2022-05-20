using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text round;

    [SerializeField]public Room[] room;

    [SerializeField] private Image LoadIcon;
    [SerializeField] private Transform LoadIconPosition;

    public  bool GamePuase = false;


    public Transform SpawnPoint;
    public Transform[] newSpawnPoint;

    private int PlayerGold;

    public int index;

    bool InstantiateLoadIcon;
    float CurrentLoadIcon;
    //int countCutScene = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        SpawnPoints();
    }
    void Start()
    {
        Load(); 

        //SpawnPoints();
        room = GetComponentsInChildren<Room>();
       //Load();
       IsGamePause(false);
    }

    

    // Update is called once per frame
    void Update()
    {
        PauseMode();
        AutoSave();
        IconLoad();
        SpawnPoints();
        RoundPlaying();
        CusSceneConditions();
        Debug.Log(room[0].Levels);

        //Debug.Log(countCutScene);
    }
    void SpawnPoints() 
    {
         SpawnPoint.position = newSpawnPoint[room[0].Levels].position;
        
    }
    void RoundPlaying() 
    {

        round.text ="Round: " + room[room[0].Levels].RoundRooms;
    }
    void AutoSave() 
    {
        for (int i = 0; i < room[0].Levels; i++) 
        {
            InstantiateLoadIcon = true;
            index = i;
            Save();
            if (i >= room.Length) 
            {
                i = room.Length;
            }
        }
        if (room[0].Levels == 1) 
        {
            room[0].CompleteLevel = "Complete";
        }
        if (room[0].Levels == 2) 
        {
            room[1].CompleteLevel = "Complete";

        }

    }
    void CusSceneConditions() 
    {
        if (Room.IsBossApears)
        {
            //countCutScene++;
            InstantiateLoadIcon = true;
            Save();
            SceneManager.LoadScene("cutscenes");
        }
  
       if (Room.IsDefeatBoss)
       {
            //countCutScene++;
            InstantiateLoadIcon = true;
            room[room[0].Levels].CompleteLevel = "Complete";
            Save();
            SceneManager.LoadScene("cutscenes");
       }
        
    }
    void IconLoad() 
    {
        if (InstantiateLoadIcon) 
        {
            CurrentLoadIcon += Time.deltaTime;
            if (CurrentLoadIcon > 2) 
            {
                
                Instantiate(LoadIcon, LoadIconPosition.position, Quaternion.identity).gameObject.transform.SetParent(LoadIconPosition);
                CurrentLoadIcon = 0;
                InstantiateLoadIcon = false;
            }
        }
    }
    public void Save()
    {
        
        PlayerPrefs.SetInt("Rounds", room[room[0].Levels].RoundRooms);
        //PlayerPrefs.SetInt("CutScene", countCutScene);
        PlayerPrefs.SetInt("Level", room[0].Levels);
        PlayerPrefs.SetString("Complete", room[room[0].Levels].CompleteLevel);

    }
    void LevelsSave() 
    {
        if (room[1].CompleteRoom == true) 
        {
            room[0].CompleteRoom = true;
        }
        if (room[2].CompleteRoom == true)
        {
            room[0].CompleteRoom = true;
            room[1].CompleteRoom = true;
        }
        //if (room[3].CompleteRoom == true)
        //{
        //    room[0].CompleteRoom = true;
        //    room[1].CompleteRoom = true;
        //    room[2].CompleteRoom = true;
        //}
        //if (room[4].CompleteRoom == true)
        //{
        //    room[0].CompleteRoom = true;
        //    room[1].CompleteRoom = true;
        //    room[3].CompleteRoom = true;
        //}
    }
    void Load()
    {
        //countCutScene = PlayerPrefs.GetInt("CutScene", countCutScene);
        //room[room[0].Levels].CompleteLevel = PlayerPrefs.GetString("Complete", room[room[0].Levels].CompleteLevel);
        room[0].Levels = PlayerPrefs.GetInt("Level", room[0].Levels);
        room[room[0].Levels].RoundRooms = PlayerPrefs.GetInt("Rounds", room[room[0].Levels].RoundRooms);
        index = room[0].Levels;
        LevelsSave();
    }
    void PauseMode() 
    {
        // activa la pausa junto al menu de pausa
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) &&  GamePuase == false)
        {
            IsGamePause(true);
            GamePuase = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) && GamePuase == true)
        {
            IsGamePause(false);
            GamePuase = false;
        }
    }
   public  void IsGamePause(bool Pause) 
    {
        if (Pause)
        {
            GamePuase = true;
            Time.timeScale = 0;
        }
        else 
        {
            GamePuase = false;
            Time.timeScale = 1;
        }
    }

    public void GetGold(int Gold) 
    {
        PlayerGold += Gold;

    }
}
