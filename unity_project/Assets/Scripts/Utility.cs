using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public static class Utility
{
    public static void DirtyChangesToScene(MonoBehaviour altered_object)
    {
        EditorUtility.SetDirty(altered_object);
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }               
}
