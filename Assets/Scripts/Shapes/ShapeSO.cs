using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Frontfire.Shapeshifter2
{
    public abstract class ShapeSO : ScriptableObject
    {
        [SerializeField] private Sprite shapeSprite;
        [SerializeField] private Color shapeColor;
        [SerializeField] private AudioMixerSnapshot shapeAudioSnapshot;

        public Sprite Sprite => shapeSprite;
        public Color Color => shapeColor;
        public AudioMixerSnapshot AudioMixerSnapshot => shapeAudioSnapshot;

        public abstract Vector2 Move(Vector2 position, Vector2 direction);
        public abstract Vector2 Shoot(Vector2 position, Vector2 direction);
    }
}