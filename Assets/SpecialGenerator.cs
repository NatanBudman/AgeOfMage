using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Room Room4;
    [SerializeField] ProtectedZoneScript[] Zones;
    [SerializeField] AltarScript[] altares;
    [SerializeField] GameObject[] Enemy;
    [SerializeField] Transform[] Spawns;
    [SerializeField] float TimeToSpawn;
    [SerializeField] float TimeResetToCount;
    [SerializeField] float TimeToPauseOleada;
    [SerializeField] GameObject Protected1;
    [SerializeField] GameObject InstrucionesAltares;
    [SerializeField] GameObject IntruccionesZone;
    float currenTimeSpawn;
    float currenTimePuase;
    float currenTimeCountReset;
    int count;
    int randomEnemy;
    int randomSapwn;
    bool pauseOleada;
    bool puaseForCompleteRound = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(puaseForCompleteRound);
        EnableGenerator();
        if (!Room4.CompleteRoom && puaseForCompleteRound == false) 
        {
            if(this.gameObject.activeSelf == true) 
            {
                Protected1.SetActive(true);
            }
            if(currenTimeCountReset >= TimeResetToCount) 
            {
               count = (int)Random.Range(1, 2);
               currenTimeCountReset = 0;
            }
            randomEnemy = (int)Random.Range(0, Enemy.Length - 1);
            randomSapwn = (int)Random.Range(0, Spawns.Length - 1);

            currenTimePuase += Time.deltaTime;
            currenTimeSpawn += 1 * Time.deltaTime;
            currenTimeCountReset +=  Time.deltaTime;
            GeneratorEnemy();

            // pausa on
            if (currenTimePuase >= TimeToPauseOleada) 
            {
                pauseOleada = true;
                if (currenTimePuase >= TimeToPauseOleada + 5) 
                {
                    pauseOleada = false;
                    currenTimePuase = 0;
                }
            }
        }
    }
    void GeneratorEnemy() 
    {
        if (count > 0 && pauseOleada == false) 
        {
            if(currenTimeSpawn > TimeToSpawn) 
            {
                Instantiate(Enemy[randomEnemy], Spawns[randomSapwn].position, Quaternion.identity,this.gameObject.transform);
                count--;
                TimeToSpawn = 0;
            }
        }
    }
    void EnableGenerator() 
    {
        // Momentos donde debe de activarse el spawn de enemigos
        if (!Zones[2].IsComplete) 
        {
            if (!Zones[0].IsComplete && Zones[0].CurrentAmount > 0  || !Zones[1].IsComplete && Zones[1].CurrentAmount > 0 || !Zones[2].IsComplete && Zones[2].CurrentAmount > 0 ) 
            {
                puaseForCompleteRound = false;
            }
            //else
            //{
            //    puaseForCompleteRound = true;
            //}
        }
        if(Zones[2].gameObject.activeSelf == false && Zones[2].IsComplete && !altares[0].IsComplete) 
        {
            altares[0].gameObject.SetActive(true);
        }
        if (!altares[0].IsComplete && Zones[0].IsComplete) 
        {
            if (!altares[0].IsComplete && altares[0].CurrentLoad > 0 )
            {
                puaseForCompleteRound = false;
            }
            else 
            {
                puaseForCompleteRound = true;
            }
        }

        if (altares[0].IsComplete) 
        {
            this.gameObject.SetActive(false);
        }

        if (!altares[0].IsComplete) 
        {
            InstrucionesAltares.SetActive(true);
        }
        else 
        {
            InstrucionesAltares.SetActive(false);

        }
        // intrucciones
        if (!Zones[0].IsComplete)
        {
            IntruccionesZone.SetActive(true);
        }
        else 
        {
            IntruccionesZone.SetActive(false);
        }
    }
}
