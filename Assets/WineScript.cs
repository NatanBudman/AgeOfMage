using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineScript : MonoBehaviour
{
    [SerializeField] float SpeedToElusive;
    [SerializeField] float Expand;
    [SerializeField] float TimeToDestroy;
    float CurrenTimeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrenTimeToDestroy += Time.deltaTime;
        Expand = Mathf.Clamp(Expand, 0.1f, 4);
        Expand += SpeedToElusive * Time.deltaTime;
        this.gameObject.transform.localScale = new Vector3(Expand,Expand,1);

        if (CurrenTimeToDestroy >= TimeToDestroy) 
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<State>()) 
        {
            collision.GetComponent<State>().Speed = 12;
        }
        if (collision.GetComponent<Elements>().SpellElement == "Agua") 
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            collision.GetComponent<State>().Speed = collision.GetComponent<State>().MaxSpeed;

    }
}
