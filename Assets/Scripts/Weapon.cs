using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


    public static int SpellCost;
    public static int SpellPositionInSelect;
    public Transform player;
    public Transform target;

    public GameObject fireBolt;
    public GameObject WaterSpell;
    public GameObject lightningSpell;
    public Transform firePoint;

    public AudioSource DashSound;
    [SerializeField] private float weaponRange = 10f;

   
    public float fireForce;
    //public float fireForce2;
    private void Start()
    {
    }
    public void Fire()
    {
        Spells();
        
    }

    public void Spells() 
    {
        if (SpellSelected.index == 0) 
        {
            FireBolt();
        }
        if (SpellSelected.index == 2) 
        {
            Water();
        }
        if (SpellSelected.index == 1) 
        {
            Dash();
        }
        if (SpellSelected.index == 3)
        {
            lightning();
        }
    }

    void FireBolt() 
    {
        SpellCost = 5;
        GameObject projectile = Instantiate(fireBolt, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
    void Water() 
    {
        SpellCost = 10;
        Instantiate(WaterSpell, transform.position + new Vector3(0, 1.4f, 0), Quaternion.identity);
    }
    void lightning() 
    {
        SpellCost = 15;
        GameObject projectile = Instantiate(lightningSpell, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
    void Dash() 
    {
        DashSound.Play();
        SpellCost = 100;
        player.transform.position = target.position;
    }
}
