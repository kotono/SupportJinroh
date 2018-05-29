using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleView : MonoBehaviour {

	// タップテキスト
	public TapText tapText = null;


	// Use this for initialization
	void Start () {
		tapText.gameObject.SetActive(true);
		tapText.SetCallback(delegate(){
			// シーン移動
			SceneNavigator.Instance.Change("PlayerSettingScene", 1.0f);
		});
	}

	// Update is called once per frame
	void Update () {
		
	}

}
