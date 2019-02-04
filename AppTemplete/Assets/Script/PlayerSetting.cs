using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetting : MonoBehaviour {

	public enum card {
		CARD_JINROH		,	// 人狼
		CARD_MADMAN		,	// 狂人
		CARD_URANAI		,	// 占い師
		CARD_GUARD		,	// ボディーガード
		CARD_HUNTER		,	// ハンター
		CARD_SHARER		,	// 共有者
		CARD_PSYCHIC	,	// 霊能者
		CARD_DETECTIVE	,	// 刑事
		CARD_SUMURA		,	// 村人

		CARD_MAX
	};

	List<string> cardName = new List<string>() {
		"jinroh"	,
		"madman"	,
		"uranai"	,
		"guard"		,
		"hunter"	,
		"sharer"	,
		"psychic"	,
		"detective"	,
		"sumura"	,
	};

	List<Sprite> cardImage = new List<Sprite>();

	Dictionary<string, string> yakushoku = new Dictionary<string, string>() {
		{	"jinroh"	,	"人狼"				},
		{	"madman"	,	"狂人"				},
		{	"uranai"	,	"占い師"			},
		{	"guard"		,	"ボディーガード"	},
		{	"hunter"	,	"ハンター"			},
		{	"sharer"	,	"共有者"			},
		{	"psychic"	,	"霊能者"			},
		{	"detective"	,	"刑事"				},
		{	"sumura"	,	"村人"				},
	};

	List<card> cardList = new List<card>() {
		card.CARD_JINROH	,	// 人狼
		card.CARD_SUMURA	,	// 村人
		card.CARD_SUMURA	,	// 村人
		card.CARD_SUMURA	,	// 村人
		card.CARD_URANAI	,	// 占い師
		card.CARD_GUARD		,	// ボディーガード
		card.CARD_MADMAN	,	// 狂人
		card.CARD_JINROH	,	// 人狼
		card.CARD_SUMURA	,	// 村人
		card.CARD_PSYCHIC	,	// 霊能者
		card.CARD_HUNTER	,	// ハンター
		card.CARD_SUMURA	,	// 村人
		card.CARD_JINROH	,	// 人狼
		card.CARD_SUMURA	,	// 村人
		card.CARD_SUMURA	,	// 村人
		card.CARD_SUMURA	,	// 村人
		card.CARD_JINROH	,	// 人狼
	};

	List<card> cardListTmp = new List<card>();

	// ミニカードの親
	public GameObject cardParent = null;

	// ミニカードのベースオブジェクト
	public GameObject cardBase = null;

	// 〇人村テキスト
	public Text playerText = null;

	// ＋－ボタン
	public Button plusButton = null;
	public Button minusButton = null;

	// ミニカードのリスト
	private List<GameObject> cardObjList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		GameObject obj;
		Image img;
		Text name;
		Sprite cardImg;

		// カード画像読み込み
		for (int i = 0; i < (int)card.CARD_MAX; i++) {
			cardImg = Resources.Load<Sprite>("Card/" + cardName[i]);
			cardImage.Add(cardImg);
		}

		// ミニカード複製
		for (int i = 0; i < MainScene.PLAYER_MAX; i++) {
			if (i == 0) {
				obj = cardBase;
			} else {
				obj = GameObject.Instantiate<GameObject>(cardBase);
				obj.transform.parent = cardParent.transform;
				obj.transform.localScale = new Vector3(1, 1, 1);
			}
			cardObjList.Add(obj);
			img = obj.GetComponent<Image>();
			int no = (int)cardList[i];
		//	img.sprite = Resources.Load<Sprite>("Card/" + cardName[no]);
			img.sprite = cardImage[no];
			img.enabled = (img.sprite != null);		// 読み込めなかったら、desable にしておく
			name = obj.GetComponentInChildren<Text>();
			name.text = yakushoku[cardName[no]];
			obj.SetActive(i < MainScene.playerNum);
		}
	}

	// Update is called once per frame
	void Update () {
		if (playerText != null) {
			playerText.text = MainScene.playerNum + "人村";
		}
		if (cardObjList.Count > 0) {
			for (int i = 1; i < cardObjList.Count; i++) {
				cardObjList[i].SetActive(i < MainScene.playerNum);
			}
		}

		// 役職変更処理
		regulationHandling();
	}

	// ＋－ボタンの制御
	public void onClickButtonPlus()
	{
		int num = MainScene.playerNum;

		num++;
		if (num > MainScene.PLAYER_MAX) {
			num = MainScene.PLAYER_MAX;
		}

		// 値更新
		MainScene.playerNum = num;
	}
	public void onClickButtonMinus()
	{
		int num = MainScene.playerNum;

		num--;
		if (num < MainScene.PLAYER_MIN) {
			num = MainScene.PLAYER_MIN;
		}

		// 値更新
		MainScene.playerNum = num;
	}

	public void onClickButtonDecide()
	{
		// カードリスト格納
		MainScene.cardList.Clear();
		for (int i = 1; i < MainScene.playerNum; i++) {
			MainScene.cardList.Add(cardList[i]);
		}
		// ソート
		MainScene.cardList.Sort();

		// シーン移動
		SceneNavigator.Instance.Change ("IntroductionScene");
	}
	
	private void regulationHandling()
	{
		// ３人レギュの時は、ボディーガードにする
		cardList[2] = (MainScene.playerNum == 3)? card.CARD_GUARD : card.CARD_SUMURA;

		// ソート
		cardListTmp.Clear();
		for (int no = 0; no < MainScene.playerNum; no++) {
			cardListTmp.Add(cardList[no]);
		}
		cardListTmp.Sort();

		// 画像設定
		for (int i = 0; i < MainScene.playerNum; i++) {
			GameObject obj = cardObjList[i];
			Image img = obj.GetComponent<Image>();
			Text name = obj.GetComponentInChildren<Text>();
			int no = (int)cardListTmp[i];
			img.sprite = cardImage[no];
			img.enabled = (img.sprite != null);		// 読み込めなかったら、desable にしておく
			name.text = yakushoku[cardName[no]];
		}

	}

}
