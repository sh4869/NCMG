using UnityEngine;
using System.Collections;

public class SEPlayer : MonoBehaviour {

	AudioSource source;
	AudioClip clip;
	GameObject SEPlayerObject;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetUpSE(){
		if(SEPlayerObject == null) {
			this.SEPlayerObject = new GameObject("SEPlayerObject");
			source = this.SEPlayerObject.AddComponent<AudioSource>();
		}
		this.clip = (AudioClip)Resources.Load("perfect");
		this.source.clip = clip;
		this.source.volume = 1.0f;
	}

	public void Play(){
		this.source.Play();
	}
}
