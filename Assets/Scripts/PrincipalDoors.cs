using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalDoors : MonoBehaviour
{
    Room room;


    public GameObject[] DoorToNextRooms;
    // Start is called before the first frame update

    private void Start()
    {
        room = GetComponent<Room>();
    }
    private void Update()
    {
        
    }
    public void PassLevel() 
    {
        room.Levels += 1;
    }
    public void EnableDoors(int door) 
    {
        // abre las puertas en orden de nivel, solo de la sala principal
        DoorToNextRooms[door].SetActive(true);
    }
}
