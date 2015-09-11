using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleView : MonoBehaviour {

	[SerializeField]
	private Text m_txtSceneTitle;

	void Awake()
	{
		if( m_txtSceneTitle == null )
		{
			foreach( Transform child in this.transform.parent )
			{
				if( child.gameObject.name == "Text")
				{
					m_txtSceneTitle = child.gameObject.GetComponent<Text>();
				}
			}
		}
		if( m_txtSceneTitle != null )
		{
			m_txtSceneTitle.text = Application.loadedLevelName;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickButton( int i )
	{
		Debug.Log ( "test" + i );
		Application.LoadLevel ( "Test" + i );
	}
}
