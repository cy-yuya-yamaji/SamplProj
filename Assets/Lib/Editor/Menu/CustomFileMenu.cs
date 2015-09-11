using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
//using System;
//using System.Collections;

public static class CustomFileMenu {
		
	// --------------------------------------------------------------------------------------------------------------
	// 新しくUnityを開く .
	// ※ショートカットキー　option + o .
	// --------------------------------------------------------------------------------------------------------------
	[MenuItem("File/Open Unity &o")]
	static void OpenUnity () { 

		// 開きたいプロジェクトを選択 .
		string selectPath = EditorUtility.OpenFolderPanel( "フォルダを選択して下さい", Application.dataPath+"/../", "FolderName" );
		if ( selectPath.Length <= 0 ) 
		{
			return;
		}

		// Unity実行ファイルのパスを取得 .		
		string unity_path = GetUnityPath();
		if ( unity_path == string.Empty )
		{
			Debug.LogError( "error unity_path enmpty." );
			return;
		}

		// コマンド起動 .
		var p = new System.Diagnostics.Process();
		p.StartInfo.FileName  = unity_path;
		p.StartInfo.Arguments = "-projectPath " + selectPath;
		p.Start();
	}

	// --------------------------------------------------------------------------------------------------------------
	// SublimeTextプロジェクトを生成 .
	// --------------------------------------------------------------------------------------------------------------
	[MenuItem("File/Create Sublime Project &c",false,2)]
	static void CreateSublimeProject () {

		string project_path = Application.dataPath.Substring( 0, Application.dataPath.LastIndexOf( "/" ) );

		try
		{
			SublimeTextProject.ExportProject( project_path );
			EditorUtility.DisplayDialog( "Export Sublime Text Project", project_path + "/" + SublimeTextProject.READ_ONLY_FILE_NAME + "を出力しました", "OK" );
		}
		catch ( System.Exception ex )
		{
			EditorUtility.DisplayDialog( "Error", ex.ToString(), "OK" );
		}

		// ソリューションファイルがない場合は、作成する .
		int    idx      = project_path.LastIndexOf( "/" )+1;
		string sln_file = project_path.Substring( idx, project_path.Length - idx ) + ".sln";
		if ( !System.IO.File.Exists( sln_file ) )
		{
			EditorApplication.ExecuteMenuItem( "Assets/Sync MonoDevelop Project" );
		}

	}

	// --------------------------------------------------------------------------------------------------------------
	// SublimeTextプロジェクトを開く .
	// --------------------------------------------------------------------------------------------------------------
	[MenuItem("File/Open Sublime Project &p",false,2)]
	static void OpenSublimeProject () {
		string full_path = Application.dataPath.Substring( 0, Application.dataPath.LastIndexOf( "/" ) ) + "/" + SublimeTextProject.READ_ONLY_FILE_NAME;

		if ( System.IO.File.Exists( full_path ) )
		{
			// SublimeTextのプロジェクトファイルを開く .
			var p = new System.Diagnostics.Process();
			p.StartInfo.FileName  = "open";
			p.StartInfo.Arguments = full_path;
			p.Start();
		}
		else 
		{
			// ファイルが存在しない .
			EditorUtility.DisplayDialog( "File Not Found.", full_path, "OK" );
		}
	}

	// --------------------------------------------------------------------------------------------------------------
	// Unity実行ファイルパスを取得 .
	// @return string - パス .
	// --------------------------------------------------------------------------------------------------------------
	static string GetUnityPath () {

		string path         = string.Empty;
		string assemblypath = InternalEditorUtility.GetEngineAssemblyPath();

		switch ( Application.platform )
		{
		case RuntimePlatform.OSXEditor:
			{
				int index = assemblypath.IndexOf( "Frameworks" );
				if ( index >= 0 )
				{
					path = assemblypath.Substring( 0, index ) + "MacOS/Unity";
				}
			}
			break;
			
		case RuntimePlatform.WindowsEditor:
			{
			}
			break;

		default:
			{
			}
			break;
		}

		return path;
	}

}
