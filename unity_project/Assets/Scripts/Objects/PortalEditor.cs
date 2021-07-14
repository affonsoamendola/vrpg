using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Portal))]
public class PortalEditor : Editor
{
    Portal selection = null;
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Portal this_portal = (Portal)target;

        EditorGUILayout.LabelField("Currently connected to:");
        EditorGUILayout.ObjectField(this_portal.current_connection, typeof(Portal), true);

        EditorGUILayout.LabelField("Select Portal to connect to:");
        selection = (Portal)EditorGUILayout.ObjectField(selection, typeof(Portal), true);

        EditorGUILayout.Toggle("Is Visible?", this_portal.getRenderer().isVisible);

        if(GUILayout.Button("Connect"))
        {
            if(selection != null)
            {
                this_portal.ConnectTo(selection); 

                //Update scene
                Utility.DirtyChangesToScene(this_portal);
                Utility.DirtyChangesToScene(selection);
            } 
        }

        if(GUILayout.Button("Disconnect"))
        {
            if(this_portal.current_connection != null)
            {
                //Mark as dirty before the disconnect happens, so reference is not lost
                Utility.DirtyChangesToScene(this_portal.current_connection);
        
                this_portal.Disconnect(); 

                 //Update scene
                Utility.DirtyChangesToScene(this_portal);
            }
        }
    }
}
