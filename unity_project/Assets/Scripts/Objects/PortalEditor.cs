using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Portal))]
public class PortalEditor : Editor //This is the code for the custom 
                                   //inspector for interacting with the Portal Class
{
    Portal selection = null;
    
    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector(); //Just uncomment to show the default inspector, 
                                  //if needed for some reason

        Portal thisPortal = (Portal)target;

        EditorGUILayout.LabelField( "Currently connected to:" );
        EditorGUILayout.ObjectField( thisPortal.currentConnection, 
                                     typeof(Portal), true);

        EditorGUILayout.LabelField("Select Portal to connect to:");
        selection = (Portal)EditorGUILayout.ObjectField(selection, 
                                                        typeof(Portal), true);

        EditorGUILayout.Toggle( "Is Visible?", 
                                thisPortal.GetRenderer().isVisible);

        if(GUILayout.Button("Connect"))
        {
            if(selection != null)
            {
                thisPortal.ConnectTo(selection); 

                //Update scene
                Utility.DirtyChangesToScene(thisPortal);
                Utility.DirtyChangesToScene(selection);
            } 
        }

        if(GUILayout.Button("Disconnect"))
        {
            if(thisPortal.currentConnection != null)
            {
                //Mark as dirty before the disconnect happens, so reference is not lost
                Utility.DirtyChangesToScene(thisPortal.currentConnection);
        
                thisPortal.Disconnect(); 

                 //Update scene
                Utility.DirtyChangesToScene(thisPortal);
            }
        }
    }
}
