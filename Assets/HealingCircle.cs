using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCircle : MonoBehaviour
{
    HealthController playerHealth;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PJ");
        playerHealth = player.GetComponent<HealthController>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name.Equals("Player") && playerHealth.currentLife < playerHealth.MaxLife)
            StartCoroutine("Heal");
        Destroy(gameObject, 2f);
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.name.Equals("Player"))
            StopCoroutine("Heal");
    }

    IEnumerator Heal()
    {
         for (float currentHealth = playerHealth.currentLife; currentHealth <= playerHealth.MaxLife; currentHealth += 0.10f)
        {
            playerHealth.currentLife = currentHealth;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        playerHealth.currentLife = playerHealth.MaxLife;
    }
}
