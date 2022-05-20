using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    HealthController health;
    public Image CurrentLife;
    public Image Mana;

    public float MaxMana;
    public float CurrentMana;

    public bool HaveMana;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();

        CurrentMana = MaxMana;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentLife.fillAmount = health.currentLife / health.MaxLife;
        if (HaveMana == true) 
        {
            Mana.fillAmount = CurrentMana / MaxMana;
        }
        if(CurrentMana > MaxMana) 
        {
            CurrentMana = MaxMana;
        }
    }
}
