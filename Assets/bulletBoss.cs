using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBoss : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Damage = 1;
    public float SplashRange = 0;
    private Vector2 moveDirection;
    private float moveSpeed;

    void Start()
    {
        moveSpeed = 10f;
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PJ") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Bullets"))
        {
            if (SplashRange > 0)
            {
                GetComponent<ParticleSystem>().Play();
                var hitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
                foreach (var hitCollider in hitColliders)
                {
                    var player = hitCollider.GetComponent<HealthController>();
                    if (player)
                    {
                        var closestPoint = hitCollider.ClosestPoint(transform.position);
                        var distance = Vector3.Distance(closestPoint, transform.position);

                        var damagePercent = Mathf.InverseLerp(SplashRange, 0, distance);
                        player.GetDamage(damagePercent * Damage);
                    }
                }
            }
            else
            {
                var player = collision.GetComponent<HealthController>();
                if (player)
                {
                    player.GetDamage(Damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
