using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSelected : MonoBehaviour
{
    public static int index;
    private int indexColor;

    BarraDeVida Mana;
    public SpellsBook[] books;
    public Image[] Spell;
    public List<Image> Color;
    public Image parchment;
    public Image parchmentCircle;
    public static bool hasFire;
    public static bool hasWater;
    public static bool hasLightning;
    public static bool hasWind;
    public static bool hasEarth;
    public static bool hasHeal;
    public static string isHasFire;
    public static string isHasWater;
    public static string isHasLightning;
    public static string isHasWind;
    public static string isHasEarth;
    public static string isHasHeal;

    public Weapon weapon;
    void Awake() 
    {
        LoadSpells();
    }
    // Start is called before the first frame update
    void Start()
    {
        Mana = FindObjectOfType<BarraDeVida>();
    }

    // Update is called once per frame
    void Update()
    {
        SpellParchment();

        if (books[0].IsBoughtBook == true)
        {
            hasFire = true;
            isHasFire = "Si";
        }
        if (books[1].IsBoughtBook == true)
        {
            hasWater = true;
            isHasWater = "Si";
        }
        if (books[2].IsBoughtBook == true)
        {
            hasLightning = true;
            isHasLightning = "Si";
        }
        if (books[3].IsBoughtBook == true)
        {
            hasEarth = true;
            isHasEarth = "Si";
        }
        if (books[4].IsBoughtBook == true)
        {
            hasWind = true;
            isHasWind = "Si";

        }
        if (books[5].IsBoughtBook == true)
        {
            hasHeal = true;
            isHasHeal = "Si";

        }

        SaveSpells();
        if (isHasFire == "Si") 
        {
            books[0].IsBoughtBook = true;
        }
        if(isHasWater == "Si") 
        {
            books[1].IsBoughtBook = true;
        }
        if (isHasLightning == "Si") 
        {
            books[2].IsBoughtBook = true;
        }
        if (isHasEarth == "Si")
        {
            books[3].IsBoughtBook = true;
        }
        if (isHasWind == "Si") 
        {
            books[4].IsBoughtBook = true;
        }
        if (isHasHeal == "Si") 
        {
            books[5].IsBoughtBook = true;
        }
    }
    void SaveSpells() 
    {
        PlayerPrefs.SetString("Fire", isHasFire);
        PlayerPrefs.SetString("Water", isHasWater);
        PlayerPrefs.SetString("Light", isHasLightning);
        PlayerPrefs.SetString("Earth", isHasEarth);
        PlayerPrefs.SetString("Wind", isHasWind);
        PlayerPrefs.SetString("Heal", isHasHeal);
    }
    void LoadSpells() 
    {
        isHasFire = PlayerPrefs.GetString("Fire");
        isHasWater = PlayerPrefs.GetString("Water");
        isHasLightning = PlayerPrefs.GetString("Light");
        isHasEarth = PlayerPrefs.GetString("Earth");
        isHasWind = PlayerPrefs.GetString("Wind");
        isHasHeal = PlayerPrefs.GetString("Heal");

    }
    void SpellParchment() 
    {
        if (index == 2)
            indexColor = 2;
            parchmentCircle.color = new Color(Color[indexColor].color.r, Color[indexColor].color.g, Color[indexColor].color.b);
        if (index == 0)
            indexColor = 0;
            parchmentCircle.color = new Color(Color[indexColor].color.r - 25, Color[indexColor].color.g, Color[indexColor].color.b);
        if (index == 1)
            indexColor = 1;
            parchmentCircle.color = new Color(Color[indexColor].color.r, Color[indexColor].color.g + 100, Color[indexColor].color.b);
        if (index == 3)
            indexColor = 3;
        parchmentCircle.color = new Color(Color[indexColor].color.r, Color[indexColor].color.g + 150, Color[indexColor].color.b);
        if (index == 4)
            indexColor = 4;
        parchmentCircle.color = new Color(Color[indexColor].color.r, Color[indexColor].color.g + 120, Color[indexColor].color.b);

        Spell[index].enabled = true;

        //if (index <= Spell.Length - 1)
        //{
        //    Spell[index + 1].enabled = false;

        //}
        if (index > 0)
        {
            Spell[index - 1].enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            index = 0;
            Spell[2].enabled = false;
            Spell[1].enabled = false;
            Spell[3].enabled = false;
            Spell[4].enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2) && hasFire == true) //fuego
        {
            index = 1;
            Spell[0].enabled = false;
            Spell[2].enabled = false;
            Spell[3].enabled = false;
            Spell[4].enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3) && hasWater == true) //agua
        {
            index = 2;
            Spell[0].enabled = false;
            Spell[1].enabled = false;
            Spell[3].enabled = false;
            Spell[4].enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha4) && hasLightning == true) //rayo
        {
            index = 3;
            Spell[2].enabled = false;
            Spell[1].enabled = false;
            Spell[0].enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha5)&& hasWind == true)
        {
            index = 4;
            Spell[2].enabled = false;
            Spell[1].enabled = false;
            Spell[3].enabled = false;
            Spell[0].enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.B) && Mana.CurrentMana >= 30 && hasHeal == true)
        {
            Mana.CurrentMana -= 30;
            weapon.Heal();
        }

        if (Input.GetKeyDown(KeyCode.T) && Mana.CurrentMana >= 30 && hasEarth == true)
        {
            Mana.CurrentMana -= 20;
            weapon.Wall();
        }

    }
}
