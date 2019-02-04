using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour {

	// あまり美しくないけど、グローバル変数をここに定義
	public const int PLAYER_MIN = 3;
	public const int PLAYER_MAX = 14;
	public static int playerNum = (PLAYER_MIN + PLAYER_MAX) / 3;

	// 選択したレギュレーション
	public static List<PlayerSetting.card> cardList = new List<PlayerSetting.card>();

	// Use this for initialization
	void Start () {
		// シーン移動
		SceneNavigator.Instance.Change("TitleScene");

		// 存在し続ける
		DontDestroyOnLoad(this);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
