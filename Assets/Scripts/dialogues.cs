using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogues : MonoBehaviour
{
    HealthController health;
    Room room;
    public Image[] talk;
    public Image[] GobliinsTalk;
    public Image[] SkeletonsTalk;
    public Image[] BossTalk;

    public Transform SpawnDialogue;

    // dialogos Exclusivos
    public bool GoblinTalk;
    public bool SkeletonTalk;
    public bool bossTalk;

    private int PosibilitaToTalk;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        room = FindObjectOfType<Room>();
      
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ToTalk()
    {
        var ramdom = (int)Random.Range(0, PosibilitaToTalk);

        if (ramdom == 1)
        {
            var ramdom2 = (int)Random.Range(0, talk.Length);
            // diferentes situaciones en las que se puede activar

            //situacion de poca vida

            if (health.currentLife <= health.currentLife * 25 / 100)
            {
                Instantiate(talk[1], SpawnDialogue.position, Quaternion.identity);

            }
            if (health.currentLife >= health.currentLife * 25 / 100 && health.currentLife <= health.currentLife * 50 / 100)
            {
                Instantiate(talk[2], SpawnDialogue.position, Quaternion.identity);
            }

            if (health.currentLife >= health.currentLife * 50 / 100)
            {
                // de ronda
                if (room.RoundRooms == 5)
                {
                    Instantiate(talk[3], SpawnDialogue.position, Quaternion.identity);
                }
                if (room.RoundRooms == 4)
                {
                    Instantiate(talk[4], SpawnDialogue.position, Quaternion.identity);
                }
                if (room.RoundRooms == 3)
                {
                    Instantiate(talk[5], SpawnDialogue.position, Quaternion.identity);
                }
                if (room.RoundRooms == 2)
                {
                    Instantiate(talk[6], SpawnDialogue.position, Quaternion.identity);
                }
                if (room.RoundRooms == 1)
                {
                    Instantiate(talk[7], SpawnDialogue.position, Quaternion.identity);
                }

                //exclivos
                GoblinExcluvie();

                SkeletonExcluvie();
            }
        }

    }
    void GoblinExcluvie()
    {
        if (GoblinTalk)
        {
            if (room.RoundRooms == 5)
            {
                Instantiate(GobliinsTalk[1], SpawnDialogue.position, Quaternion.identity);
            }
            if (room.RoundRooms == 4)
            {
                Instantiate(GobliinsTalk[2], SpawnDialogue.position, Quaternion.identity);
            }
            if (room.RoundRooms == 3)
            {
                Instantiate(GobliinsTalk[3], SpawnDialogue.position, Quaternion.identity);
            }
            if (room.RoundRooms == 2)
            {
                Instantiate(GobliinsTalk[4], SpawnDialogue.position, Quaternion.identity);
            }
            if (room.RoundRooms == 1)
            {
                Instantiate(GobliinsTalk[5], SpawnDialogue.position, Quaternion.identity);
            }
        }
    }
    void SkeletonExcluvie()
    {
        if (SkeletonTalk)
        {
            if (room.RoundRooms == 5)
            {
                Instantiate(SkeletonsTalk[1], SpawnDialogue.position, Quaternion.identity);
            }
            if (room.RoundRooms == 4)
            {
                Instantiate(SkeletonsTalk[2], SpawnDialogue.position, Quaternion.identity);
            }
            if (room.RoundRooms == 3)
            {
                Instantiate(SkeletonsTalk[3], SpawnDialogue.position, Quaternion.identity);
            }
            if (room.RoundRooms == 2)
            {
                Instantiate(SkeletonsTalk[4], SpawnDialogue.position, Quaternion.identity);
            }
            if (room.RoundRooms == 1)
            {
                Instantiate(SkeletonsTalk[5], SpawnDialogue.position, Quaternion.identity);
            }
        }
    }
    void BossExclive() 
    {

    }
}
