using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	public static int Score = 0;

	// Use this for initialization
	void Start () {
//		SceneManager.LoadScene("Result");
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.frameCount > 100){
			SceneManager.LoadScene("Result");
		}
	}
}
