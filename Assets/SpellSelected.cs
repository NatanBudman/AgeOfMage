using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSelected : MonoBehaviour
{
    public static int index;
    private int indexColor;

    public Image[] Spell;
    public List<Image> Color;
    public Image parchment;
    public Image parchmentCircle;
    bool hasFire;
    bool hasWater;
    bool hasEarth;
    bool hasHeal;
    bool hasLightning;
    bool hasWind;
    bool hasDash;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        SpellParchment();

    
    }
    void SpellParchment() 
    {
        //parchment.color = Color[index].color;

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
        parchmentCircle.color = new Color(Color[indexColor].color.r, Color[indexColor].color.g + 100, Color[indexColor].color.b);

        Spell[index].enabled = true;

        if (index <= Spell.Length - 1)
        {
            Spell[index + 1].enabled = false;

        }
        
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
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            index = 1;
            Spell[0].enabled = false;
            Spell[2].enabled = false;
            Spell[3].enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            index = 2;
            Spell[0].enabled = false;
            Spell[1].enabled = false;
            Spell[3].enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            index = 3;
            Spell[2].enabled = false;
            Spell[1].enabled = false;
            Spell[0].enabled = false;
        }


    }
}
