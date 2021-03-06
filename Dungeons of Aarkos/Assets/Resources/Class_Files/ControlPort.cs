using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Diagnostics;
using System;
using System.IO;

public class ControlPort:MonoBehaviour
{
	private GameObject cursor;

	void Start()
	{
		GameObject weapon = new GameObject(); weapon.name = "weapon";
		weapon.AddComponent<EntityCLASS>().init(Resources.Load<Sprite>("Sprites/T0 Staff"), "WEAPON", true);
		weapon.AddComponent<WeaponClass>().bulletSprite = Resources.Load<Sprite>("Sprites/Misc/Wave Attack Front");
		weapon.GetComponent<WeaponClass>().damage = 10;
		weapon.GetComponent<WeaponClass>().fireRate = 4;
		weapon.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
		weapon.transform.parent.GetComponentInChildren<EquipmentGrid>()._AllocateObject(weapon);
		//staff.transform.parent.GetChild(GetComponentInChildren<EquipmentGrid>().transform.GetSiblingIndex());//depreciated

		GameObject ability = new GameObject(); ability.name = "ability";
		ability.AddComponent<EntityCLASS>().init(Resources.Load<Sprite>("Sprites/Items/Default_Entity"), "ABILITY", true);
		ability.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
		FindObjectOfType<InventoryGrid>()._AllocateInstance(ability);

		GameObject armor = new GameObject(); armor.name = "armor";
		armor.AddComponent<EntityCLASS>().init(Resources.Load<Sprite>("Sprites/Items/Mage Robes/Armour Robe"), "ARMOR", true);
		armor.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
		FindObjectOfType<InventoryGrid>()._AllocateInstance(armor);

		GameObject ring = new GameObject(); ring.name = "ring";
		ring.AddComponent<EntityCLASS>().init(Resources.Load<Sprite>("Sprites/Items/Default_Entity"), "RING", true);
		ring.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
		FindObjectOfType<InventoryGrid>()._AllocateInstance(ring);

		cursor = new GameObject(); cursor.name = "cursor";
		cursor.AddComponent<Cursor>();
		cursor.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;

		//UnityEngine.Debug.Log(Path.GetFullPath(Path.Combine(Application.dataPath, @"..")));
		//System.Diagnostics.Process.Start(Path.GetFullPath(Path.Combine(Application.dataPath, @".."))+"/response.bat");
		//System.Diagnostics.Process.Start(Path.GetFullPath(Path.Combine(Application.dataPath, @".."))+"/Library/response.bat");
	}
	
	void Update ()
	{
		if(Input.anyKey)
		{
			KeyInput();
		}
	}

	public void KeyInput()
	{
		//KEYBOARD INPUT
		if(Input.GetKeyDown(KeyCode.K))
		{
			Utils._GetClosestInstance(this.gameObject, DungeonPortal.FindObjectsOfType<DungeonPortal>()).gameObject.GetComponent<DungeonPortal>().EnterDungeon();
		}

		//MOUSE INPUT
		if(cursor.GetComponent<Cursor>().UIActive)
		{
			
		}else{
			if(Input.GetMouseButton(0) && GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<EquipmentGrid>().equipmentArray[0] as GameObject != null && GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<EquipmentGrid>().equipmentArray[0].transform.parent == FindObjectOfType<EquipmentGrid>().transform)
			{
				//GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<EquipmentGrid>().transform.GetChild(0).GetComponentInChildren<WeaponClass>()._WeaponLogic();//Redundant
				GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<EquipmentGrid>().equipmentArray[0].GetComponent<WeaponClass>()._WeaponLogic();
			}
		}
	}
}
