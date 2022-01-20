using System.Collections;
using UnityEngine;

namespace Frontfire.Shapeshifter2
{
    public class Player : Entity
    {
        [SerializeField] private GameObject projectile;

        private bool canShoot;

        public float shootCooldown;
        public Vector2 LookAtPoint { get; set; }

        private void Awake()
        {
            canShoot = true;
        }

        public void LookTowards(Vector2 direction)
        {
            rigidbody.rotation = Vector2.SignedAngle(Vector2.up, direction);
        }

        public void LookAt(Vector2 target)
        {
            LookTowards(target - (Vector2) transform.position);
        }

        public void Shoot()
        {
            if (canShoot)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                StartCoroutine(ShootCooldown());
            }
        }

        private IEnumerator ShootCooldown()
        {
            canShoot = false;
            yield return new WaitForSeconds(shootCooldown);
            canShoot = true;
        }
    }
}