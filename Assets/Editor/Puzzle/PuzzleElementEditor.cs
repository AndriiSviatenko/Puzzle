using _Project.Scripts.Puzzles;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PuzzleElement))]
public class PuzzleElementEditor : Editor
{
    private const string BUTTON_HEADER = "Open Transition Editor";

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PuzzleElement puzzleElement = (PuzzleElement)target;

        if (GUILayout.Button(BUTTON_HEADER))
        {
            TransitionEditorWindow.ShowWindow(puzzleElement);
        }
    }
}