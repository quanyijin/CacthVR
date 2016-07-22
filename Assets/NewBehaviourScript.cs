using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject ins;
    public int a;
    public int col;
    public int row;
    public GameObject Par;

    GameObject now;
	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < col; i++)
        {
            
            for (int j = 0; j < row; j++)
            {
                now=Instantiate(ins, new Vector3(0, 0,0), Quaternion.identity)as GameObject;
                now.transform.SetParent(Par.transform);
                now.name = i + "|" + j;
                now.transform.position = new Vector3(i * 2, 0, j * 2);
                
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
