using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    GameObject player;
    [SerializeField] public SpellsBook[] ItemsForSale;
    [SerializeField] Transform[] ItemsSpawn;
    [SerializeField] GameObject[] ItemsSold;
    [SerializeField] public GameObject ItemsColliders1;
    [SerializeField] public GameObject ItemsColliders2;
    [SerializeField] public GameObject ItemsColliders3;
    [SerializeField] public Text ItemDescription;
    [SerializeField] public Text ItemName;
    [SerializeField] public Text ItemCost;
    [SerializeField] public Text ItemAttack;
    [SerializeField] public Text ItemType;
    [SerializeField] public Image Panel;
    public int Items1 = -1;
    public int Items2 = -1;
    public int Items3 = -1;
    int IndexBooks = 0;
    public bool isItem1;
    public bool isItem2;
    public bool isItem3;
    bool IsShopRealod = false;
    public GameObject[] ItemsInSale;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("PJ");
        IndexBooks = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(IndexBooks);
        //Debug.Log(IsShopRealod);

        ItemsInSale = GameObject.FindGameObjectsWithTag("Books");

        if (Items1 == -1)
        {
            Items1 = (int)Random.Range(0, ItemsForSale.Length - 1);


        }
        if (/*Items1 > -1 && Items2 == -1 || */Items2 == -1 || Items2 == Items1)
        {


            Items2 = (int)Random.Range(0, ItemsForSale.Length - 1);
        }
        if (/*Items2 > -1 || Items3 == -1 ||*/Items3 == -1 || Items3 == Items2 || Items3 == Items1)
        {
             
           Items3 = (int)Random.Range(0, ItemsForSale.Length - 1);
        }
        else if(Items3 != -1 && Items3 != Items2 && Items3 != Items1) 
        {
            IsShopRealod = true;
        }



  
        if (IsShopRealod)
        {
            ReloadShop();
        }

        SpellDescription();
    }

    void SpellDescription()
    {
        if (ItemsForSale[Items1].IsBoughtBook)
        {
            ItemsSold[0].SetActive(true);
        }
   
        if (ItemsForSale[Items2].IsBoughtBook)
        {
            ItemsSold[1].SetActive(true);
        }
    
        if (ItemsForSale[Items3].IsBoughtBook)
        {
            ItemsSold[2].SetActive(true);
        }
   

        if (isItem1)
        {
            if (!ItemsForSale[Items1].IsBoughtBook)
            {

                ItemDescription.text = "Description: " + ItemsForSale[Items1].description + "\n"+ "\n" + "Efectos: " + ItemsForSale[Items1].Efectos + "\n" + "\n" + "Press F to Buy";
                ItemName.text = "Name: " + ItemsForSale[Items1].name;
                ItemCost.text = "Cost: " + ItemsForSale[Items1].cost;
                ItemAttack.text = "Attack: " + ItemsForSale[Items1].attack;
                ItemType.text = "Tipo: " + ItemsForSale[Items1].TypeSpell;

            }

        }
        if (isItem2)
        {
            if (!ItemsForSale[Items2].IsBoughtBook)
            {

                ItemDescription.text = "Description: " + ItemsForSale[Items2].description + "\n" + "\n" + "Efectos: " + ItemsForSale[Items2].Efectos + "\n" + "\n" + "Press F to Buy";
                ItemName.text = "Name: " + ItemsForSale[Items2].name;
                ItemCost.text = "Cost: " + ItemsForSale[Items2].cost;
                ItemAttack.text = "Attack: " + ItemsForSale[Items2].attack;
                ItemType.text = "Tipo: " + ItemsForSale[Items2].TypeSpell;

            }


        }
        if (isItem3)
        {
            if (!ItemsForSale[Items3].IsBoughtBook)
            {

                ItemDescription.text = "Description: " + ItemsForSale[Items3].description + "\n" + "\n" + "Efectos: " + ItemsForSale[Items3].Efectos + "\n" + "\n" + "Press F to Buy";
                ItemName.text = "Name: " + ItemsForSale[Items3].name;
                ItemCost.text = "Cost: " + ItemsForSale[Items3].cost;
                ItemAttack.text = "Attack: " + ItemsForSale[Items3].attack;
                ItemType.text = "Tipo: " + ItemsForSale[Items3].TypeSpell ;
            }

        }
    }

    void ReloadShop()
    {
        if (IndexBooks >= 0) 
        if (IndexBooks >= 0)
        {
        
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Instantiate(ItemsForSale[Items1].Book, ItemsSpawn[0].position, Quaternion.identity, this.gameObject.transform);
                    i = 1;
                }
                if (i == 1)
                {
                    Instantiate(ItemsForSale[Items2].Book, ItemsSpawn[1].position, Quaternion.identity, this.gameObject.transform);
                    IsShopRealod = false;
                    i = 2;

                }
                if (i == 2)
                {
                    Instantiate(ItemsForSale[Items3].Book, ItemsSpawn[2].position, Quaternion.identity, this.gameObject.transform);
                    IsShopRealod = false;
                    i = 3;
                }
                if (i == 3)
                {
                    IndexBooks = -1;
                }
            }
            if (ItemsInSale.Length == 4)
            {
                Destroy(ItemsInSale[4]);
            }
            //Instantiate(ItemsForSale[Items2].Book, ItemsSpawn[1].position, Quaternion.identity, this.gameObject.transform);

            //Instantiate(ItemsForSale[Items3].Book, ItemsSpawn[2].position, Quaternion.identity, this.gameObject.transform);
           
        }


    }

}
