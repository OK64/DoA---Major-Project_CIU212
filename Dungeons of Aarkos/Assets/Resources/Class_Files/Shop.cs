using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public GameObject canvas;

	// Use this for initialization
	void Start () {
		canvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == ("Player"))
		{
			canvas.SetActive (true);
		}
	}
}
