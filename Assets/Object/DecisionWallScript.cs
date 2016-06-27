using UnityEngine;
using System.Collections;

public class DecisionWallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay(Collision collision){
		if(collision.gameObject.name == "Notes(Clone)") {
			// TODO: Refactoring
			if(collision.gameObject.transform.position.x == 5){
				if(collision.gameObject.transform.position.y == 0){
					if(Input.GetKey("s")){
						Destroy(collision.gameObject);
					}
				} else {
					if(Input.GetKey("w")){
						Destroy(collision.gameObject);
					}
				}
			} else {
				if(collision.gameObject.transform.position.y == 0){
					if(Input.GetKey("a")){
						Destroy(collision.gameObject);
					}
				} else {
					if(Input.GetKey("q")){
						Destroy(collision.gameObject);
					}
				}
			}
		}
	}
}
