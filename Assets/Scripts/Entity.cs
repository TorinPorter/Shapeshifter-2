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


    }
}