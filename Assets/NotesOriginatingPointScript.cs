using UnityEngine;
using System.Collections;

public class NotesOriginatingPointScript : MonoBehaviour {
	public Transform notes;
	int [,] position = new int[,] {{5,5},{-5,5},{5,5},{-5,-5}};
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.frameCount % 60 == 0){
			int i = Random.Range(0,4);
			Instantiate(notes,new Vector3(position[i,0],position[i,1],20),Quaternion.identity);
		}
	}
}
