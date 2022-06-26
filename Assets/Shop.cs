using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    GameObject player;
    [SerializeField] public SpellsBook[] ItemsForSale;
    [SerializeField] Transform[] ItemsSpawn;
    [SerializeField]public GameObject ItemsColliders1;
    [SerializeField]public GameObject ItemsColliders2;
    [SerializeField]public GameObject ItemsColliders3;
    [SerializeField]public Text ItemDescription;
    [SerializeField]public Text ItemName;
    [SerializeField]public Text ItemCost;
    [SerializeField]public Text ItemAttack;
    [SerializeField]public Image Panel;
    public int Items1 = -1;
    public int Items2 = -1;
    public int Items3 = -1;
    int IndexBooks = 0;
    public bool isItem1;
    public bool isItem2;
    public bool isItem3;
    public GameObject[] ItemsInSale;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("PJ");
    }

    // Update is called once per frame
    void Update()
    {
        ItemsInSale = GameObject.FindGameObjectsWithTag("Books");

        if (Items1 == -1) 
        {
            Items1 = (int)Random.Range(0, ItemsForSale.Length);


        }
        if (/*Items1 > -1 && Items2 == -1 || */Items2 == -1||Items2 == Items1) 
        {
    

            Items2 = (int)Random.Range(0, ItemsForSale.Length);
        }
        if(/*Items2 > -1 || Items3 == -1 ||*/Items3 == -1|| Items3 == Items2 || Items3 == Items1) 
        {
             
           Items3 = (int)Random.Range(0, ItemsForSale.Length);
        }

        if(Items3 > -1 && Items3 != Items2 && Items3 != Items1) 
        {
            ReloadShop();
        }
    
        SpellDescription();
    }

    void SpellDescription() 
    {
        if (ItemsForSale[Items1].IsBoughtBook)
        {
            ItemsForSale[Items1].Book.gameObject.SetActive(false);

            if (ItemsForSale[Items1].Book.activeSelf == true)
                ItemsInSale[0].SetActive(false);

        }
        else 
        {
            ItemsForSale[Items1].Book.gameObject.SetActive(true);


        }
        if (ItemsForSale[Items2].IsBoughtBook)
        {
            ItemsForSale[Items2].Book.gameObject.SetActive(false);

            if (ItemsForSale[Items2].Book.activeSelf == true)
                ItemsInSale[1].SetActive(false);

        }
        else 
        {
            ItemsForSale[Items2].Book.gameObject.SetActive(true);


        }
        if (ItemsForSale[Items3].IsBoughtBook)
        {
            ItemsForSale[Items3].Book.gameObject.SetActive(false);

            if (ItemsForSale[Items3].Book.activeSelf == true)
                ItemsInSale[2].SetActive(false);

        }
        else 
        {
            ItemsForSale[Items3].Book.gameObject.SetActive(true);

        }

        if (isItem1) 
        {
            if (!ItemsForSale[Items1].IsBoughtBook)
            {

                ItemDescription.text = "Description: " + ItemsForSale[Items1].description;
                ItemName.text = "Name:" + ItemsForSale[Items1].name;
                ItemCost.text = "Cost:" + ItemsForSale[Items1].cost;
                ItemAttack.text = "Attack:" + ItemsForSale[Items1].attack;
            }

        }
        if (isItem2) 
        {
            if (!ItemsForSale[Items2].IsBoughtBook) 
            {

                ItemDescription.text = "Description: " + ItemsForSale[Items2].description;
                ItemName.text = "Name: " + ItemsForSale[Items2].name;
                ItemCost.text = "Cost: " + ItemsForSale[Items2].cost;
                ItemAttack.text = "Attack: " + ItemsForSale[Items2].attack;
            }

      
        }
        if (isItem3) 
        {
            if (!ItemsForSale[Items3].IsBoughtBook) 
            {

                ItemDescription.text = "Description " + ItemsForSale[Items3].description;
                ItemName.text = "Name: " + ItemsForSale[Items3].name;
                ItemCost.text = "Cost: " + ItemsForSale[Items3].cost;
                ItemAttack.text = "Attack: " + ItemsForSale[Items3].attack;
            }

        }
    }
 
    void ReloadShop() 
    {
        if (IndexBooks < 1) 
        {
            if (!ItemsForSale[Items1].IsBoughtBook)
                Instantiate(ItemsForSale[Items1].Book, ItemsSpawn[0].position, Quaternion.identity, this.gameObject.transform);

            if (!ItemsForSale[Items2].IsBoughtBook)
                Instantiate(ItemsForSale[Items2].Book, ItemsSpawn[1].position, Quaternion.identity, this.gameObject.transform);

            if (!ItemsForSale[Items3].IsBoughtBook)
                Instantiate(ItemsForSale[Items3].Book, ItemsSpawn[2].position, Quaternion.identity, this.gameObject.transform);


             IndexBooks++;
            
        }
   

    }

}
