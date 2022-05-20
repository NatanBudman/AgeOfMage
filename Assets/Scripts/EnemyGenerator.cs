using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    //LevelManager level;
    Room room;


    [SerializeField] private Transform BossSpawn;
    public Transform[] SpawnsGenerators;
    public GameObject[] LongRangeEnemy;
    public GameObject[] MeleEnemy;
    public GameObject BossRoom;

    // La cantidad que se va a spawnear
    public int MeleEnemyCount;
    public int RangeEnemyCount;

    public int[] RoundMeleEnmey;
    public int[] RoundLongRangeEnemy;

    public GameObject[] EnemyInMap;
  
    public GameObject[] BossInMap;

    public int EntityCount;

    [SerializeField] private int PosibilitySpawnSkeletons;
    [SerializeField] private int PosibilitySpawnGoblins;

    [SerializeField]  private float CoolDownMeleEnemy;
    [SerializeField]  private float CoolDownRangeEnemy;

    [SerializeField] private int MaxGoblinsGenerateInRound;
    [SerializeField] private int MaxSkeletonsGenerateInRound;

    string TagName;
    bool BossSpwaner = true;
 
    //public bool passRound;
    // Start is called before the first frame update
    void Start()
    {
         //level = FindObjectOfType<LevelManager>();
         // agarra la informacion del padre
        room = GetComponentInParent<Room>();
       
    }

    // Update is called once per frame
    void Update()
    {
        CoolDownMeleEnemy += Time.deltaTime;
        CoolDownRangeEnemy += Time.deltaTime;



        var ramdomSkeletons = (int)Random.Range(0, PosibilitySpawnSkeletons);
        var ramdomGoblins = (int)Random.Range(0, PosibilitySpawnGoblins);
        var ramdomCurrentTimeGoblins = (int)Random.Range(2,5);
        var ramdomCurrentTimeSkeletons = (int)Random.Range(2,5);
        if(ramdomGoblins == 1) 
        {
            if (MeleEnemyCount > 0 && MaxGoblinsGenerateInRound > EnemyInMap.Length && CoolDownMeleEnemy >= ramdomCurrentTimeGoblins && room.PlayerInRoom == true) 
            {
                GoblinsGenerate();
                MeleEnemyCount--;
                CoolDownMeleEnemy = 0;
            }
        }
        if (ramdomSkeletons == 1) 
        {

            if (RangeEnemyCount > 0 && MaxSkeletonsGenerateInRound > EnemyInMap.Length && CoolDownRangeEnemy >= ramdomCurrentTimeSkeletons && room.PlayerInRoom == true)
            {
                 SkeletonsGenerate();
                 RangeEnemyCount--;
                CoolDownRangeEnemy = 0;
            }

        }
        if (BossSpwaner && room.RoundRooms == 5 && room.PlayerInRoom == true)
        {
            BossGenerate();
            CoolDownRangeEnemy = 0;
        }
        if (MeleEnemyCount <= 0 ) 
        {
         
            MeleEnemyCount = 0;

        }
        if (RangeEnemyCount <= 0) 
        {
            RangeEnemyCount = 0;
        }
        if (RangeEnemyCount <= 0 && MeleEnemyCount <= 0 && EnemyInMap.Length <= 0 && EnemyInMap.Length <= 0 && BossInMap.Length <= 0)
        {
            room.NoEnemy = true;
        }
        else 
        {
            room.NoEnemy = false;
        }

        EnemeyPerRound();
        EnemiesInMap();

        if (RangeEnemyCount <= 0 && MeleEnemyCount <= 0)
        {
            for (int i = 0; i < SpawnsGenerators.Length; i++) 
            {
                SpawnsGenerators[i].gameObject.SetActive(false);
            }
        }
        
     
    

    }





    private void SkeletonsGenerate()
    {
        int n = Random.Range(0, LongRangeEnemy.Length);
        int z = Random.Range(0, SpawnsGenerators.Length);

      

        SpawnsGenerators[z].gameObject.SetActive(true);

        Instantiate(LongRangeEnemy[n], SpawnsGenerators[z].position, LongRangeEnemy[n].transform.rotation);

      
    }
    private void GoblinsGenerate()
    {
        int n = Random.Range(0, MeleEnemy.Length);
        int z = Random.Range(0, SpawnsGenerators.Length);

        SpawnsGenerators[z].gameObject.SetActive(true);
      
        Instantiate(MeleEnemy[n], SpawnsGenerators[z].position, MeleEnemy[n].transform.rotation);

    



    }
    private void BossGenerate()
    {
   
        Instantiate(BossRoom, BossSpawn.position, BossRoom.transform.rotation);
        BossSpwaner = false;
    }

    public  void EnemeyPerRound() 
    {
        if (room.PlayerInRoom == true && room.RoundRooms <= 5) 
        {
        // cada ronda dentro del room recarga a los enemigos
            for (int i = 0; i < room.RoundRooms; i++) 
            {
               if (room.AddEnemy == true) 
               {
                   MeleEnemyCount = RoundMeleEnmey[i];
                   RangeEnemyCount = RoundLongRangeEnemy[i];
               }
        
            }

        }
    
    }

    public void EnemiesInMap()
    {
        // busca a los enemigos en el mapa
        EnemyInMap = GameObject.FindGameObjectsWithTag("Enemy");
        BossInMap = GameObject.FindGameObjectsWithTag("Boss");
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    TagName = collision.gameObject.tag;

    //}

}
