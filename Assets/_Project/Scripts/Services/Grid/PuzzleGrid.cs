using _Project.Scripts.Puzzles;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Services.Grid
{
    public class PuzzleGrid : MonoBehaviour
    {
        [SerializeField] private int rows;
        [SerializeField] private int columns;
        [SerializeField] private Vector2 cellSize;
        [SerializeField] private Vector2 padding;
        [SerializeField] private Vector2 spacing;

        private List<PuzzleElement> _puzzles = new ();
        private List<PuzzleElement> _neighbors = new ();

        public void ArrangeGrid()
        {
            _puzzles.Clear();

            foreach (var puzzle in transform.GetComponentsInChildren<PuzzleElement>())
            {
                if (puzzle != null)
                {
                    if (!_puzzles.Contains(puzzle))
                    {
                        _puzzles.Add(puzzle);
                    }
                }
            }

            for (int i = 0; i < _puzzles.Count; i++)
            {
                int x = i % columns;
                int y = i / columns;

                Vector2 position = new Vector2
                (
                    padding.x + x * (cellSize.x + spacing.x),
                    padding.y + y * (cellSize.y + spacing.y)
                );

                _puzzles[i].transform.localPosition = position;

                Debug.Log($"Element {i}: {_puzzles[i].transform.localPosition}");
            }
        }


        public List<PuzzleElement> GetNeighbors(PuzzleElement targetElement)
        {
            int index = _puzzles.IndexOf(targetElement);

            if (index == -1)
                return new List<PuzzleElement>();

            _neighbors.Clear();

            PuzzleElement upper = GetUpperNeighbor(targetElement);

            if (upper != null)
                _neighbors.Add(upper);

            PuzzleElement lower = GetLowerNeighbor(targetElement);

            if (lower != null)
                _neighbors.Add(lower);

            PuzzleElement left = GetLeftNeighbor(targetElement);

            if (left != null)
                _neighbors.Add(left);

            PuzzleElement right = GetRightNeighbor(targetElement);

            if (right != null)
                _neighbors.Add(right);

            return _neighbors;
        }

        public PuzzleElement GetUpperNeighbor(PuzzleElement targetElement)
        {
            int index = _puzzles.IndexOf(targetElement);

            if (index == -1)
                return null;

            int y = index / columns;
            if (y < rows - 1)
            {
                int upIndex = index + columns;
                return (upIndex < _puzzles.Count) ? _puzzles[upIndex] : null;
            }
            return null;
        }

        public PuzzleElement GetLowerNeighbor(PuzzleElement targetElement)
        {
            int index = _puzzles.IndexOf(targetElement);

            if (index == -1)
                return null;

            int y = index / columns;
            if (y > 0)
            {
                int downIndex = index - columns;
                return (downIndex >= 0) ? _puzzles[downIndex] : null;
            }
            return null;
        }

        public PuzzleElement GetLeftNeighbor(PuzzleElement targetElement)
        {
            int index = _puzzles.IndexOf(targetElement);

            if (index == -1)
                return null;

            int x = index % columns;
            if (x > 0)
            {
                int leftIndex = index - 1;
                return _puzzles[leftIndex];
            }
            return null;
        }

        public PuzzleElement GetRightNeighbor(PuzzleElement targetElement)
        {
            int index = _puzzles.IndexOf(targetElement);

            if (index == -1)
                return null;

            int x = index % columns;
            if (x < columns - 1)
            {
                int rightIndex = index + 1;
                return (rightIndex < _puzzles.Count) ? _puzzles[rightIndex] : null;
            }
            return null;
        }
    }

}
