using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[InitializeOnLoad]
public class CustomPreferens {
	
	const string CONST_KEY_SHOW_HIERARCHY_ICON = "KEY_SHOW_HIERARCHY_ICON";
	
	private static bool 	g_IsLoaded = false;
	private static bool 	g_IsShowHierarchyIcon = false;

	// -----------------------------------------------------------------------------------------------
	// コンストラクタ .
	// -----------------------------------------------------------------------------------------------
	static CustomPreferens () {
		OnLoaded();
	}

	// -----------------------------------------------------------------------------------------------
	// GUI表示 .
	// -----------------------------------------------------------------------------------------------
	[PreferenceItem("CustomPreferens")]
	public static void PreferecesGUI () {
		
		// 情報をロードする .
		OnLoaded();
		
		// ヒエラルキー上にアイコンを表示するかどうかのフラグ .
		g_IsShowHierarchyIcon = EditorGUILayout.Toggle( "Show Hierarchy Icon", g_IsShowHierarchyIcon );
		
		
		// 情報を保存する . 
		if ( GUI.changed == true )
		{
			OnSave();
		}			
	}
	
	// -----------------------------------------------------------------------------------------------
	// ヒエラルキー上にアイコンを表示するかどうか .
	// @return bool - true(する)/false(しない) .
	// -----------------------------------------------------------------------------------------------	
	public static bool IsShowHIerarchyIcon () {
		return g_IsShowHierarchyIcon;
	}
	
	// -----------------------------------------------------------------------------------------------
	// ロード .
	// -----------------------------------------------------------------------------------------------	
	private static void OnLoaded () {
		
		if ( g_IsLoaded == true )
		{
			return;
		}
		
		g_IsLoaded = true;
		
		g_IsShowHierarchyIcon = EditorPrefs.GetBool( CONST_KEY_SHOW_HIERARCHY_ICON );
	}

	// -----------------------------------------------------------------------------------------------
	// 保存 .
	// -----------------------------------------------------------------------------------------------
	private static void OnSave () {
		
		EditorPrefs.SetBool( CONST_KEY_SHOW_HIERARCHY_ICON, g_IsShowHierarchyIcon );
		
	}

}
