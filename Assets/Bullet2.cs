using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Damage;
    public float SplashRange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (SplashRange > 0)
            {
                GetComponent<ParticleSystem>().Play();
                var hitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
                foreach (var hitCollider in hitColliders)
                {
                    var enemy = hitCollider.GetComponent<EnemyScript>();
                    if (enemy)
                    {
                        var closestPoint = hitCollider.ClosestPoint(transform.position);
                        var distance = Vector3.Distance(closestPoint, transform.position);

                        var damagePercent = Mathf.InverseLerp(SplashRange, 0, distance);
                        enemy.TakeHit(damagePercent * Damage);
                    }
                }
            }
            else
            {
                var enemy = collision.GetComponent<EnemyScript>();
                if (enemy)
                {
                    enemy.TakeHit(Damage);
                }
            }
            Destroy(gameObject, 1f);
        }
    }
}
