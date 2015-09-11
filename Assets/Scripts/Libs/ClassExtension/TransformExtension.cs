using UnityEngine;

public static class TransformExtenssion {
	
	public static void SetPosX( this Transform transform, float x )
	{
		Vector3 pos = transform.localPosition;
		pos.x = x;
		transform.localPosition = pos;
	}
	
	public static void SetPosY( this Transform transform, float y )
	{
		Vector3 pos = transform.localPosition;
		pos.y = y;
		transform.localPosition = pos;
	}
	
	public static void SetPosZ( this Transform transform, float z )
	{
		Vector3 pos = transform.localPosition;
		pos.z = z;
		transform.localPosition = pos;
	}

	public static void AddPosX( this Transform transform, float x )
	{
		Vector3 pos = transform.localPosition;
		pos.x += x;
		transform.localPosition = pos;
	}
	
	public static void AddPosY( this Transform transform, float y )
	{
		Vector3 pos = transform.localPosition;
		pos.y += y;
		transform.localPosition = pos;
	}
	
	public static void AddPosZ( this Transform transform, float z )
	{
		Vector3 pos = transform.localPosition;
		pos.z += z;
		transform.localPosition = pos;
	}

	public static void SetRotX( this Transform transform, float x )
	{
		Quaternion rot = transform.localRotation;
		rot.x = x;
		transform.localRotation = rot;
	}
	
	public static void SetRotY( this Transform transform, float y )
	{
		Quaternion rot = transform.localRotation;
		rot.y = y;
		transform.localRotation = rot;
	}
	
	public static void SetRotZ( this Transform transform, float z )
	{
		Quaternion rot = transform.localRotation;
		rot.z = z;
		transform.localRotation = rot;
	}

	public static void AddRotX( this Transform transform, float x )
	{
		Quaternion rot = transform.localRotation;
		rot.x += x;
		transform.localRotation = rot;
	}
	
	public static void AddRotY( this Transform transform, float y )
	{
		Quaternion rot = transform.localRotation;
		rot.y += y;
		transform.localRotation = rot;
	}
	
	public static void AddRotZ( this Transform transform, float z )
	{
		Quaternion rot = transform.localRotation;
		rot.z += z;
		transform.localRotation = rot;
	}
}
