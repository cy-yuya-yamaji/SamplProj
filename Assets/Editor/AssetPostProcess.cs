/**
 * アセットのインポート直後に走る設定
 *
 */
using UnityEditor;
using UnityEngine;
using System.Collections;

/// <summary>
/// アセットのインポート管理
/// </summary>
public class AssetPostProcess : AssetPostprocessor {



	/// <summary>
    /// 全てのアセットのインポートが終了した際に呼ばれる
    /// </summary>
    public static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromPath)
    {
         
    }

	////////////////////////////////////////////////////////////////////
	// インポート直前に動くスクリプト

	/// <summary>
	/// この関数をサブクラスに追加してモデル (.fbx、.mb ファイル等) のインポート完了の直前に通知を取得します
	/// </summary>
	public void OnPreprocessAnimation()
	{
		// ModelImporter modelImporter = assetImporter as ModelImporter;
		// modelImporter.clipAnimations = modelImporter.defaultClipAnimations;
	}
	/// <summary>
	/// この関数をサブクラスに追加してオーディオクリップのインポート完了の直前に通知を取得します
	/// </summary>
	public void OnPreprocessAudio()
	{
		// if (assetPath.Contains("mono")) {
		// 	var audioImporter : AudioImporter = assetImporter;
		// 	audioImporter.forceToMono = true;
		// }
	}
	/// <summary>
	/// この関数をサブクラスに追加してモデル (.fbx、.mb ファイル等) のインポート完了の直前に通知を取得します
	/// </summary>
	public void OnPreprocessModel()
	{
		// if (assetPath.Contains("@")) {
		// 	var modelImporter : ModelImporter = assetImporter;
		// 	modelImporter.importMaterials = false;
		// }
	}
	/// <summary>
	/// Add this function in a subclass to get a notification just before a SpeedTree asset (.spm file) is imported.
	/// </summary>
	public void OnPreprocessSpeedTree()
	{
		// if (assetPath.Contains("@")) {
		// 	var modelImporter : ModelImporter = assetImporter;
		// 	modelImporter.importMaterials = false;
		// }
	}
	/// <summary>
	/// この関数をサブクラスに追加してテクスチャのインポート完了の直後に通知を取得します
	/// </summary>
	public void OnPreprocessTexture()
	{
		// スプライト用の画像フォルダ以下にインポート
		if ( assetPath.StartsWith( "Assets/Textures/SpriteTextures" ) ) 
		{
			string[] str = assetPath.Split("/"[0]);
			string packingTagName = "";
			for( int i = 3; i < str.Length; ++i )
			{
				packingTagName += str[i];
			}
			TextureImporter textureImporter		= (TextureImporter) assetImporter;
			textureImporter.textureType			= TextureImporterType.Sprite;
			textureImporter.spriteImportMode	= SpriteImportMode.Single;
			textureImporter.spritePackingTag	= packingTagName;
			textureImporter.mipmapEnabled		= false;
			textureImporter.filterMode			= FilterMode.Point;
			textureImporter.spritePixelsPerUnit	= 100;
		}
		// アトラス用の画像フォルダ以下にインポート
		else if ( assetPath.StartsWith( "Assets/Textures/SpriteAtlas" ) ) 
		{
			string packingTagName = "";
			TextureImporter textureImporter		= (TextureImporter) assetImporter;
			textureImporter.textureType			= TextureImporterType.Sprite;
			textureImporter.spriteImportMode	= SpriteImportMode.Multiple;
			textureImporter.spritePackingTag	= packingTagName;
			textureImporter.mipmapEnabled		= false;
			textureImporter.filterMode			= FilterMode.Point;
			textureImporter.spritePixelsPerUnit	= 100;
			UnityEngine.Debug.LogWarning( "ボーダー設定を確認してください。" );
		}
	}

	/// <summary>
	/// ソースマテリアルをフィードします。
	/// </summary>
	public void OnAssignMaterialModel()
	{

	}
	/// <summary>
	/// Handler called when asset is assigned to a different asset bundle.
	/// </summary>
	public void OnPostprocessAssetbundleNameChanged( string assetPath, string previousAssetBundleName, string newAssetBundleName )
	{

	}
	/// <summary>
	/// この関数をサブクラスに追加してオーディオクリップがインポート完了した時に通知を取得します
	/// </summary>
	public void OnPostprocessAudio( AudioClip audio )
	{

	}
	/// <summary>
	/// インポートファイルで少なくとも一つのユーザープロパティーがアタッチされた各々のゲームオブジェクトごとに呼び出されます
	/// </summary>
	public void OnPostprocessGameObjectWithUserProperties( GameObject go, string[] propNames, System.Object[] values )
	{

	}
	/// <summary>
	/// この関数をサブクラスに追加してモデルのインポートが完了したときに通知を取得します
	/// </summary>
	public void OnPostprocessModel( GameObject model)
	{

	}
	/// <summary>
	/// Add this function in a subclass to get a notification when a SpeedTree asset has completed importing.
	/// SpeedTree -> 木を作成するツールらしい・・・
	/// </summary>
	public void OnPostprocessSpeedTree( GameObject treeModel )
	{

	}
	/// <summary>
	/// この関数をサブクラスに追加してテクスチャのインポート完了の直後に通知を取得します
	/// </summary>
	public void OnPostprocessTexture( Texture2D texture )
	{
	}
}
