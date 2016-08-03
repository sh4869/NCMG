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
	
	}
}
