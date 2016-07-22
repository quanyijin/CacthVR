using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
	public float distanceAway;			// 距离
	public float distanceUp;			// 高度

	public Transform follow;
	public static bool bb_;

	void LateUpdate ()
	{
		if (bb_) 
		{
			follow =GameObject.Find(PlayerPrefs.GetString("renwu")+"(Clone)").transform;
		}


		transform.position=new Vector3(follow.position.x,follow.position.y+distanceUp,follow.position.z+distanceAway);

		transform.LookAt(follow);

	}
}