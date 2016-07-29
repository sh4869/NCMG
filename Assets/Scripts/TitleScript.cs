using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TitleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("return")){
			SceneManager.LoadScene("Main");
		}
	}
	void OnGUI(){
		GUI.Label(new Rect(50,50,100,20), "Game Start!!");
	}
}
