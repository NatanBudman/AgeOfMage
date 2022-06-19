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
    }

    // Update is called once per frame
    void Update()
    {
        if (room.RoundRooms >= 1){ Destroy(gameObject); }
        if (ProtectedZone[2].IsComplete) 
        {
            for(int i = 0; i < ProtectedZone.Length; i++) 
            {
                Destroy(ProtectedZone[i]);
                room.RoundRooms = 1;
                Destroy(gameObject);
            }
        }
    }
}
