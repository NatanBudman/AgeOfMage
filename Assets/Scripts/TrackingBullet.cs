using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBullet : MonoBehaviour
{
    private GameObject enemy;
    private int speed = 20;
    private TimeManager timemanager;
    void Start()
    {
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    private GameObject FindClosestEnemy()
    {
        try
        {
            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject enemy in enemies)
            {
                Vector3 diff = enemy.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = enemy;
                    distance = curDistance;
                }
            }
            return closest;
        }
        catch
        {
            return null;
        }
    }

    void Update()
    {
        if (enemy == null)
        {
            enemy = FindClosestEnemy();
        }
        if (enemy != null)
        {
            MoveTowardsEnemy();
        }
        else
        {
            transform.Translate(Vector3.up * (speed / 2) * Time.deltaTime);
        }
    }

    private void MoveTowardsEnemy()
    {
        if (timemanager.TimeIsStopped == false)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                enemy.transform.position, speed * Time.deltaTime);
            Vector3 offset = transform.position - enemy.transform.position;

            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), offset);

            if (Vector3.Distance(transform.position, enemy.transform.position) < 0.001f)
            {
                enemy.transform.position *= 1.0f;
            }
        }
    }
}
