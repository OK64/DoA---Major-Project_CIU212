using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPort:MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.anyKey)
		{
			KeyInput();
		}
	}

	public void KeyInput()
	{
		if(Input.GetKeyDown(KeyCode.K))
		{
			Utils._GetClosestInstance(this.gameObject, DungeonPortal.FindObjectsOfType<DungeonPortal>()).gameObject.GetComponent<DungeonPortal>().EnterDungeon();
		}
	}
}
