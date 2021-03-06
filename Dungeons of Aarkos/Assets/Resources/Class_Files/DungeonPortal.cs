﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DungeonPortal : MonoBehaviour
{
	public string warpDestination;
	private bool inRange;

	public GameObject enterButton;

	void Awake()
	{
		enterButton = GameObject.FindObjectOfType<Canvas>().transform.Find("Game_UI").Find("Enter Button").gameObject;
		if(enterButton != null)
		{
			enterButton.SetActive(false);
		}
	}

	void Start ()
	{
		inRange = false;
	}
	
	void Update ()
	{
		Utils._DepthPerception(this.gameObject);

		if(Utils._DistanceDetection(this.gameObject, GameObject.FindObjectOfType<PlayerMovement>().gameObject) < 3)
		{
			inRange = true;
		}else{
			inRange = false;
		}

		if(enterButton != null)
			enterButton.SetActive(inRange);
	}

	public void EnterDungeon()
	{
		if(inRange && warpDestination != null)
		{
			SceneManager.LoadScene(warpDestination);
		}
	}
}
