using UnityEngine;
using System.Collections;

public class NotesOriginatingPointScript : MonoBehaviour {
	public Transform notes;

	private int currentNotesNum = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.frameCount % 60 == 0){
			Instantiate(notes,new Vector3(0,0,20),Quaternion.identity);
			currentNotesNum++;
		}
	}
}
