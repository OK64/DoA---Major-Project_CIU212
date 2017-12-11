using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor:MonoBehaviour
{
	private Sprite gpCursor;
	private Sprite uiCursor;

	private Texture2D gpCursor2D;
	private Texture2D uiCursor2D;

	public bool UIActive;
	public bool holding;

	void Start()
	{
		UIActive = false;
		holding = false;
		UnityEngine.Cursor.visible = false;

		gpCursor = Resources.Load<Sprite>("Sprites/UI/GPCursor");
		uiCursor = Resources.Load<Sprite>("Sprites/UI/UICursor");

		gpCursor2D = Resources.Load<Texture2D>("Sprites/UI/GPCursor");
		uiCursor2D = Resources.Load<Texture2D>("Sprites/UI/UICursor");

		//gameObject.AddComponent<Image>().sprite = uiCursor;
		//gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
	}

	void Update()
	{
		/*if(Utils._InUIBounds(Input.mousePosition, GameObject.FindObjectOfType<Canvas>().transform.Find("Game_UI").GetComponent<RectTransform>()) || Utils._InUIBounds(Input.mousePosition, GameObject.FindObjectOfType<Canvas>().transform.Find("Quest_UI").GetComponent<RectTransform>()))
		{
			UIActive = true;
			//gameObject.GetComponent<Image>().sprite = uiCursor;
			//UnityEngine.Cursor.SetCursor(uiCursor2D, new Vector2(0, 0), CursorMode.ForceSoftware);
		}else{
			UIActive = false;
			//gameObject.GetComponent<Image>().sprite = gpCursor;
			//UnityEngine.Cursor.SetCursor(gpCursor2D, new Vector2(gpCursor2D.width/2, gpCursor2D.height/2), CursorMode.ForceSoftware);
		}*/
		/*transform.position = Input.mousePosition;
		if(gameObject.GetComponent<Image>().sprite == uiCursor)
			transform.position += new Vector3((gameObject.GetComponent<RectTransform>().sizeDelta.x/2)*transform.localScale.x, -(gameObject.GetComponent<RectTransform>().sizeDelta.y/2)*transform.localScale.y, 0);
		*/
	}

	void OnGUI()
	{
		int size = 32;
		if(Utils._InUIBounds(Input.mousePosition, GameObject.FindObjectOfType<Canvas>().transform.Find("Game_UI").GetComponent<RectTransform>()) || Utils._InUIBounds(Input.mousePosition, GameObject.FindObjectOfType<Canvas>().transform.Find("Quest_UI").GetComponent<RectTransform>()))
		{
			UIActive = true;
			GUI.DrawTexture(new Rect(Input.mousePosition.x, -Input.mousePosition.y + Screen.height + 1.5f, size, size), uiCursor2D);
		}else{
			UIActive = false;
			GUI.DrawTexture(new Rect(Input.mousePosition.x - ((size/gpCursor2D.width)*gpCursor2D.width/2), -Input.mousePosition.y + Screen.height - ((size/gpCursor2D.height)*gpCursor2D.height/2) + 1.5f, size, size), gpCursor2D);
		}
	}
}
