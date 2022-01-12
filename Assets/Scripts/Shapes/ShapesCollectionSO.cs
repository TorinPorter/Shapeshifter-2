using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Frontfire.Shapeshifter2 
{
    [CreateAssetMenu()]
    public class ShapesCollectionSO : ScriptableObject
    {
        [SerializeField] private VerticalLineSO verticalLine;
        [SerializeField] private HorizontalLineSO horizontalLine;
        [SerializeField] private TriangleSO triangle;
        [SerializeField] private SquareSO square;
        [SerializeField] private PentagonSO pentagon;
        [SerializeField] private HexagonSO hexagon;
        [SerializeField] private HeptagonSO heptagon;
        [SerializeField] private OctagonSO octagon;
        [SerializeField] private CircleSO circle;

        private ShapeSO[] shapesArray;
        private bool shapesArrayInitialized = false;

        private void Awake()
        {
            InitShapesArray();
        }

        public ShapeSO VerticalLine => verticalLine;
        public ShapeSO HorizontalLine => horizontalLine;
        public ShapeSO Triangle => triangle;
        public ShapeSO Square => square;
        public ShapeSO Pentagon => pentagon;
        public ShapeSO Hexagon => hexagon;
        public ShapeSO Heptagon => heptagon;
        public ShapeSO Octagon => octagon;
        public ShapeSO Circle => circle;
        public ShapeSO[] AllShapes => (ShapeSO[])shapesArray.Clone();

        public ShapeSO RandomShape()
        {
            if (shapesArray == null)
            {
                InitShapesArray();
            }

            return shapesArray[Random.Range(0, shapesArray.Length)];
        }

        private void InitShapesArray()
        {
            shapesArray = new ShapeSO[9];
            shapesArray[0] = verticalLine;
            shapesArray[1] = horizontalLine;
            shapesArray[2] = triangle;
            shapesArray[3] = square;
            shapesArray[4] = pentagon;
            shapesArray[5] = hexagon;
            shapesArray[6] = heptagon;
            shapesArray[7] = octagon;
            shapesArray[8] = circle;
        }
    }
}