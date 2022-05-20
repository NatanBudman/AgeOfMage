using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePlayer : MonoBehaviour
{
    GameObject player;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PJ");
        SawPlayer(player);
    }

    // Update is called once per frame
    void Update()
    {
        //SawPlayer(player);
    }
    void SawPlayer(GameObject See)
    {
        Vector2 lookDir = See.transform.position - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;

        rb.rotation = angle;
    }
}
