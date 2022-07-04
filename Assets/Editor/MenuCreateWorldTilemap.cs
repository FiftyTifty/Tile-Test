using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using FiftyTifty.Tilemaps;

public class MenuCreateWorldTilemap : EditorWindow
{

	//Add a menu entry that will bring up the World Tilemap creation window
    [MenuItem("FiftyTifty/World/Create World Tilemap")]
    static void menuCreateWorldTilemap()
	{

		EditorWindow windowCreateWorldTilemap = (MenuCreateWorldTilemap) EditorWindow.GetWindow(typeof(MenuCreateWorldTilemap), true, "Create World Tilemap", true);
		windowCreateWorldTilemap.titleContent = new GUIContent("Create World Tilemap");

	}

	[MenuItem("FiftyTifty/World/Create World Tilemap", true)]
	private static bool menuCreateWorldTilemap_Check()
	{
		return GameObject.Find("tilemapWorld") == false;
	}

	private static void CreateWorldTilemap()
	{

		GameObject tilemapWorld = new GameObject("tilemapWorld");
		tilemapWorld.Add

	}

	private void OnGUI()
	{

		EditorGUILayout.Vector2IntField("Tilemap Size", new Vector2Int (1, 1));

		if (GUI.Button(new Rect(60,60, 200, 50), "Create World Tilemap"))
		{
			Debug.Log("Clicked");
		}

	}

}
