using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Frontfire.Shapeshifter2
{
    public enum ShapeMovementType
    {
        Free,
        FreeFast,
        FixedPosition,
        Vertical,
        Horizontal,
        FixedDirection,
    }

    public enum ShapeShootType
    {
        None,
        Free,
        Vertical,
        Horizontal,
        FixedDirection,
        AllDirections,
        Cycle
    }

    public abstract class ShapeSO : ScriptableObject
    {
        [SerializeField] private Sprite shapeSprite;
        [SerializeField] private Color shapeColor;
        [SerializeField] private AudioMixerSnapshot shapeAudioSnapshot;
        [SerializeField] private ShapeMovementType shapeMovementType;
        [SerializeField] private ShapeShootType shapeShootType;

        public Sprite Sprite { get { return shapeSprite; } }
        public Color Color { get { return shapeColor; } }
        public AudioMixerSnapshot AudioMixerSnapshot { get { return shapeAudioSnapshot; } }
        public ShapeMovementType ShapeMovementType { get { return shapeMovementType; } }
        public ShapeShootType ShapeShootType { get { return shapeShootType; } }

        public abstract Vector2 Move(Vector2 position, Vector2 direction);
        public abstract Vector2 Shoot(Vector2 position, Vector2 direction);
    }
}