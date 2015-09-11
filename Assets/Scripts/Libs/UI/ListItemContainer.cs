using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class ListItemContainer : MonoBehaviour {

	[SerializeField]
	public RectTransform m_rootObject;

	void Awake()
	{
		if( m_rootObject == null )
		{
			Image rootBg = new GameObject( "test" ).AddComponent<Image>();
			m_rootObject = rootBg.transform as RectTransform;
			rootBg.transform.parent = this.transform;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
