using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManagerScript : MonoBehaviour
{
    [SerializeField] Room room;
    [SerializeField] public ProtectedZoneScript[] ProtectedZone;
    int ZonesComplete;
    // Start is called before the first frame update
    void Start()
    {
        ProtectedZone[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //if (room.RoundRooms >= 1){ Destroy(gameObject); }
        if (ProtectedZone[2].IsComplete || room.RoundRooms > 1) 
        {
            for(int i = 0; i < ProtectedZone.Length; i++) 
            {
                ProtectedZone[i].gameObject.SetActive(false);
                room.RoundRooms = 1;
                if(i >= ProtectedZone.Length - 1) 
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
