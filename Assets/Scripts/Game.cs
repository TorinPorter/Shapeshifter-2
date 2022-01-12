using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontfire.Shapeshifter2
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private ShapesCollectionSO shapes;

        private List<Entity> entities;

        private void Start()
        {
            entities = new List<Entity>();

            foreach (Entity e in FindObjectsOfType<Entity>())
            {
                entities.Add(e);
            }
        }

        float timeOfLastShapeshift = 0;
        private void Update()
        {
            // Just to test. Changes shapes every 1 second
            if (Time.time - timeOfLastShapeshift >= 1f)
            {
                ShapeshiftAll(shapes.RandomShape());
                timeOfLastShapeshift = Time.time;
            }
        }

        private void ShapeshiftAll(ShapeSO newShape)
        {
            foreach (Entity e in entities)
            {
                e.CurrentShape = newShape;
            }
        }
    }
}