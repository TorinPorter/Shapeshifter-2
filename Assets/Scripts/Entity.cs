using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontfire.Shapeshifter2
{
    public abstract class Entity : MovingObject
    {
        private ShapeSO _currentShape;
        public ShapeSO CurrentShape
        {
            get { return _currentShape; }

            set
            {
                spriteRenderer.sprite = value.Sprite;
                spriteRenderer.color = value.Color;

                _currentShape = value;
            }
        }

        [SerializeField]
        private float _moveSpeed;
        public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

        [SerializeField] private GameObject projectile;
        protected bool canShoot;
        public float shootCooldown;

        protected override void OnEnable()
        {
            base.OnEnable();
            canShoot = true;
        }

        public void LookTowards(Vector2 direction)
        {
            rigidbody.rotation = Vector2.SignedAngle(Vector2.up, direction);
        }

        public void LookAt(Vector2 target)
        {
            LookTowards(target - (Vector2)transform.position);
        }

        public void Shoot()
        {
            if (canShoot)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                StartCoroutine(ShootCooldown());
            }
        }

        protected IEnumerator ShootCooldown()
        {
            canShoot = false;
            yield return new WaitForSeconds(shootCooldown);
            canShoot = true;
        }

    }
}