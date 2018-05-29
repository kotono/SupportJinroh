using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionView : MonoBehaviour {

	// タップテキスト
	public TapText tapText = null;

	// 文章の親
	public GameObject messageParent = null;

	// 文章のベースオブジェクト
	public GameObject textBase = null;

	// 文章のリスト
	private List<GameObject> textObjList = new List<GameObject>();


	// メッセージリスト
	List<string> strList = new List<string>() {
		"この村には、夜な夜な人間を食べてしまう\n『人狼』が村人になりすまして潜んでいます",
		"そんな『人狼』を昼間の会議で追放し\n村に平和を取り戻しましょう",
		"『人狼』は、毎晩誰かを襲撃します\nガードが成功しなければ\nその人は朝、死体となって発見されます",
		"『人狼』と村人の数が同じになった時点で\n村は滅びてしまいます",
		"そうならないように\n村人は力を合わせて\n『人狼』を全て追放しましょう",
	};


	// Use this for initialization
	void Start () {
		GameObject obj;
		Text message;

		// text複製
		for (int i = 0; i < strList.Count; i++) {
			if (i == 0) {
				obj = textBase;
			} else {
				obj = GameObject.Instantiate<GameObject>(textBase);
				obj.transform.parent = messageParent.transform;
				obj.transform.localScale = new Vector3(1, 1, 1);
			}
			textObjList.Add(obj);
			message = obj.GetComponent<Text>();
			message.text = strList[i];
		}

		StartCoroutine(mainView());
	}


	// ===================================================
	// ---------------------------------------------------
	/// <summary>
	/// 画面の表示を行う
	/// </summary>
	/// <returns></returns>
	private IEnumerator mainView()
	{
		// タップ表示
		tapText.gameObject.SetActive(true);
		tapText.SetCallback(delegate(){
			// シーン移動
			SceneNavigator.Instance.Change("GameScene", 1.0f);
		});

		yield return null;
	}


	// Update is called once per frame
	void Update () {
		
	}

}
