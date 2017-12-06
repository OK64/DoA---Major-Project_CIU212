using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityCLASS : MonoBehaviour
{
	private bool held;

	public string type;
	public bool equippable;
	public Sprite sprite;
	
	void Awake()
	{
		held = false;
		equippable = false;
	}
	public void init(Sprite sprite, string type, bool equippable)
	{
		this.sprite = sprite;
		this.type = type;
		this.equippable = equippable;
		gameObject.AddComponent<Image>().sprite = sprite;
	}

	void Update()
	{
		_TransferCapabilities();
	}

	private void _TransferCapabilities()
	{
		if(Utils._InUIBounds(Input.mousePosition, this.gameObject.GetComponent<RectTransform>()))
		{
			if(!held)
			{
				GameObject.FindObjectOfType<Canvas>().transform.Find("Game_UI").transform.Find("Highlight").transform.position = this.transform.position;
				GameObject.FindObjectOfType<Canvas>().transform.Find("Game_UI").transform.Find("Highlight").gameObject.GetComponent<Image>().enabled = true;
			}else{
				GameObject.FindObjectOfType<Canvas>().transform.Find("Game_UI").transform.Find("Highlight").gameObject.GetComponent<Image>().enabled = false;
			}

			if(Input.GetMouseButtonDown(0) && GameObject.FindObjectOfType<Cursor>().holding == false || Input.GetMouseButton(0) && held)
			{
				transform.position = Input.mousePosition;
				held = true;
			}else if(held){
				if(equippable && Utils._InUIBounds(Input.mousePosition, GameObject.FindObjectOfType<Canvas>().transform.Find("Game_UI").GetComponentInChildren<EquipmentGrid>().GetComponent<RectTransform>()))
				{
					GameObject.FindObjectOfType<EquipmentGrid>()._AllocateObject(this.gameObject);
				}else if(Utils._InUIBounds(Input.mousePosition, GameObject.FindObjectOfType<Canvas>().transform.Find("Game_UI").GetComponentInChildren<InventoryGrid>().GetComponent<RectTransform>())){
					GameObject.FindObjectOfType<InventoryGrid>()._AllocateInstance(this.gameObject);
				}else{
					if(transform.parent.GetComponent<EquipmentGrid>())
					{
						GameObject.FindObjectOfType<EquipmentGrid>()._AllocateObject(this.gameObject);
					}else if(transform.parent.GetComponent<InventoryGrid>()){
						GameObject.FindObjectOfType<InventoryGrid>()._AllocateInstance(this.gameObject);
					}
				}
				held = false;
			}
			GameObject.FindObjectOfType<Cursor>().holding = held;
		}else if(GameObject.FindObjectOfType<Canvas>().transform.Find("Game_UI").transform.Find("Highlight").transform.position == this.transform.position){
			GameObject.FindObjectOfType<Canvas>().transform.Find("Game_UI").transform.Find("Highlight").gameObject.GetComponent<Image>().enabled = false;
		}

		if(held)
		{
			transform.position = Input.mousePosition;
		}
	}
}
