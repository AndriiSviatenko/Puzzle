using _Project.Scripts.Conditions.Configs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Puzzles
{
    public class PuzzleElement : MonoBehaviour
    {
        [SerializeField] public SpriteRenderer spriteRenderer;
        [SerializeField] public ElementType elementType;
        [SerializeField] public Direction direction;
        [SerializeField] public bool isConnected;

        public List<TransitionCondition> upConditions = new();
        public List<TransitionCondition> downConditions = new();
        public List<TransitionCondition> leftConditions = new();
        public List<TransitionCondition> rightConditions = new();
        public bool IsConnectedToPath { get => isConnected; set => isConnected = value; }

        private void OnValidate()
        {
            if (direction == Direction.First)
            {
                Vector3 rotationAngles = new Vector3(0, 0, 0);
                transform.rotation = Quaternion.Euler(rotationAngles);
            }
            else if (direction == Direction.Second)
            {
                Vector3 rotationAngles = new Vector3(0, 0, 90);
                transform.rotation = Quaternion.Euler(rotationAngles);
            }
            else if (direction == Direction.Third)
            {
                Vector3 rotationAngles = new Vector3(0, 0, 180);
                transform.rotation = Quaternion.Euler(rotationAngles);
            }
            else if (direction == Direction.Four)
            {
                Vector3 rotationAngles = new Vector3(0, 0, 270);
                transform.rotation = Quaternion.Euler(rotationAngles);
            }

        }
        public void RotateElement()
        {
            if (direction == Direction.Four)
            {
                Vector3 rotationAngles = new Vector3(0, 0, 0);
                transform.rotation = Quaternion.Euler(rotationAngles);
            }
            else
            {
                transform.Rotate(0, 0, 90);
            }

            if (transform.rotation.eulerAngles == Vector3.zero)
            {
                direction = Direction.First;
            }
            else if (transform.rotation.eulerAngles == new Vector3(0, 0, 90))
            {
                direction = Direction.Second;
            }
            else if (transform.rotation.eulerAngles == new Vector3(0, 0, 180))
            {
                direction = Direction.Third;
            }
            else if (transform.rotation.eulerAngles == new Vector3(0, 0, 270))
            {
                direction = Direction.Four;
            }
        }
        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }
        public bool CheckColision(PuzzleElement up, PuzzleElement down, PuzzleElement left, PuzzleElement right)
        {
            return CheckConnection(this, up, upConditions) || CheckConnection(this, down, downConditions)
                || CheckConnection(this, left, leftConditions) || CheckConnection(this, right, rightConditions);
        }
        public bool CheckConnection(PuzzleElement from, PuzzleElement to, List<TransitionCondition> conditions)
        {
            foreach (var condition in conditions)
            {
                if (condition.CanApply(from, to))
                {
                    if (from != null && to != null)
                    {
                        if (from.elementType == ElementType.Start)
                            return IsConnectedToPath = true;

                        if (condition.IsConnected(to))
                        {
                            IsConnectedToPath = true;
                            return true;
                        }
                    }
                }
            }
            IsConnectedToPath = false;
            return false;
        }
    }
}

