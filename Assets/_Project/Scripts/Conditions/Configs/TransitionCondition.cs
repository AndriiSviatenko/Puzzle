using System.Linq;
using System;
using UnityEngine;
using _Project.Scripts.Puzzles;

namespace _Project.Scripts.Conditions.Configs
{
    [CreateAssetMenu(fileName = "NewTransition", menuName = "Puzzle/Transition")]
    public class TransitionCondition : ScriptableObject
    {
        public ElementType FromType;
        public ElementType ToType;
        public Direction[] FromDirections;
        public Direction[] ToDirections;

        public bool CheckDirections(Direction from, Direction to) =>
            FromDirections.Contains(from) && ToDirections.Contains(to);

        public bool CanApply(PuzzleElement from, PuzzleElement to)
        {
            if (from == null || to == null)
                return false;

            if (FromType == from.elementType && ToType == to.elementType)
                return CheckDirections(from.direction, to.direction);

            return false;
        }

        public bool IsConnected(PuzzleElement to) =>
            to.IsConnectedToPath;
    }
}