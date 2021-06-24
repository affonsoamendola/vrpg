using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColliderEntry
{
	string type;
	float radius;

	float offset_x;
	float offset_y;
	float offset_z;
}

public class ModelEntry
{
	string type;
	string filename;
				
	float offset_x;
	float offset_y;
	float offset_z;

	float rotation_x;
	float rotation_y;
	float rotation_z;
				  
	float scale;
}

public class TextureEntry
{
	string type;
	string file;
}

public class ObjectEntry
{
	string pre_name;
	string item_name;
	string description;

	int takeable;

	List<TextureEntry> textures;
	List<ModelEntry> models;
	List<ColliderEntry> colliders;
}

public class ObjectBank : MonoBehaviour
{	
	public List<GameObject> bank;

	/*public bool CreateObjectFromFile(string filename)
	{
		GameObject new_object;

		new_object = new GameObject();


	}*/
}
