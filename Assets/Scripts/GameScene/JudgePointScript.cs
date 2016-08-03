using UnityEngine;
using System.Collections;

public class JudgePointScript : MonoBehaviour {
	public string keyname;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision){
		Debug.Log(collision.gameObject.name);
		if(collision.gameObject.name == "Notes(Clone)") {
			if(Input.GetKey(keyname)){
				Destroy(collision.gameObject);
			}
		}
	}
}
