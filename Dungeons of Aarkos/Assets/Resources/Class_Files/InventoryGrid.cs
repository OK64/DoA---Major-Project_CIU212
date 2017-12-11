using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid:MonoBehaviour
{
	private GameObject[] inventory;

	void Awake()
	{
		inventory = new GameObject[12];
	}
	
	void Update(){}

	public void _AllocateInstance(GameObject item)
	{
		for(int n = 0; n < inventory.Length; n++)
		{
			if(inventory[n] != null)
			{
				if(inventory[n] == item && item.transform.parent != this.gameObject.transform)
				{
					inventory[n] = null;
				}else{
					bool identified = false;
					uint index = 0;
					while(index < inventory.Length)
					{
						if(inventory[index] != null)
						{
							if(inventory[index] == inventory[n])
							{
								if(identified)
								{
									inventory[index] = null;
								}else{
									identified = true;
								}
							}
						}
						index++;
					}
				}
			}
		}
		
		float posScaleX = (gameObject.GetComponent<RectTransform>().sizeDelta.x*gameObject.transform.localScale.x)/4; posScaleX *= 1 - (0.10f/(40/10));//Considders the thin lining between cells. (generally meant to have 2x cell division thickness, 1x thick perimiter [this grid has a cell division thickness of x1])
		for(int i = 0; i < inventory.Length; i++)
		{
			bool identified = false;
			uint index = 0;
			while(index < inventory.Length)
			{
				if(inventory[index] == item)
				{
					identified = true;
					break;
				}
				index++;
			}
			if(identified)
			{
				item.transform.position = transform.GetChild(0).transform.position + new Vector3((index - ((int)(index/4))*4)*posScaleX, -((int)(index/4))*posScaleX, 0);
			}else{
				if(item == inventory[i])
				{
					item.transform.position = transform.GetChild(0).transform.position + new Vector3((i - ((int)(i/4))*4)*posScaleX, -((int)(i/4))*posScaleX, 0);
					break;
				}
				if(inventory[i] == null || inventory[i] != null && inventory[i].transform.parent != this.gameObject.transform)
				{
					item.transform.SetParent(gameObject.transform);
					item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
					item.transform.position = transform.GetChild(0).transform.position + new Vector3((i - ((int)(i/4))*4)*posScaleX, -((int)(i/4))*posScaleX, 0);
					inventory[i] = item;
					break;
				}
			}
		}
	}
}
