using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour {

	[SerializeField]
	RectTransform prefab = null;

	void Start () 
	{
		for(int i=2; i<13; i++)
		{
			var item = GameObject.Instantiate(prefab) as RectTransform;
			item.SetParent(transform, false);

			var text = item.GetComponentInChildren<Text>();
			text.text = "Player" + i.ToString();
		}
	}
}