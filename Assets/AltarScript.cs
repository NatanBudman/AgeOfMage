using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AltarScript : MonoBehaviour
{
    BarraDeVida barra;
    HealthController health;
    [SerializeField] Image LoadBar;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Image[] canvas;
    [SerializeField] float FullBar;
    [SerializeField] float VelocityLoadBar;
    public bool IsComplete;
    public float CurrentLoad;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        barra = GetComponent<BarraDeVida>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.currentLife <= 0 && !IsComplete)
        {
            SceneManager.LoadScene("Lose");
        }

        LoadBar.fillAmount = CurrentLoad / FullBar;

        if (CurrentLoad > FullBar) 
        {
            IsComplete = true;
        }
        if(!IsComplete)
            CurrentLoad += VelocityLoadBar * Time.deltaTime;
        if (IsComplete) 
        {
            sprite.sortingLayerName = "Personajes";
            Destroy(health);
            Destroy(barra);
            for (int i = 0; i < canvas.Length; i++) 
            {
                canvas[i].gameObject.SetActive(false);
            }

        }
        if (IsComplete) 
        {
            this.gameObject.tag = "Wall";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullets") 
        {
            health.currentLife -= 10;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            health.GetDamage(20);
            Destroy(collision.gameObject);
        }
    }
}
