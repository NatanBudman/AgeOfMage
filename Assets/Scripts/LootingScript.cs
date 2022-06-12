using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootingScript : MonoBehaviour
{
    public Transform PointToSpawn;
    public Transform Parent;
    [SerializeField] Text AddCoins;
    Text text;
    int AddGold;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        AddGold = GameManager.PlayerGold;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PointToSpawn.position;
        transform.Rotate(0, 0, 0);
        
        AddCoins.transform.Rotate(0,0,0);
        if (AddGold != GameManager.PlayerGold) 
        {
            int Coins =GameManager.PlayerGold - AddGold;
            AddCoins.text ="+" + Coins;
            AddGold = GameManager.PlayerGold;
            Instantiate(AddCoins, transform.position, AddCoins.transform.rotation , Parent);
        }
        
     
    }
}
