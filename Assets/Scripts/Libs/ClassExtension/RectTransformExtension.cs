using UnityEngine;

public static class RectTransformExtenssion {
	
	public static void SetPosX( this Transform transform, float x )
	{
		Vector3 pos = transform.localPosition;
		pos.x = x;
		transform.localPosition = pos;
	}
}
