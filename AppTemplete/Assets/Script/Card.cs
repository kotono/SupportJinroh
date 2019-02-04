using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	// Canvas Group
	public CanvasGroup canvasGroup = null;

	// 名前テキスト
	public Text nameText = null;

	// カードイメージ
	public Image cardImage = null;

	// タップテキスト
	public Text tapText = null;

	// 次へテキスト
	public Text nextText = null;

	// タップ待ち用フラグ
	private bool tapWait = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(cardView());
	}

	// ===================================================
	// ---------------------------------------------------
	/// <summary>
	/// カードの表示を行う
	/// </summary>
	/// <returns></returns>
	private IEnumerator cardView(System.Action endcallback = null)
	{
		Sprite image;
		float scaleX = 1.0f;
		float posX = 0.0f;
		float posY = 300.0f;
		float textAlpha = 0.0f;

		// 文字を透明にしておく
		nameText.color = new Color (1.0f, 1.0f, 1.0f, textAlpha);
		tapText.color = new Color (1.0f, 1.0f, 1.0f, textAlpha);
		nextText.color = new Color (1.0f, 1.0f, 1.0f, textAlpha);

		// アニメーション
		// Alphaを0→1にする
		textAlpha = 0.0f;
		nameText.gameObject.SetActive(true);
		do {
			textAlpha += 0.2f;
			if (textAlpha > 1.0f) {
				textAlpha = 1.0f;
			}

			nameText.color = new Color (1.0f, 1.0f, 1.0f, textAlpha);

			// wait
			yield return new WaitForSeconds(0.01f);

		} while (textAlpha < 1.0f) ;

		// 待ち
		tapWait = true;
		while (tapWait) {
			yield return null;
		}

		// タップ用の文字を消す
		nameText.gameObject.SetActive(false);

		// アニメーション
		// Scale.xを1にする
	//	cardImage.transform.localPosition = new Vector3( 0, posY, 0);
		posY = cardImage.transform.localPosition.y;
		cardImage.transform.localScale = new Vector3( scaleX, 1, 1);

		// 裏面
		image = Resources.Load<Sprite>("Card/back");
		if (cardImage != null) {
			cardImage.sprite = image;
		}

		// アニメーション
		// Pos.yを→0にする
		do {
			posY -= 24.0f;
			if (posY < 0.0f) {
				posY = 0.0f;
			}

			cardImage.transform.localPosition = new Vector3( posX, posY, 0);

			// wait
			yield return new WaitForSeconds(0.01f);

		} while (posY > 0.0f) ;

		// アニメーション
		// Alphaを0→1にする
		textAlpha = 0.0f;
		tapText.gameObject.SetActive(true);
		do {
			textAlpha += 0.2f;
			if (textAlpha > 1.0f) {
				textAlpha = 1.0f;
			}

			tapText.color = new Color (1.0f, 1.0f, 1.0f, textAlpha);

			// wait
			yield return new WaitForSeconds(0.01f);

		} while (textAlpha < 1.0f) ;

		// 待ち
		tapWait = true;
		while (tapWait) {
			yield return null;
		}

		// タップ用の文字を消す
		tapText.gameObject.SetActive(false);

		// wait
		yield return new WaitForSeconds(1.0f);

		// アニメーション
		// Scale.xを1→0にする
		do {
			scaleX -= 0.1f;
			if (scaleX < 0.0f) {
				scaleX = 0.0f;
			}

			cardImage.transform.localScale = new Vector3( scaleX, 1, 1);

			// wait
			yield return new WaitForSeconds(0.01f);

		} while (scaleX > 0.0f) ;

		// 表面
		image = Resources.Load<Sprite>("Card/sumura");
		if (cardImage != null) {
			cardImage.sprite = image;
		}

		// アニメーション
		// Scale.xを0→1にする
		do {
			scaleX += 0.1f;
			if (scaleX > 1.0f) {
				scaleX = 1.0f;
			}

			cardImage.transform.localScale = new Vector3( scaleX, 1, 1);

			// wait
			yield return new WaitForSeconds(0.01f);

		} while (scaleX < 1.0f) ;

		// wait
		yield return new WaitForSeconds(1.0f);

		// アニメーション
		// Pos.xを→-500にする
		do {
			posX -= 32.0f;
			if (posX < -500.0f) {
				posX = -500.0f;
			}

			cardImage.transform.localPosition = new Vector3( posX, posY, 0);

			// wait
			yield return new WaitForSeconds(0.01f);

		} while (posX > -500.0f) ;

		// アニメーション
		// Alphaを0→1にする
		textAlpha = 0.0f;
		nextText.gameObject.SetActive(true);
		do {
			textAlpha += 0.2f;
			if (textAlpha > 1.0f) {
				textAlpha = 1.0f;
			}

			nextText.color = new Color (1.0f, 1.0f, 1.0f, textAlpha);

			// wait
			yield return new WaitForSeconds(0.01f);

		} while (textAlpha < 1.0f) ;

		// 待ち
		tapWait = true;
		while (tapWait) {
			yield return null;
		}

		// 終了コールバック
		if (endcallback != null) {
			endcallback();
		}

		// アニメーション
		// Alphaを→0にする
		textAlpha = 1.0f;
		do {
			textAlpha -= 0.2f;
			if (textAlpha < 0.0f) {
				textAlpha = 0.0f;
			}

			canvasGroup.alpha = textAlpha;

			// wait
			yield return new WaitForSeconds(0.01f);

		} while (textAlpha < 1.0f) ;

		yield return null;
	}

	// Update is called once per frame
	void Update ()
	{
	}

	// 画面タップ
	public void onTap(){
		tapWait = false;
	}

}
