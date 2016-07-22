using UnityEngine;
using System.Collections;
using TNet;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TNet_ : MonoBehaviour {

	public InputField IP;
	public int serverTcpPort = 5127;
	public Text tx;
	public Button But_server;
	public Text tx_ip;


	private int udpPort;
	private TNLobbyClient lobby;
	public bool Switching_bool=true;

	public void Start()
	{
		tx_ip.text=Tools.localAddress.ToString();
	}
	public void Update()
	{
		
		/*	if (TNServerInstance.playerCount>0) 
			{
				if (Switching_bool) 
				{
					Switching_bool=false;
					SceneManager.LoadScene("people");	
				}
			}
			if (TNManager.isConnected) 
			{
				if (Switching_bool) 
				{
					Switching_bool=false;
					Debug.Log("成功");
					SceneManager.LoadScene("people");
				}
			}*/
		//Debug.Log(TNServerInstance.playerCount);
	}


	public void StartServer()
	{
		if (TNServerInstance.isActive)
		{
			But_server.transform.GetChild(0).GetComponent<Text>().color=Color.black;
			But_server.transform.GetChild(0).GetComponent<Text>().text="建立主机";
			TNServerInstance.Stop("server.dat");
			tx.text = "Server stopped";
		}
		else
		{
			int udpPort = Random.Range(10000, 40000);
			TNLobbyClient lobby = GetComponent<TNLobbyClient>();

			if (lobby == null)
			{
				TNServerInstance.Start(serverTcpPort, udpPort, "server.dat");
			}
			else
			{
				if (lobby!=null) 
				{
					TNServerInstance.Type type = (lobby is TNUdpLobbyClient) ?
						TNServerInstance.Type.Udp : TNServerInstance.Type.Tcp;
					TNServerInstance.Start(serverTcpPort, udpPort, lobby.remotePort, "server.dat", type);
				}	
			}
			tx.text = "Server started";
			But_server.transform.GetChild(0).GetComponent<Text>().color=Color.red;
			But_server.transform.GetChild(0).GetComponent<Text>().text="等待加入";
			transform.GetComponent<TNAutoJoin>().enabled=true;
		}
	}

	public void Connect()
	{
		TNManager.Connect(IP.text);
	}

}
