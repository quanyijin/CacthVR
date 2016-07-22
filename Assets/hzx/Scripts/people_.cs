using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class people_ : MonoBehaviour {
	public List<Animation> an_list;//角色模型
	public GameObject but;//选择角色进入
	public GameObject but_zhu;
	public Vector3 m_Camera_ve=new Vector3(0,1,-5);//摄像机坐标
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		jiaose();
	}
	//选择角色
	public void jiaose()
	{
		RaycastHit hit;
		Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray,out hit)) 
		{
			string An_name=hit.transform.name;
			hit.transform.GetComponent<Animation>().Play("Success "+An_name);	
			//人物近镜头
			if (Input.GetMouseButtonDown(0)) 
			{
				foreach (var item in an_list) {
					if (item.name==hit.transform.name) 
					{
						//储存选择人物
						PlayerPrefs.SetString("renwu",item.name);
						m_Camera_ve=new Vector3(hit.transform.position.x,hit.transform.position.y+1,-2);
						//显示button
						if (hit.transform.name=="Toon Ghost") 
						{
							but_zhu.SetActive(true);	
						}
						else
						{
							but.SetActive(true);
						}
						Vector3 ve=new Vector3(hit.transform.position.x,hit.transform.position.y+1.5f,hit.transform.position.z-0.2f);
						but.transform.position=ve;
						but_zhu.transform.position=ve;
					}
				}	
			}
		}
		else
		{
			if (Input.GetMouseButtonDown(0)) 
			{
				//返回视角

				m_Camera_ve=new Vector3(0,1,-5);
				//button隐藏为空
				but.SetActive(false);
				but_zhu.SetActive(false);
			}
		}
		foreach (var item in an_list) 
		{
			//空闲状态下保持静止动画状态
			if (!item.isPlaying) //item.IsPlaying("Success "+item.name)
			{
				item.Play("Idle "+item.name);	
			}
			//始终朝向摄像机
			item.transform.LookAt(new Vector3(Camera.main.transform.position.x,item.transform.position.y,Camera.main.transform.position.z));
		}
		Camera.main.transform.position=Vector3.MoveTowards(Camera.main.transform.position,m_Camera_ve,Time.deltaTime*10);
	}

	public void IN_Game()
	{
		
		SceneManager.LoadScene("game");
		//transform.GetComponent<TNAutoJoin>().enabled=true;
	}
}
