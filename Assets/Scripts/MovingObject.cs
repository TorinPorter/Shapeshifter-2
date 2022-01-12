using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontfire.Shapeshifter2
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class MovingObject : MonoBehaviour
    {
        public Vector2 Velocity { get; set; }

        protected new Rigidbody2D rigidbody;
        protected SpriteRenderer spriteRenderer;

        protected virtual void OnEnable()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            Velocity = Vector2.zero;
        }

        protected virtual void FixedUpdate()
        {
            rigidbody.position += Velocity * Time.deltaTime;
        }
    }
}