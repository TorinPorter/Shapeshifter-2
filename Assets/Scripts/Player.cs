using UnityEngine;

namespace Frontfire.Shapeshifter2
{
    public class Player : Entity 
    {
        public int MaxHealth { get; set; }
        public int Health { get; set; }

        protected override void OnEnable()
        {
            base.OnEnable();
            Health = MaxHealth;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("EnemyProjectile"))
            {
                Destroy(collision.gameObject);
                Hit();
            }
        }

        private void Hit()
        {
            Health--;
        }
    }
}