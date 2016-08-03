using UnityEngine;
using System.Collections;

public class MusicSelectionObjectScript : MonoBehaviour {

	public Transform backGroundObjectPrefab;
	
	public Transform musicTitleTextPrefab;

	public Transform artistTitleTextPrefab;

	private Transform backGroundObject;

	private Transform musicTitleText;

	private Transform artistTitleText;

	private Vector3 musicTitleTextPositon = new Vector3(-4.5f,2.0f,-1.0f);
	private Vector3 artistTitleTextPosition = new Vector3(-3.0f,0.7f,-1.0f);
	
	// Use this for initialization
	void Start () {
		if(backGroundObject == null){
			this.backGroundObject = Instantiate(backGroundObjectPrefab);
			this.backGroundObject.transform.parent = this.gameObject.transform;
			
			// MusictitleText Position  
			this.musicTitleText = Instantiate(musicTitleTextPrefab);
			this.musicTitleText.transform.position = this.backGroundObject.transform.position + musicTitleTextPositon;
			this.musicTitleText.transform.parent = this.gameObject.transform;

			// Artist Text Position
			this.artistTitleText = Instantiate(artistTitleTextPrefab);
			this.artistTitleText.transform.position = this.backGroundObject.transform.position + artistTitleTextPosition;
			this.artistTitleText.transform.parent = this.gameObject.transform;
		}
	}
	
	public void SetUpWithMusicInfo(MusicInfo info){
		
		this.musicTitleText.GetComponent<TextMesh>().text = info.musicTitle;
		this.artistTitleText.GetComponent<TextMesh>().text = info.artistName;
			
	}
	
	// Update is called once per frame
	void Update () {

	}
	void Awake(){
		Start();
	}
}
