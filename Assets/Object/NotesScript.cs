using UnityEngine;
using System.Collections;

public class NotesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.z -= 1.0f;
		transform.position = pos;
	}
	void OnCollisionEnter(Collision collision){
		
	}	
	void OnCollisionStay(Collision collision){
		
	}
}
