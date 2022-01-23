using UnityEngine;

namespace Frontfire.Shapeshifter2
{
    public class Projectile : MovingObject
    {
        [SerializeField] private float moveSpeed;

        void Start()
        {
            Velocity = transform.up * moveSpeed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((collision.CompareTag("Obstacle")
                || collision.CompareTag("PlayerProjectile")
                || collision.CompareTag("EnemyProjectile"))
                && !collision.CompareTag(tag))
            {
                Destroy(gameObject);
            }
        }
    }
}
