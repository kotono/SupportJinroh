using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class TapText : MonoBehaviour {

	// タップテキスト
	private Text tapText = null;

	// Coroutine
	private IEnumerator coroutineMethod = null;

	// Callback
	UnityAction callback = null;

	// Use this for initialization
	void Start () {
		tapText = this.gameObject.GetComponent<Text>();
		StartCoroutine(coroutineMethod = tapTextAnim());
	}


	// ===================================================
	// ---------------------------------------------------
	/// <summary>
	/// タップ文字の表示を行う
	/// </summary>
	/// <returns></returns>
	private IEnumerator tapTextAnim()
	{
		float textAlpha = 0.0f;

		if (tapText == null) {
			yield break;
		}

		// 文字を透明にしておく
		tapText.color = new Color (1.0f, 1.0f, 1.0f, textAlpha);

		// アニメーション
		// Alphaを0→1にする
		tapText.gameObject.SetActive(true);
		do {
			textAlpha += 0.02f;
			if (textAlpha > 1.0f) {
				textAlpha = 1.0f;
			}

			tapText.color = new Color (1.0f, 1.0f, 1.0f, textAlpha);

			// wait
			yield return new WaitForSeconds(0.01f);

		} while (textAlpha < 1.0f) ;

		// wait
		yield return new WaitForSeconds(1.0f);

		while (true) {

			// アニメーション
			// Alphaを1→0.5にする
			tapText.gameObject.SetActive(true);
			do {
				textAlpha -= 0.04f;
				if (textAlpha < 0.0f) {
					textAlpha = 0.0f;
				}

				tapText.color = new Color (1.0f, 1.0f, 1.0f, textAlpha);

				// wait
				yield return new WaitForSeconds(0.01f);

			} while (textAlpha > 0.25f) ;

			// アニメーション
			// Alphaを0.25→1にする
			tapText.gameObject.SetActive(true);
			do {
				textAlpha += 0.02f;
				if (textAlpha > 1.0f) {
					textAlpha = 1.0f;
				}

				tapText.color = new Color (1.0f, 1.0f, 1.0f, textAlpha);

				// wait
				yield return new WaitForSeconds(0.01f);

			} while (textAlpha < 1.0f) ;

			// wait
			yield return new WaitForSeconds(0.5f);
		}

		yield return null;
	}


	// Update is called once per frame
	void Update () {
		
	}


	// コールバック設定
	public void SetCallback(UnityAction _callback){
		callback = _callback;
	}


	// 画面タップ
	public void onTap(){
		StopCoroutine (coroutineMethod);
		if (callback != null) {
			callback();
		}
		tapText.gameObject.SetActive (false);
	}


}
