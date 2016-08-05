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

	private bool isStart = false;
	// Use this for initialization
	void Start () {
		Singleton<SoundPlayer>.instance.playMusic(GameManager.SelectMusic);
	}
	
	// Update is called once per frame
	void Update () {
		if(Singleton<SoundPlayer>.instance.isPlaying()) isStart = true;
		if(Input.GetKey(KeyCode.Escape) || (!Singleton<SoundPlayer>.instance.isPlaying() && isStart)){
			var scorePer = (float)NotesScript.removeNotesNum / (float)NotesOriginatingPointScript.currentNotesNum;
			GameManager.Score = (int)(scorePer * 100000);
			Singleton<SoundPlayer>.instance.stopMusic();
			SceneManager.LoadScene("Result");
		}
	}
}
