using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor:MonoBehaviour
{
	private Sprite gpCursor;
	private Sprite uiCursor;

	public bool UIActive;
	public bool holding;

	void Start()
	{
		UIActive = false;
		holding = false;
		UnityEngine.Cursor.visible = false;

		gpCursor = Resources.Load<Sprite>("Sprites/UI/GPCursor");
		uiCursor = Resources.Load<Sprite>("Sprites/UI/UICursor");

		gameObject.AddComponent<Image>().sprite = uiCursor;
		gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
	}

	void Update()
	{
		if(Utils._InUIBounds(Input.mousePosition, GameObject.FindObjectOfType<Canvas>().transform.Find("Game_UI").GetComponent<RectTransform>()))
		{
			UIActive = true;
			gameObject.GetComponent<Image>().sprite = uiCursor;
		}else{
			UIActive = false;
			gameObject.GetComponent<Image>().sprite = gpCursor;
		}

		transform.position = Input.mousePosition;
		if(gameObject.GetComponent<Image>().sprite == uiCursor)
			transform.position += new Vector3((gameObject.GetComponent<RectTransform>().sizeDelta.x/2)*transform.localScale.x, -(gameObject.GetComponent<RectTransform>().sizeDelta.y/2)*transform.localScale.y, 0);
	}
}
