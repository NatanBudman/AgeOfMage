using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootScript : MonoBehaviour
{
    GameObject player;
    public  Transform PointToSpawn;
    public  Transform Parent;
    public  Text AddCoins;
    Transform nerPos;
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
            if (AddGold > GameManager.PlayerGold) 
            {
                AddCoins.text = "-" + Coins;
                AddCoins.color = new Color(255,0, 0, 255);

            }
            if (AddGold < GameManager.PlayerGold) 
            {
                AddCoins.text = "+" + Coins;
                AddCoins.color = new Color(250, 255, 0, 255);

            }

            AddGold = GameManager.PlayerGold;
            Instantiate(AddCoins, new Vector3(transform.position.x,transform.position.y + 5), AddCoins.transform.rotation, Parent);
        }
        if (player.GetComponent<PlayerController>().TakeLifePotion == true) 
        {
            //AddCoins.text = "+Life";
            TextInWindow("+Life", 250,255,0,255);

            //Instantiate(AddCoins, transform.position, AddCoins.transform.rotation, Parent);
            player.GetComponent<PlayerController>().TakeLifePotion = false;

        }
        if (player.GetComponent<PlayerController>().TakeManaPotion == true)
        {
            //AddCoins.text = "+Mana";
            TextInWindow("+Mana", 250, 255, 0, 255);
            //Instantiate(AddCoins, transform.position, AddCoins.transform.rotation, Parent);
            player.GetComponent<PlayerController>().TakeManaPotion = false;
        }

    }

    public  void TextInWindow(string Text, int r,int g, int b, int Transparecy) 
    {
        AddCoins.color = new Color(r,g,b,Transparecy);
        AddCoins.text = Text;
        Instantiate(AddCoins, transform.position, AddCoins.transform.rotation, Parent);

    }
}
