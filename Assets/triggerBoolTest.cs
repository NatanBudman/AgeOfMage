using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerBoolTest : MonoBehaviour
{
    public SpellSelected spells;
    public SpellsBook []book;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spells.hasFire = true;
    }
}
