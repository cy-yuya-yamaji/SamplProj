using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[InitializeOnLoad]
public class CustomHierarchyView {

	// -----------------------------------------------------------------------------------------------
	// コンストラクタ .
	// -----------------------------------------------------------------------------------------------
	static CustomHierarchyView () {
		EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyComponentIcons;
	}

	// -----------------------------------------------------------------------------------------------
	// ヒエラルキー上にコンポーネントアイコン表示する .
	// @param instanceID - インスタンスID .
	// @param rect       - 表示領域 .
	// -----------------------------------------------------------------------------------------------
	static void DrawHierarchyComponentIcons ( int instanceID, Rect rect ) {
		
		if ( CustomPreferens.IsShowHIerarchyIcon() == false )
		{
			return;
		}
		
		const int CONST_ICON_SIZE = 12;
		
		rect.x      += rect.width;
		rect.width   = CONST_ICON_SIZE;
		rect.height  = CONST_ICON_SIZE;
		 
		HashSet<Component> components = GetComponents( instanceID );
		foreach ( var component in components )
		{
			rect.x -= CONST_ICON_SIZE;
			Texture tex = AssetPreview.GetMiniThumbnail( component );
			GUI.DrawTexture( rect, tex );
		}
		
	}

	// -----------------------------------------------------------------------------------------------
	// 指定したinstanceIDのオブジェクトに使用されているコンポーネントを取得する .
	// @param  instanceID      - インスタンスID .
	// @return List<Component> - コンポーネント .
	// -----------------------------------------------------------------------------------------------
	static HashSet<Component> GetComponents ( int instanceID ) {
		
		HashSet<Component> hash = new HashSet<Component>();
		
		GameObject sceneGameObject = EditorUtility.InstanceIDToObject( instanceID ) as GameObject;
		Component[] components = sceneGameObject.GetComponents<Component>();
		for ( int i = 0; i < components.Length; ++i )
		{
			if ( components[i] is UnityEngine.Transform ) 
			{
				continue;
			}
			hash.Add( components[i] );
		}
		
		return hash;
		
	}
}
