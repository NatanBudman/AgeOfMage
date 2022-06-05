using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour
{

    public GameObject point;

    public bool IsLoadScene;

    public string SceneName;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PJ");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLoadScene) 
        {
            point.SetActive(false);
        }
        else if (!IsLoadScene) 
        {
            SceneName = null;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PJ") && !IsLoadScene ) 
        {
            //if(Input.GetKey(KeyCode.F))
            player.transform.position = point.transform.position;
            //Camera.main.transform.position = 
            //destroyGameObject();
        }
        if(collision.gameObject.CompareTag("PJ") && IsLoadScene ) 
        {
            //if(Input.GetKey(KeyCode.F))
            SceneManager.LoadScene(SceneName);
            //destroyGameObject();
        }
    }

}
