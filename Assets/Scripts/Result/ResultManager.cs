using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour {
	public Transform TextObject;
	public Transform BackGroundObject;
	private GameObject scoreText;
	private GameObject resultText;
	private GameObject musicText;
	private GameObject backGround;

	// Use this for initialization
	void Start () {
		this.backGround = Instantiate(this.BackGroundObject).gameObject;
		this.backGround.transform.localScale = new Vector3(20,30,20);
		this.backGround.transform.position = this.gameObject.transform.position + new Vector3(4f,-4f,-10f);
		this.backGround.transform.parent = this.gameObject.transform;
		this.SetUpText();	
	}
	
	void SetUpText() {
		this.resultText = Instantiate(this.TextObject).gameObject;
		this.resultText.GetComponent<TextManager>().UpdateText("Result");
		this.resultText.GetComponent<TextManager>().UpdateSize(60);
		this.resultText.transform.position = this.gameObject.transform.position + new Vector3(0f,-1f,0f);
		this.resultText.transform.parent = this.gameObject.transform;

		this.scoreText = Instantiate(this.TextObject).gameObject;
		this.scoreText.GetComponent<TextManager>().UpdateText(GameManager.Score.ToString());
		this.scoreText.GetComponent<TextManager>().UpdateSize(120);
		this.scoreText.transform.position = this.gameObject.transform.position + new Vector3(3f,-2f,3f);
		this.scoreText.transform.parent = this.gameObject.transform;
		SetUpMusicText();
	}

	void SetUpMusicText() {
		this.musicText = Instantiate(this.TextObject).gameObject;
		MusicInfo info = MenuScript.SelectMusic;
		this.musicText.GetComponent<TextManager>().UpdateText(info.musicTitle + " - " + info.artistName);
		this.musicText.GetComponent<TextManager>().UpdateSize(30);
		this.musicText.GetComponent<TextManager>().UpdateColor(new Color(0,133,171,255));
		this.musicText.transform.position = this.gameObject.transform.position + new Vector3(-0.2f,-5.3f,0f);
		this.musicText.transform.parent = this.gameObject.transform;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("return")){
			GameManager.Score = 0;
			MenuScript.SelectMusic = null;
			SceneManager.LoadScene("Title");
		}
	}
}
