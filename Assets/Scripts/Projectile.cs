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
    }
}
