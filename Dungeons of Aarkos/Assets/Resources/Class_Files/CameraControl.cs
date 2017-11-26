using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private bool ready = false;

	// Use this for initialization
	void Start() {
		if(player != null)
		{
			init();
		}else {
			//Debug.Log("Player non-existent: External Initiation Required");
		}
	}

	public void init()
	{
		offset = transform.position - player.transform.position;
		ready = true;
	}

	// Update is called once per frame
	void Update () 
	{
		if(ready)
		{
			transform.position = player.transform.position + offset;
		}
	}
}
