using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Translate (new Vector3 (-moveSpeed, 0,0));
			spriteRenderer.sprite = sprite1;
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate(new Vector3(moveSpeed,0,0));
			spriteRenderer.sprite = sprite2;
		}

		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate(new Vector3(0,moveSpeed,0));
			spriteRenderer.sprite = sprite3;
		}

		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate(new Vector3(0,-moveSpeed,0));
			spriteRenderer.sprite = sprite4;
		}
	}
}
