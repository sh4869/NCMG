using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {
	GameObject soundPlayerObject;
	AudioSource source;
	AudioClip clip;

	// Use this for initialization
	void Start () {
	
	}
	
	public void playMusic(MusicInfo music){
		clip = (AudioClip)Resources.Load(music.artistName + " - " + music.musicTitle);
		if(clip == null) return;
		if(soundPlayerObject == null){
			soundPlayerObject = new GameObject("SoundPlayer");
			source = soundPlayerObject.AddComponent<AudioSource>();
		}
		source.clip = clip;
		source.Play();
	}

	public void stopMusic(){
		if(clip != null){
			source.Stop();
		}
	}

	public bool isPlaying() {
		if(source == null) return false;
		return this.source.isPlaying;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
