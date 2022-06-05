using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    Room level;
    Room room;
    PrincipalDoors principalDoors;
    public Doors[] door;
    //[SerializeField] EnemyGenerator generadorScript;
    public GameObject Generator;
    public Transform floor;

    float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Room>();
        door = GetComponentsInChildren<Doors>();
        room = GetComponent<Room>();
        principalDoors = GetComponent<PrincipalDoors>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void DoorsToLevels()
    {
        if (room.RoomPrincipal) 
        {
           for (int i = 0; i < room.Levels; i++)
           {
                principalDoors.EnableDoors(i);
                door[i].AnimatedDoor();
           }
        }
      
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
 

        if (collision.gameObject.CompareTag("PJ"))
        {
            if (room.PlayerInRoom == false)
            {
                Generator.SetActive(false);
            }
            else 
            {
                Generator.SetActive(true);
            }
            //Camera.main.transform.position = new Vector3(floor.position.x, floor.position.y, -10);

            if (room.CompleteRoom == true )
            {

                if (!room.RoomPrincipal) 
                {
                    for (int i = 0; i < door.Length; i++) 
                    {
                        door[i].AnimatedDoor();
                    }
                }
                if (room.RoomPrincipal) 
                {
                    DoorsToLevels();
                }
                room.PlayerInRoom = false;
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cooldown = 0;
    }
}
