using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootScript : MonoBehaviour
{
    GameObject player;
    public Transform PointToSpawn;
    public Transform Parent;
    [SerializeField] Text AddCoins;
    Text text;
    int AddGold;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PJ");
        text = GetComponentInChildren<Text>();
        AddGold = GameManager.PlayerGold;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PointToSpawn.position;
        transform.Rotate(0, 0, 0);

        AddCoins.transform.Rotate(0, 0, 0);
        if (AddGold != GameManager.PlayerGold)
        {
            int Coins = GameManager.PlayerGold - AddGold;
            AddCoins.text = "+" + Coins;
            AddGold = GameManager.PlayerGold;
            Instantiate(AddCoins, transform.position, AddCoins.transform.rotation, Parent);
        }
        if (player.GetComponent<PlayerController>().TakeLifePotion == true) 
        {
            AddCoins.text = "+Life";
            Instantiate(AddCoins, transform.position, AddCoins.transform.rotation, Parent);
            player.GetComponent<PlayerController>().TakeLifePotion = false;

        }
        if (player.GetComponent<PlayerController>().TakeManaPotion == true)
        {
            AddCoins.text = "+Mana";
            Instantiate(AddCoins, transform.position, AddCoins.transform.rotation, Parent);
            player.GetComponent<PlayerController>().TakeManaPotion = false;
        }
    }
}
