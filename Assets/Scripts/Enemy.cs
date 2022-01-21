using UnityEngine;

namespace Frontfire.Shapeshifter2
{
    public class Enemy : Entity
    {
        [SerializeField] private float shootingDistance;
        private Transform playerTransform;

        private void Update()
        {
            LookAt(playerTransform.position);
            if (DistanceFromPlayer() <= shootingDistance)
            {
                Shoot();
            }
            else
            {
                MoveTowardsPlayer();
            }
        }

        private void MoveTowardsPlayer()
        {
            Velocity = (playerTransform.position - transform.position).normalized;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            playerTransform = FindObjectOfType<Player>().transform;
        }

        private float DistanceFromPlayer()
        {
            return (playerTransform.position - this.transform.position).magnitude;
        }
    }
}
