using _Project.Scripts.Puzzles;
using _Project.Scripts.Services.Grid;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Services.PathValidator
{
    public class PathValidator
    {
        private const int MIN_COUNT_TO_CHECK = 3;
        private PuzzleGrid _grid;

        public PathValidator(PuzzleGrid grid) =>
            _grid = grid;

        public void UpdatePath(List<PuzzleElement> path, PuzzleElement puzzle)
        {
            var up = _grid.GetUpperNeighbor(puzzle);
            var down = _grid.GetLowerNeighbor(puzzle);
            var left = _grid.GetLeftNeighbor(puzzle);
            var right = _grid.GetRightNeighbor(puzzle);

            if (puzzle.CheckColision(up, down, left, right))
            {
                puzzle.SetColor(Color.green);

                if (!path.Contains(puzzle))
                {
                    path.Add(puzzle);
                }
            }
            else
            {
                puzzle.SetColor(Color.red);
            }

            if (path.Count > MIN_COUNT_TO_CHECK)
                CheckPathOrder(path);
        }

        private void CheckPathOrder(List<PuzzleElement> path)
        {
            for (int i = 0; i < path.Count; i++)
            {
                bool isConnected = true;

                if (i > 0)
                {
                    var prevNeighbors = _grid.GetNeighbors(path[i]);
                    if (prevNeighbors.Count > i)
                    {
                        if (!path[i].CheckColision(prevNeighbors[0], prevNeighbors[1], prevNeighbors[2], prevNeighbors[3]))
                        {
                            isConnected = false;
                        }
                    }
                }

                if (i < path.Count - 1)
                {
                    var nextNeighbors = _grid.GetNeighbors(path[i]);
                    if (nextNeighbors.Count > i)
                    {
                        if (!path[i].CheckColision(nextNeighbors[0], nextNeighbors[1], nextNeighbors[2], nextNeighbors[3]))
                        {
                            isConnected = false;
                        }
                    }
                }

                if (!isConnected)
                {
                    for (int j = i; j < path.Count; j++)
                    {
                        path[j].SetColor(Color.red);
                    }
                    path.RemoveRange(i, path.Count - i);
                    break;
                }
            }
        }
    }
}
