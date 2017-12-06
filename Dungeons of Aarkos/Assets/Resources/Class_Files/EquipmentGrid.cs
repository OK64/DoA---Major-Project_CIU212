using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentGrid:MonoBehaviour
{
	public GameObject[] equipmentArray;
	
	void Awake()
	{
		equipmentArray = new GameObject[4];
	}
	
	void Update(){}

	public void _AllocateObject(GameObject item)
	{
		if(item.GetComponent<EntityCLASS>().equippable)
		{
			item.transform.parent = gameObject.transform;
			item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

			uint index;
			float posScaleX = (gameObject.GetComponent<RectTransform>().sizeDelta.x*gameObject.transform.localScale.x)/4;
			string type = item.GetComponent<EntityCLASS>().type;
			if(type == "WEAPON")
			{
				item.transform.position = transform.GetChild(0).transform.position;		
				index = 0;	
			}else if(type == "ABILITY"){
				item.transform.position = transform.GetChild(0).transform.position + new Vector3(posScaleX*1, 0, 0);
				index = 1;
			}else if(type == "ARMOR"){
				item.transform.position = transform.GetChild(0).transform.position + new Vector3(posScaleX*2, 0, 0);
				index = 2;
			}else{
				item.transform.position = transform.GetChild(0).transform.position + new Vector3(posScaleX*3, 0, 0);
				index = 3;
			}

			/*for(int i = 0; i < equipmentArray.Length; i++)
			{
				if(equipmentArray[index] as GameObject != null && equipmentArray[i].transform.parent != this.gameObject.transform)
				{
					equipmentArray[i] = null;
				}
			}*/
			if(equipmentArray[index] as GameObject != null && equipmentArray[index].transform.parent == this.gameObject.transform && item != equipmentArray[index])
			{
				GameObject.FindObjectOfType<Canvas>().transform.GetComponentInChildren<InventoryGrid>()._AllocateInstance(equipmentArray[index]);
				equipmentArray[index] = item;
			}else{
				equipmentArray[index] = item;
			}
		}
	}
}
