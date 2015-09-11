#if UNITY_EDITOR

using System;
using System.IO;
using System.Collections;

public static class SublimeTextProject {

	public static readonly string READ_ONLY_EXTENSION = ".sublime-project";
	public static readonly string READ_ONLY_FILE_NAME = "project" + READ_ONLY_EXTENSION;

	// --------------------------------------------------------------------------------------------------------------
	// プロジェクトファイル出力 .
	// @param path - 出力パス .
	// --------------------------------------------------------------------------------------------------------------
	public static void ExportProject ( string path ) {

		string filename     = path + "/" + READ_ONLY_FILE_NAME;
		string project_name = path.Substring( path.LastIndexOf("/")+1, path.Length - (path.LastIndexOf("/")+1) ); 
		var    encode       = new System.Text.UTF8Encoding();

		using (	var wr = new StreamWriter( filename, false, encode ) )
		{
			wr.WriteLine( "{" );
			wr.WriteLine( "\t\"bold_folder_labels\": true," );
			wr.WriteLine( "\t\"default_encoding\": \"UTF-8 with BOM\"," );
			wr.WriteLine( "\t\"detect_indentation\": true," );
			wr.WriteLine( "\t\"draw_indent_guides\": true," );
			wr.WriteLine( "\t\"draw_white_space\": \"all\"," );
			wr.WriteLine( "\t\"ensure_newline_at_eof_on_save\": true," );

			wr.WriteLine( "\t\"folders\":" );
			wr.WriteLine( "\t[" );
			wr.WriteLine( "\t\t{" );
			wr.WriteLine( "\t\t\t\"file_exclude_patterns\":" );
			wr.WriteLine( "\t\t\t[" );
			wr.WriteLine( "\t\t\t\t\"*.meta\"," );
			wr.WriteLine( "\t\t\t\t\"*.jpg\"," );
			wr.WriteLine( "\t\t\t\t\"*.jpeg\"," );
			wr.WriteLine( "\t\t\t\t\"*.png\"," );
			wr.WriteLine( "\t\t\t\t\"*.bmp\"," );
			wr.WriteLine( "\t\t\t\t\"*.tga\"," );
			wr.WriteLine( "\t\t\t\t\"*.psd\"," );
			wr.WriteLine( "\t\t\t\t\"*.gif\"," );
			wr.WriteLine( "\t\t\t\t\"*.tif\"," );
			wr.WriteLine( "\t\t\t\t\"*.tiff\"," );
			wr.WriteLine( "\t\t\t\t\"*.db\"," );
			wr.WriteLine( "\t\t\t\t\"*.mdb\"," );
			wr.WriteLine( "\t\t\t\t\"*.accdb\"," );
			wr.WriteLine( "\t\t\t\t\"*.prefab\"," );
			wr.WriteLine( "\t\t\t\t\"*.unity\"," );
			wr.WriteLine( "\t\t\t\t\"*.unity3d\"," );
			wr.WriteLine( "\t\t\t\t\"*.unitypackage\"," );
			wr.WriteLine( "\t\t\t\t\"*.mat\"," );
			wr.WriteLine( "\t\t\t\t\"*.obj\"," );
			wr.WriteLine( "\t\t\t\t\"*.3ds\"," );
			wr.WriteLine( "\t\t\t\t\"*.vrmL\"," );
			wr.WriteLine( "\t\t\t\t\"*.x3d\"," );
			wr.WriteLine( "\t\t\t\t\"*.dxf\"," );
			wr.WriteLine( "\t\t\t\t\"*.stl\"," );
			wr.WriteLine( "\t\t\t\t\"*.pov\"," );
			wr.WriteLine( "\t\t\t\t\"*.collada\"," );
			wr.WriteLine( "\t\t\t\t\"*.fbx\"," );
			wr.WriteLine( "\t\t\t\t\"*.lwo\"," );
			wr.WriteLine( "\t\t\t\t\"*.ply\"," );
			wr.WriteLine( "\t\t\t\t\"*.xsi\"," );
			wr.WriteLine( "\t\t\t\t\"*.ac3d\"," );
			wr.WriteLine( "\t\t\t\t\"*.c3d\"," );
			wr.WriteLine( "\t\t\t\t\"*.bvh\"," );
			wr.WriteLine( "\t\t\t\t\"*.zip\"," );
			wr.WriteLine( "\t\t\t\t\"*.rar\"," );
			wr.WriteLine( "\t\t\t\t\"*.gz\"," );
			wr.WriteLine( "\t\t\t\t\"*.tar\"," );
			wr.WriteLine( "\t\t\t\t\"*.xz\"," );
			wr.WriteLine( "\t\t\t\t\"*.7z\"," );
			wr.WriteLine( "\t\t\t\t\"*.lhz\"," );
			wr.WriteLine( "\t\t\t\t\"*.apk\"," );
			wr.WriteLine( "\t\t\t\t\"*.ipa\"," );
			wr.WriteLine( "\t\t\t\t\"*.app\"," );
			wr.WriteLine( "\t\t\t\t\"*.exe\"," );
			wr.WriteLine( "\t\t\t\t\"*.dll\"," );
			wr.WriteLine( "\t\t\t\t\"*.jar\"," );
			wr.WriteLine( "\t\t\t\t\"*.framework\"," );
			wr.WriteLine( "\t\t\t\t\"*.keystore\"," );
			wr.WriteLine( "\t\t\t\t\"*.mobileprovision\"," );
			wr.WriteLine( "\t\t\t\t\"*.cer\"," );
			wr.WriteLine( "\t\t\t\t\"*.p12\"," );
			wr.WriteLine( "\t\t\t\t\"*.xls\"," );
			wr.WriteLine( "\t\t\t\t\"*.xlsx\"," );
			wr.WriteLine( "\t\t\t\t\"*.xlsm\"," );
			wr.WriteLine( "\t\t\t\t\"*.doc\"," );
			wr.WriteLine( "\t\t\t\t\"*.docx\"," );
			wr.WriteLine( "\t\t\t\t\"*.docm\"," );
			wr.WriteLine( "\t\t\t\t\"*.ppt\"," );
			wr.WriteLine( "\t\t\t\t\"*.pptx\"," );
			wr.WriteLine( "\t\t\t\t\"*.pptm\"," );
			wr.WriteLine( "\t\t\t\t\"*.pdf\"," );
			wr.WriteLine( "\t\t\t\t\"*.avi\"," );
			wr.WriteLine( "\t\t\t\t\"*.mov\"," );
			wr.WriteLine( "\t\t\t\t\"*.mp4\"," );
			wr.WriteLine( "\t\t\t\t\"*.mpg\"," );
			wr.WriteLine( "\t\t\t\t\"*.mpeg\"," );
			wr.WriteLine( "\t\t\t\t\"*.vob\"," );
			wr.WriteLine( "\t\t\t\t\"*.ogm\"," );
			wr.WriteLine( "\t\t\t\t\"*.rm\"," );
			wr.WriteLine( "\t\t\t\t\"*.divx\"," );
			wr.WriteLine( "\t\t\t\t\"*.wav\"," );
			wr.WriteLine( "\t\t\t\t\"*.wma\"," );
			wr.WriteLine( "\t\t\t\t\"*.mp3\"," );
			wr.WriteLine( "\t\t\t\t\"*.ogg\"," );
			wr.WriteLine( "\t\t\t\t\"*.m4a\"," );
			wr.WriteLine( "\t\t\t\t\"*.cda\"," );
			wr.WriteLine( "\t\t\t\t\"*.aif\"," );
			wr.WriteLine( "\t\t\t\t\"*.aiff\"," );
			wr.WriteLine( "\t\t\t\t\"*.au\"," );
			wr.WriteLine( "\t\t\t\t\"*.o\"," );
			wr.WriteLine( "\t\t\t\t\"*.mak\"," );
			wr.WriteLine( "\t\t\t\t\".*\"," );
			wr.WriteLine( "\t\t\t]," );

			wr.WriteLine( "\t\t\t\"folder_exclude_patterns\":" );
			wr.WriteLine( "\t\t\t[" );
			wr.WriteLine( "\t\t\t\t\".*\"" );
			wr.WriteLine( "\t\t\t]," );
			wr.WriteLine( "\t\t\t\"path\":\"Assets\"" );
			wr.WriteLine( "\t\t}," );

			wr.WriteLine( "\t\t{" );
			wr.WriteLine( "\t\t\t\"path\":\"Xcode/Unity-iPhone.xcodeproj\"" );
			wr.WriteLine( "\t\t}," );

			wr.WriteLine( "\t]," );

			wr.WriteLine( "\t\"solution_file\": \"" + project_name + ".sln\"," );
			wr.WriteLine( "\t\"highlight_line\": true," );
			wr.WriteLine( "\t\"match_brackets_content\": true," );
			wr.WriteLine( "\t\"match_brackets_square\": true," );
			wr.WriteLine( "\t\"match_selection\": true," );
			wr.WriteLine( "\t\"preview_on_click\": true," );
			wr.WriteLine( "\t\"remember_open_files\": true," );
			wr.WriteLine( "\t\"shift_tab_unindent\": true," );
			wr.WriteLine( "\t\"tab_size\": 4," );
			wr.WriteLine( "\t\"translate_tabs_to_spaces\": true," );
			wr.WriteLine( "\t\"trim_trailing_white_space_on_save\": true," );

			wr.WriteLine( "}" );
		}
	}

}

#endif 	// UNITY_EDITOR