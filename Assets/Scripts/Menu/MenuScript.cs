using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;

public class MenuScript : MonoBehaviour {
	public string musicsInfoJsonPath;

	public Transform musicSelectionObjectPrefab;
	// Use this for initialization
	private List<GameObject> musicSelectionObjects = new List<GameObject>();

	[System.Serializable]
	public class MusicInfos  {
		public MusicInfo[] musicInfos;
	}
	private MusicInfos infos;
	
	private int currentMusic = 0;
	private List<Vector3> positions = new List<Vector3>();
	private int oldframeCount = 0;
	void Start () {
		this.infos = JsonUtility.FromJson<MusicInfos>(ReadJson());
		this.createMusicSelectionObjects();
	}

	void createMusicSelectionObjects(){
		int i = 0;
		foreach(var info in infos.musicInfos){
			this.musicSelectionObjects.Insert(i,Instantiate(musicSelectionObjectPrefab).gameObject);
			this.musicSelectionObjects[i].GetComponent<MusicSelectionObjectScript>().SetUpWithMusicInfo(info);
			// 子要素に
			this.musicSelectionObjects[i].transform.parent = this.gameObject.transform;
			this.musicSelectionObjects[i].transform.position = this.gameObject.transform.position + new Vector3(0f,i*4.0f,5.0f*i);
			var currentObjPosition = musicSelectionObjects[i].transform.position;
			this.positions.Insert(i,new Vector3(currentObjPosition.x,currentObjPosition.y,currentObjPosition.z));
			i += 1;
		}
    }

	string ReadJson() {
		string filetext = "";
		FileInfo fi = new FileInfo(Application.dataPath + "/" + this.musicsInfoJsonPath);
        try {
            // 一行毎読み込み
            using (StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8)){
                 filetext = sr.ReadToEnd();
            }
        } catch (Exception e){
			Debug.Log(e);
            // 改行コード
            filetext += "\n";
        }
		return filetext;
	}	
	// Update is called once per frame
	void Update () {
		if(Time.frameCount - oldframeCount > 10){
			var x = Input.GetAxis("Vertical");
			if(x != 0) MoveMusicSelection(x > 0);
			oldframeCount = Time.frameCount;
		}
	}
	void MoveMusicSelection(bool up){
		int max = musicSelectionObjects.Count - 1;
		if(up){
			if(currentMusic  == max){
				currentMusic = 0;
			} else {
				currentMusic += 1;
			}

			Debug.Log(currentMusic);
			for(int i = 0;i <= max;i++){
				if(currentMusic < i){
					musicSelectionObjects[i].transform.position = positions[i - currentMusic];	
				} else  if(currentMusic == i){
					musicSelectionObjects[i].transform.position = positions[0];
				} else {
					musicSelectionObjects[i].transform.position = positions[(max - currentMusic) + 1 + i];
				}
			}
		} else {
			if(currentMusic == 0){
				currentMusic = musicSelectionObjects.Count - 1;
			} else {
				currentMusic -= 1;
			}
			for(int i = 0;i <= max;i++){
				if(currentMusic < i){	
					musicSelectionObjects[i].transform.position = positions[i - currentMusic];	
				} else  if(currentMusic == i){
					musicSelectionObjects[i].transform.position = positions[0];
				} else {
					musicSelectionObjects[i].transform.position = positions[(max - currentMusic) + 1 + i];
				}
			}
		}
	}
}
