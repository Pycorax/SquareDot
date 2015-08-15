using UnityEngine;
using System.Collections;
using UnityEditor;

public class RenderEditor : Editor 
{
    [CustomEditor(typeof(Render))]

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        /*
        Render myTarget = (Render)target;

        GameObject tile = new GameObject();

        myTarget.tileList[TILE_TYPE.TILE_NONE] = EditorGUILayout.PropertyField("Empty Tile", tile, );
            EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
         */
    }
}
