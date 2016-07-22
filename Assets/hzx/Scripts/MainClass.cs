using UnityEngine;
using System.Collections;

public class MainClass {
	/// <summary>
	/// 移动.
	/// </summary>
	/// <param name="frist">起始点</param>
	/// <param name="end">结束点</param>
	/// <param name="speed">速度</param>
	public  virtual void Move_play(Vector3 frist,Vector3 end,float speed)
	{
		frist=Vector3.MoveTowards(frist,end,speed);
	}
}
