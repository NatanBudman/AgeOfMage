using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    PrincipalDoors doors;
    Room level;
    Detector detector;
    EnemyGenerator generator;
    EnemyScript enemy;
    PlayerController player;
    GameManager manager;

    public static bool IsDefeatBoss = false;
    public static bool IsBossApears = false;

    public GameObject Door;

    private Portals DoorsToPrincipalRoom;

    public GameObject RoomItem;

    public bool CompleteRoom = false;
    public bool PlayerInRoom;

    public bool RoomPrincipal;

    public int RoundRooms = 0;

    public int Levels = 0;

    float cooldownPass;
    public bool NoEnemy;
    public bool AddEnemy;
    bool InstatntiateItem;


    public string CompleteLevel;
    float currentTimeToSave;

 
    // Start is called before the first frame update
  
    void Start()
    {
        IsBossApears = false;
        manager = FindObjectOfType<GameManager>();
        doors = FindObjectOfType<PrincipalDoors>();
        detector = GetComponent<Detector>();
        generator = GetComponentInChildren<EnemyGenerator>();
        level = FindObjectOfType<Room>();
        enemy = FindObjectOfType<EnemyScript>();
       

       
        if (!RoomPrincipal) 
        {
            DoorsToPrincipalRoom = GetComponentInChildren<Portals>();
        }
    }
 
    // Update is called once per frame
    void Update()
    {
    
        PassRound();
        PassNextRoom();
        EnableDoor();
    }
  

    void PassNextRoom()
    {
        if (CompleteLevel == "Complete") 
        {
            CompleteRoom = true;
        }
        if (CompleteRoom == true && InstatntiateItem == true)
        {
            Instantiate(RoomItem, new Vector2(detector.floor.position.x, detector.floor.position.y - 10), Quaternion.identity);
            InstatntiateItem = false;
        }
        // activa el portal y desactiva el room
        if (CompleteRoom == true)
        {
            CompleteLevel = "Complete";
            PlayerInRoom = false;
            Door.SetActive(true);

        }
    }
    void EnableDoor() 
    {
        // si completas la sala desbloquea las puertas
        if (CompleteRoom && !RoomPrincipal)
        {
            DoorsToPrincipalRoom.enabled = true;
        }
        else if(!CompleteRoom && !RoomPrincipal)
        {
            DoorsToPrincipalRoom.enabled = false;
        }
    }

  
    
    void PassRound() 
    {
        
        // pasa de ronda
        if (NoEnemy == true  && RoundRooms >= 6 && PlayerInRoom == true)
        {
            doors.PassLevel();
            InstatntiateItem = true;
            IfFiveRound();
            cooldownPass += Time.deltaTime;
        }
        if (NoEnemy == true && PlayerInRoom == true && RoundRooms <= 5)
        {
            cooldownPass += Time.deltaTime;
            if (cooldownPass >= 3.5)
            {
                RoundRooms += 1;
                AddEnemy = true;
                cooldownPass = 0;
                if (RoundRooms == 5) 
                {
                    IsBossApears = true;
                }
            }
            else 
            {
               
                AddEnemy = false;
            }
        }
    }
 
    void IfFiveRound()
    {
        RoundRooms = 0;
        CompleteRoom = true;
   
        IsDefeatBoss = true;
        //AutoSave = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // player entra al room
        if (collision.gameObject.CompareTag("PJ") && CompleteRoom == false)
        {
            PlayerInRoom = true;
        }
        
 
        
      
    }

 

    private void OnTriggerExit2D(Collider2D collision)
    {
     


    }

}
