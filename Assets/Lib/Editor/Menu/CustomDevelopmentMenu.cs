using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.Collections;

public class CustomDevelopmentMenu {
		
	// --------------------------------------------------------------------------------------------------------------
	// 現在開いているプロジェクトのシンボリックリンクされたプロジェクトを作成 .
	// --------------------------------------------------------------------------------------------------------------	
	[MenuItem("Development/Symbolic Link/Create Project")]
	static void CreateSymbolicProject () {
				
		string project_path = Application.dataPath;
		project_path = project_path.Substring( 0, project_path.LastIndexOf( '/' ) );
		_CreateSymbolicLinkProject( project_path );
		
	}
	
	// --------------------------------------------------------------------------------------------------------------
	// 選択したプロジェクトのシンボリックリンクされたプロジェクトを作成 .
	// --------------------------------------------------------------------------------------------------------------
	[MenuItem("Development/Symbolic Link/Other Create Project")]
	static void CreateSymbolicOtherProject () {
		
		// 開きたいプロジェクトを選択 .
		string select_path = EditorUtility.OpenFolderPanel( "Unityプロジェクトフォルダを選択して下さい", Application.dataPath+"/../", "FolderName" );
		if ( select_path.Length <= 0 ) 
		{
			return;
		}
		
		// シンボリックリンクプロジェクト作成 .
		_CreateSymbolicLinkProject( select_path );
	}

	// --------------------------------------------------------------------------------------------------------------
	// 指定したプロジェクトのシンボリックリンクしたプロジェクトを作成 .
	// @param project_path .
	// --------------------------------------------------------------------------------------------------------------	
	static void _CreateSymbolicLinkProject ( string project_path ) {
		
		if (  Application.platform != RuntimePlatform.OSXEditor )
		{
			EditorUtility.DisplayDialog( "エラー", "MacOSのみ実行可能です。", "閉じる" );
			return;
		}
		
		// Assetsフォルダが存在するか確認する .
		string assets_path = project_path + "/Assets";
		if ( System.IO.Directory.Exists( assets_path ) == false )
		{
			EditorUtility.DisplayDialog( "エラー", assets_path + "存在しません。", "閉じる" );
			return;			
		}
		
		// ProjectSettingsフォルダが存在するか確認する .
		string projectsettings_path = project_path + "/ProjectSettings";
		if ( System.IO.Directory.Exists( projectsettings_path ) == false )
		{
			EditorUtility.DisplayDialog( "エラー", projectsettings_path + "存在しません。", "閉じる" );
			return;			
		}

		string[] split_array = project_path.Split( '/' );
		string   directory   = split_array[split_array.Length-1];
				
		// フォルダが既にあれば削除する .
		string symbolic_directory = directory + "_symbolic";
		string target_path        = Application.dataPath + "/../../" + symbolic_directory;
		if ( System.IO.Directory.Exists( target_path ) == true )
		{
			System.IO.DirectoryInfo di = new System.IO.DirectoryInfo( target_path );
			di.Delete( true );
		}
		
		// コマンド起動 .
		System.Diagnostics.Process p = new System.Diagnostics.Process();
		p.StartInfo.FileName  = "sh";
		p.StartInfo.Arguments = Application.dataPath + "/../CreateSymbolicProject.sh " + project_path + " " + directory + " " + symbolic_directory;
		p.Start();
		
	}

}
