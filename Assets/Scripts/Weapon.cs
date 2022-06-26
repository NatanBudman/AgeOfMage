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
    public GameObject healingCircle;
    public GameObject earthWall;
    public GameObject windProjectile;

    public AudioSource DashSound;
    [SerializeField] private float weaponRange = 10f;


    public float fireForce;
    //public float fireForce2;
    public LayerMask enemyLayers;
    public float meleeRange = 1f;
    public int meleeDamage = 15;

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
            NormalSpell();
        }
        if (SpellSelected.index == 1)
        {
            FireBolt();
        }
        if (SpellSelected.index == 2)
        {
            Water();
        }
        if (SpellSelected.index == 3)
        {
            lightning();
        }
    }

    void NormalSpell()
    {

    }

    void FireBolt()
    {
        SpellCost = 5;
        GameObject projectile = Instantiate(fireBolt, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
    public void Wind()
    {
        GameObject wind;
        wind = Instantiate(windProjectile, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation) as GameObject;
    }
    void Water()
    {
        SpellCost = 10;
        Instantiate(WaterSpell, transform.position + new Vector3(0, 1.4f, 0), Quaternion.identity);
    }

    public void Wall()
    {
        Instantiate(earthWall, firePoint.position, firePoint.rotation);
    }
    void lightning()
    {
        SpellCost = 15;
        GameObject projectile = Instantiate(lightningSpell, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    public void Melee()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(firePoint.position, meleeRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyScript>().TakeHit(meleeDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (firePoint == null)
            return;

        Gizmos.DrawWireSphere(firePoint.position, meleeRange);
    }

    public void Heal()
    {
        GameObject projectile = Instantiate(healingCircle, firePoint.position, firePoint.rotation);
    }
    void Dash()
    {
        DashSound.Play();
        SpellCost = 100;
        player.transform.position = target.position;
    }
}
