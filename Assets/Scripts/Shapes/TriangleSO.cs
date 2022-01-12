using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontfire.Shapeshifter2
{
    [CreateAssetMenu(fileName = "Triangle", menuName = "Shape SO/Triangle")]
    public class TriangleSO : ShapeSO
    {
        public override Vector2 Move(Vector2 position, Vector2 direction)
        {
            throw new System.NotImplementedException();
        }
        public override Vector2 Shoot(Vector2 position, Vector2 direction)
        {
            throw new System.NotImplementedException();
        }
    }
}