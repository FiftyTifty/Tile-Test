using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuCreateWorldTilemap : EditorWindow
{

	//Add a menu entry that will bring up the World Tilemap creation window
    [MenuItem("FiftyTifty/World/Create World Tilemap")]
    static void menuCreateWorldTilemap()
	{

		EditorWindow windowCreateWorldTilemap = (MenuCreateWorldTilemap) EditorWindow.GetWindow(typeof(MenuCreateWorldTilemap), true, "Create World Tilemap");
		windowCreateWorldTilemap.titleContent = new GUIContent("Create World Tilemap");

	}

	[MenuItem("FiftyTifty/World/Create World Tilemap", false)]
	private static bool menuCreateWorldTilemap_Check()
	{
		return GameObject.Find("tilemapWorld");
	}

}
