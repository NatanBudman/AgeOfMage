using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopPlataforms : MonoBehaviour
{
    LootScript loot;
    Shop shop;
    [SerializeField] bool Item1;
    [SerializeField] bool Item2;
    [SerializeField] bool Item3;
    //[SerializeField] Text BuyText;
    //[SerializeField] Transform BuyTextSpawn;
    //[SerializeField] GameObject canvas;
    int CountText = 0;
    bool IsCanBuy;
    bool IsBuy;
    float currenTime;
    // Start is called before the first frame update
    void Start()
    {
        shop = FindObjectOfType<Shop>();
        loot = FindObjectOfType<LootScript>();
    }

    // Update is called once per frame
    void Update()
    {
        currenTime += 1 * Time.deltaTime;

        if (IsBuy) 
        {
           if(!IsCanBuy)
           {
               loot.TextInWindow("A laburar Vago",255,0,0,255);
               IsBuy = false;

            }
            if (IsCanBuy) 
            {
                loot.TextInWindow("Buy", 250, 255, 0, 255);
                IsBuy = false;
                Debug.Log("Buy");
            }
        }
        if (CountText >= 1) 
        {
                //Instantiate(BuyText, BuyTextSpawn.position,Quaternion.identity,canvas.transform);
                CountText--;
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PJ")) 
        {
            if (Item1)
            {
                shop.Panel.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F) && GameManager.PlayerGold >= shop.ItemsForSale[shop.Items1].cost && !shop.ItemsForSale[shop.Items1].IsBoughtBook)
                {
                    if (currenTime > 1.5f) 
                    {
                        GameManager.PlayerGold -= shop.ItemsForSale[shop.Items1].cost;
                        CountText++;
                        IsCanBuy = true;
                        IsBuy = true;
                        shop.ItemsForSale[shop.Items1].IsBoughtBook = true;
                        currenTime = 0;
                    }

                }
                if (Input.GetKeyDown(KeyCode.F) && GameManager.PlayerGold < shop.ItemsForSale[shop.Items1].cost)
                {
                    if (currenTime > 1.5f) 
                    {
                        CountText++;
                        IsCanBuy = false;
                        IsBuy = true;
                        currenTime = 0;

                    }
                }

                shop.isItem1 = true;
                shop.isItem2 = false;
                shop.isItem3 = false;
            }
            if (Item2) 
            {
                shop.Panel.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F) && GameManager.PlayerGold >= shop.ItemsForSale[shop.Items2].cost && !shop.ItemsForSale[shop.Items2].IsBoughtBook)
                {
                    if (currenTime > 1.5f) 
                    {
                        GameManager.PlayerGold -= shop.ItemsForSale[shop.Items2].cost;
                         CountText++;
                         IsCanBuy = true;
                         IsBuy = true;
                        shop.ItemsForSale[shop.Items2].IsBoughtBook = true;
                        currenTime = 0;
                    }

                }
                if (Input.GetKeyDown(KeyCode.F) && GameManager.PlayerGold < shop.ItemsForSale[shop.Items2].cost)
                {
                    if (currenTime > 1.5f) 
                    {
                        CountText++;
                        IsCanBuy = false;
                        IsBuy = true;
                        currenTime = 0;

                    }

                }
                shop.isItem1 = false;
                shop.isItem2 = true;
                shop.isItem3 = false;
            }
            if (Item3)
            {
                shop.Panel.gameObject.SetActive(true);


                if (Input.GetKeyDown(KeyCode.F) && GameManager.PlayerGold >= shop.ItemsForSale[shop.Items3].cost && !shop.ItemsForSale[shop.Items3].IsBoughtBook)
                {

                    if (currenTime > 1.5f) 
                    {
                        GameManager.PlayerGold -= shop.ItemsForSale[shop.Items3].cost;
                        CountText++;
                        IsCanBuy = true;
                        IsBuy = true;
                        shop.ItemsForSale[shop.Items3].IsBoughtBook = true;
                        currenTime = 0;

                    }
                }
                if (Input.GetKeyDown(KeyCode.F) && GameManager.PlayerGold < shop.ItemsForSale[shop.Items3].cost)
                {
                    if (currenTime > 1.5f) 
                    {
                        CountText++;
                        IsCanBuy = false;
                        IsBuy = true;
                        currenTime = 0;

                    }
                }
                shop.isItem1 = false;
                shop.isItem2 = false;
                shop.isItem3 = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        shop.Panel.gameObject.SetActive(false);

    }
}
