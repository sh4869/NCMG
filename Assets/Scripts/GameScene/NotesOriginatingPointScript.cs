using UnityEngine;
using System.Collections;

public class NotesOriginatingPointScript : MonoBehaviour {
	public Transform notes;

	public static int currentNotesNum = 0;
	// Use this for initialization
	void Start () {
		Singleton<SEPlayer>.instance.SetUpSE();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.frameCount % 60 == 0){
			Instantiate(notes,new Vector3(0,0,-5),Quaternion.identity);
			currentNotesNum++;
		}
	}
}
