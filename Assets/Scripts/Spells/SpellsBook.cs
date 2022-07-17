using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewSpell",menuName ="Spells")]
public class SpellsBook : ScriptableObject
{
    public string spellName;
    public string description;
    public GameObject Book;
    public string mana;
    public string attack;
    public int cost;
    public bool IsBoughtBook;
    public string TypeSpell;
    public string Efectos;

}
