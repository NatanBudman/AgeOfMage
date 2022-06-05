using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text[] round;
    [SerializeField] private Image BossBatlle;

    [SerializeField]public Room[] room;

    [SerializeField] private Image LoadIcon;
    [SerializeField] private Text[] Gold;
    [SerializeField] private Transform LoadIconPosition;

    public  bool GamePuase = false;


    public Transform SpawnPoint;
    public Transform[] newSpawnPoint;

    private static int PlayerGold;
    string _NumbersInCount;
    string _RoundInCount;
    string _LevelInCount;

    bool InstantiateLoadIcon;
    float CurrentLoadIcon;

    int Level;
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
        GoldCount();
        IconLoad();
        SpawnPoints();
        RoundPlaying();
        CusSceneConditions();
        RoundCount();

 
        //Debug.Log(countCutScene);
    }
    void SpawnPoints() 
    {
         SpawnPoint.position = newSpawnPoint[room[0].Levels].position;
        
    }
    void RoundPlaying() 
    {

      
    }
    void AutoSave() 
    {
        for (int i = 0; i < room[0].Levels; i++) 
        {
            InstantiateLoadIcon = true;
           
            Save();

            if (i >= room.Length) 
            {
                i = room.Length;
            }
        }

        Level = room[0].Levels;

        if (room[0].Levels >= 1) 
        {
            room[0].CompleteLevel = "Complete";
        }
        if (room[0].Levels >= 2) 
        {
            room[1].CompleteLevel = "Complete";
        }
        if (room[0].Levels >= 3)
        {
            room[2].CompleteLevel = "Complete";
        }
    }
    void CusSceneConditions() 
    {
        if (Room.IsBossApears)
        {
            InstantiateLoadIcon = true;
            Save();
            SceneManager.LoadScene("cutscenes");
        }
  
       if (Room.IsDefeatBoss)
       {
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
  
        PlayerPrefs.SetInt("Rounds", room[Level].RoundRooms);
        PlayerPrefs.SetInt("Level", Level);
        PlayerPrefs.SetString("Complete", room[Level].CompleteLevel);

    }
    void Load()
    {

        room[0].Levels = PlayerPrefs.GetInt("Level", Level);
        room[room[0].Levels].RoundRooms = PlayerPrefs.GetInt("Rounds", room[Level].RoundRooms);
        for (int i = 0; i < Level - 1; i++) 
        {
            room[i].CompleteRoom = true;
        }


        LevelsSave();
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
   public void IsGamePause(bool Pause) 
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

    public static void GetGold(int Gold) 
    {
        PlayerGold += Gold;

    }
    void GoldCount() 
    {
        _NumbersInCount = "" + PlayerGold;

        char numer1 = _NumbersInCount[0];
        Gold[0].text = "" + numer1;

        if (PlayerGold > 9)
        { 
            char numer2 = _NumbersInCount[1];
            Gold[1].text = "" + numer2;
        }
        if (PlayerGold > 99) 
        {
            char numer3 = _NumbersInCount[2];
            Gold[2].text = "" + numer3;

        }
        if (PlayerGold > 999) 
        {
            char numer4 = _NumbersInCount[3];
            Gold[3].text = "" + numer4;
        }
        if (PlayerGold > 9999) 
        {
            char numer5 = _NumbersInCount[4];
            Gold[4].text = "" + numer5;

        }

    }
    void RoundCount() 
    {
        _RoundInCount = "" + room[room[0].Levels].RoundRooms;
        _LevelInCount = "" + room[0].Levels;

        char number1 = _RoundInCount[0];
        round[0].text = "" + number1; 
   
       char number2 = _LevelInCount[0];
       round[1].text = "" + number2;
        


        if (room[room[0].Levels].RoundRooms == 5)
        {
            BossBatlle.gameObject.SetActive(true);
        }
        else 
        {
            BossBatlle.gameObject.SetActive(false);
        }
    }
}
