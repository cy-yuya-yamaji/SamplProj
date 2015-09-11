using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Transform))]
public class CustomTransformInspector : Editor { 

    enum eElement : int {
        Position = 0,       // 座標 .
        Rotation,           // 回転 .
        Scale,              // 拡大 .
        Num,                // 数 .
    }
    
    private Vector3[] m_vTmpArray = new Vector3[(int)eElement.Num];
    
    // ------------------------------------------------------------------------------
    // インスペクタ表示 .
    // ------------------------------------------------------------------------------
    public override void OnInspectorGUI () {
		
        Transform targetTransform = target as Transform;
 
        EditorGUI.BeginChangeCheck(); 
 
        Vector3[] local_value_array = new Vector3[(int)eElement.Num] {
              targetTransform.localPosition,
              targetTransform.localEulerAngles,
              targetTransform.localScale
        };
              
        for ( int i = 0; i < (int)eElement.Num; ++i )
        {
            EditorGUILayout.BeginHorizontal();
            
            m_vTmpArray[i] = EditorGUILayout.Vector3Field( ((eElement)i).ToString(), local_value_array[i] );
            
            GUI.backgroundColor = Color.yellow;
            if ( GUILayout.Button( "Reset", GUILayout.Width( 45 ) ) )
            { 
                m_vTmpArray[i] = (i==(int)eElement.Scale) ? Vector3.one : Vector3.zero;
            }
            GUI.backgroundColor = Color.white;
            
            EditorGUILayout.EndHorizontal();
        }
        
        if ( EditorGUI.EndChangeCheck() ) 
        {
            // 値が変更されたので更新 . 
            Undo.RecordObject( target, "Undo Transform" ); 
            targetTransform.localPosition    = m_vTmpArray[(int)eElement.Position]; 
            targetTransform.localEulerAngles = m_vTmpArray[(int)eElement.Rotation];
            targetTransform.localScale       = m_vTmpArray[(int)eElement.Scale];
        }
        
    }
}