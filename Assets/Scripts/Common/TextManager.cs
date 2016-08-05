using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TextManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void UpdateText(string text){
		this.gameObject.GetComponent<TextMesh>().text = text;
	}

	public void UpdateColor(Color color){
		this.gameObject.GetComponent<TextMesh>().color = color;
	}

	public void UpdateSize(int size){
		this.gameObject.GetComponent<TextMesh>().fontSize = size;
	}
	// Update is called once per frame
	void Update () {
	}
}
