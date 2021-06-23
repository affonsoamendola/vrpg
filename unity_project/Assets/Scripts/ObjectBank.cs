using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectEntry
{
    public int id;
    public string location;
}

[System.Serializable]
public class ObjectList
{
    public ObjectEntry[] objects;
}

public class ObjectBank : MonoBehaviour
{   
    public Dictionary<int, GameObject> bank;

    public TextAsset object_list;

    void Start()
    {
        ObjectList list = JsonUtility.FromJson<ObjectList>(object_list.text);
        
        bank = new Dictionary<int, GameObject>();

        foreach(ObjectEntry object_ in list.objects)
        {
            bank.Add(object_.id, Resources.Load(object_.location) as GameObject);
        }
    }
}
