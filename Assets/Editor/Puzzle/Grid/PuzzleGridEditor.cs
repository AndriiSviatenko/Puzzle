using UnityEngine;
using UnityEditor;
using _Project.Scripts.Services.Grid;

#if UNITY_EDITOR
[CustomEditor(typeof(PuzzleGrid))]
public class PuzzleGridEditor : Editor
{
    private const string BUTTON_HEADER = "Arrange Grid";

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PuzzleGrid script = (PuzzleGrid)target;
        if (GUILayout.Button(BUTTON_HEADER))
        {
            script.ArrangeGrid();
            EditorUtility.SetDirty(script);
        }
    }
}
#endif
