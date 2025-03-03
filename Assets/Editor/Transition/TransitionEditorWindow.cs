using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Conditions.Configs;
using _Project.Scripts.Puzzles;

public class TransitionEditorWindow : EditorWindow
{
    private const string NAME_WINDOW = "Transition Editor";
    private const string ADD_BUTTON_HEADER = "Add Transition";

    private const string NONE_HEADER = "No target selected!";
    private const string FROM_TYPE_HEADER = "From Type";
    private const string TO_TYPE_HEADER = "To Type";
    private const string FROM_DIRECTIONS_HEADER = "From Directions";
    private const string CREATE_NEW_TRANSITION_HEADER = "Create New Transition";
    private const string TO_DIRECTIONS_HEADER = "To Directions";
    private const string TRANSITIONS_DIRECTION_HEADER = "Transition Direction";
    private const string EXISTING_HEADER = "Existing Transitions";

    private const string TITLE_PATH_HEADER = "Save Transition";
    private const string DEFAULT_NAME_PATH_HEADER = "NewTransition";
    private const string EXTENSION_PATH_HEADER = "asset";
    private const string MESSAGE_PATH_HEADER = "Save transition";

    private ElementType _fromType;
    private ElementType _toType;
    private Direction[] _fromDirections;
    private Direction[] _toDirections;
    private TransitionDirection _selectedTransitionDirection;
    private PuzzleElement _targetElement;
    private List<TransitionCondition> _transitions = new();

    public static void ShowWindow(PuzzleElement target)
    {
        var window = GetWindow<TransitionEditorWindow>(NAME_WINDOW);
        window._targetElement = target;
    }

    private void OnGUI()
    {
        if (_targetElement == null)
        {
            GUILayout.Label(NONE_HEADER);
            return;
        }

        GUILayout.Label(CREATE_NEW_TRANSITION_HEADER, EditorStyles.boldLabel);

        _fromType = (ElementType)EditorGUILayout.EnumPopup(FROM_TYPE_HEADER, _fromType);
        _toType = (ElementType)EditorGUILayout.EnumPopup(TO_TYPE_HEADER, _toType);

        GUILayout.Label(FROM_DIRECTIONS_HEADER);
        _fromDirections = DrawDirectionMultiSelect(_fromDirections);

        GUILayout.Label(TO_DIRECTIONS_HEADER);
        _toDirections = DrawDirectionMultiSelect(_toDirections);

        _selectedTransitionDirection = (TransitionDirection)EditorGUILayout.EnumPopup(TRANSITIONS_DIRECTION_HEADER, _selectedTransitionDirection);

        if (GUILayout.Button(ADD_BUTTON_HEADER))
        {
            AddTransition();
        }

        GUILayout.Label(EXISTING_HEADER, EditorStyles.boldLabel);
        foreach (var transition in _transitions)
        {
            EditorGUILayout.LabelField(transition.name);
        }
    }

    private Direction[] DrawDirectionMultiSelect(Direction[] selectedDirections)
    {
        var allDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToArray();
        if (selectedDirections == null) selectedDirections = Array.Empty<Direction>();

        foreach (var direction in allDirections)
        {
            bool isSelected = selectedDirections.Contains(direction);
            bool newSelection = EditorGUILayout.Toggle(direction.ToString(), isSelected);

            if (newSelection && !isSelected)
            {
                selectedDirections = selectedDirections.Concat(new[] { direction }).ToArray();
            }
            else if (!newSelection && isSelected)
            {
                selectedDirections = selectedDirections.Where(d => d != direction).ToArray();
            }
        }

        return selectedDirections;
    }

    private void AddTransition()
    {
        var transition = CreateInstance<TransitionCondition>();
        transition.FromType = _fromType;
        transition.ToType = _toType;
        transition.FromDirections = _fromDirections;
        transition.ToDirections = _toDirections;

        string path = EditorUtility.SaveFilePanelInProject(TITLE_PATH_HEADER, DEFAULT_NAME_PATH_HEADER, EXTENSION_PATH_HEADER, MESSAGE_PATH_HEADER);
        if (!string.IsNullOrEmpty(path))
        {
            AssetDatabase.CreateAsset(transition, path);
            AssetDatabase.SaveAssets();

            switch (_selectedTransitionDirection)
            {
                case TransitionDirection.Up:
                    _targetElement.upConditions.Add(transition);
                    break;
                case TransitionDirection.Down:
                    _targetElement.downConditions.Add(transition);
                    break;
                case TransitionDirection.Left:
                    _targetElement.leftConditions.Add(transition);
                    break;
                case TransitionDirection.Right:
                    _targetElement.rightConditions.Add(transition);
                    break;
            }

            _transitions.Add(transition);
            Debug.Log($"Transition saved and added to {_selectedTransitionDirection} list!");
        }
    }
}