using UnityEngine;
using System.Collections;
using TNet;

public class NetWork__ :TNBehaviour 
{

	public Animation am;
	public string zhuangtai;//="Idle Owl";
	public string renwu_name;
	// Use this for initialization
	void Start () 
	{
		renwu_name=PlayerPrefs.GetString("renwu").ToString();
		zhuangtai="Idle "+renwu_name;
		am=transform.GetComponent<Animation>();
		if (GetComponent<TNObject>().isMine) 
		{
			GetComponent<PlayMakerFSM>().enabled=true;
		}
	}
	[RFC]
	public void Animation_play(string zhuangtai_)
	{
		zhuangtai=zhuangtai_;
	}
	void FixedUpdate()
	{
		Animation_play();
	}
	public void Animation_play()
	{
		if (GetComponent<TNObject>().isMine)
		{
			tno.Send("Animation_play",TNet.Target.AllSaved,zhuangtai);
			if(Input.anyKey) 
			{
				zhuangtai="Run "+renwu_name;
			}
			else
			{
				zhuangtai="Idle "+renwu_name;
			}
		}
		am.Play(zhuangtai);
	}
}
