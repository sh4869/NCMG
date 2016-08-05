using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Game Manager
/// </summary>
public class GameManager : MonoBehaviour {

	/// <summary>
    /// Music Info that user selected 
    /// </summary>
	public static MusicInfo SelectMusic = new MusicInfo();

	/// <summary>
    /// Game Score.
    /// </summary>
	public static int Score = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.frameCount > 100){
			SceneManager.LoadScene("Result");
		}
	}
}
