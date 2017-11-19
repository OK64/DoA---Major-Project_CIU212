using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public Sprite spriteF;
	public Sprite spriteB;
	public Sprite spriteL;
	public Sprite spriteR;
	public Sprite spriteFR;
	public Sprite spriteFL;
	public Sprite spriteBR;
	public Sprite spriteBL;
	public Sprite spriteLR;
	public Sprite spriteLL;
	public Sprite spriteRR;
	public Sprite spriteRL;

	public GameObject waveAttack;

	private SpriteRenderer spriteRenderer;

	private float walkCycleTimer;
	private bool walking;

	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		walkCycleTimer = 0.25f;
		walking = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.anyKey || walking)
		{
			Movement();
		}
		Attacking ();
	}

	void Movement()
	{
		bool overPress = Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A);
		if(!walking)
		{
			walkCycleTimer = 0;
			walking = true;
		}

		bool transition = false;
		if(walkCycleTimer > 0)
		{
			walkCycleTimer -= Time.deltaTime;
		}else {
			transition = true;
			walkCycleTimer = 0.25f;
		}
		string LoR;
		LoR = spriteRenderer.sprite.name.ToCharArray(0, spriteRenderer.sprite.name.Length)[spriteRenderer.sprite.name.Length-1].ToString();
		if(!overPress)
		{
			if(Input.GetKey(KeyCode.A)) 
			{
				if(Input.GetKeyDown(KeyCode.A) && (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
				{
					spriteRenderer.sprite = spriteLR;
				}
				transform.Translate (new Vector3 (-moveSpeed, 0,0));
				if(transition)
				{
					if(LoR == "L")
					{
						spriteRenderer.sprite = spriteLR;
					}else{
						spriteRenderer.sprite = spriteLL;
					}
				}
			}else if(Input.GetKeyUp(KeyCode.A) && (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
			{
				spriteRenderer.sprite = spriteL;
				walking = false;
			} 

			if(Input.GetKey(KeyCode.D)) 
			{
				if(Input.GetKeyDown(KeyCode.D) && (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
				{
					spriteRenderer.sprite = spriteRR;
				}
				transform.Translate(new Vector3(moveSpeed,0,0));
				if(transition)
				{
					if(LoR == "L")
					{
						spriteRenderer.sprite = spriteRR;
					}else{
						spriteRenderer.sprite = spriteRL;
					}
				}
			}else if(Input.GetKeyUp(KeyCode.D) && (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
			{
				spriteRenderer.sprite = spriteR;
				walking = false;
			}
		}else if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
		{
			spriteRenderer.sprite = spriteF;
		}

		if(Input.GetKey(KeyCode.W)) 
		{
			if(Input.GetKeyDown(KeyCode.W))
			{
				spriteRenderer.sprite = spriteBR;
			}
			transform.Translate(new Vector3(0,moveSpeed,0));
			if(transition)
			{
				if(LoR == "L")
				{
					spriteRenderer.sprite = spriteBR;
				}else{
					spriteRenderer.sprite = spriteBL;
				}
			}
		}else if(Input.GetKeyUp(KeyCode.W))
		{
			spriteRenderer.sprite = spriteB;
			walking = false;
		}

		if(Input.GetKey(KeyCode.S)) 
		{
			if(Input.GetKeyDown(KeyCode.S))
			{
				spriteRenderer.sprite = spriteFR;
			}
			transform.Translate(new Vector3(0,-moveSpeed,0));
			if(transition)
			{
				if(LoR == "L")
				{
					spriteRenderer.sprite = spriteFR;
				}else{
					spriteRenderer.sprite = spriteFL;
				}
			}
		}else if(Input.GetKeyUp(KeyCode.S))
		{
			spriteRenderer.sprite = spriteF;
			walking = false;
		}
	}

	void Attacking()
	{
		if(Input.GetMouseButtonDown(0))
		{
			float setRotation = 0;
			setRotation = (Mathf.Atan2(Input.mousePosition.y - Screen.height/2, Input.mousePosition.x - Screen.width/2)*180/Mathf.PI)+90;
			Quaternion rotation = Quaternion.Euler(0, 0, setRotation);
			
			Instantiate(waveAttack, transform.position, rotation);
		}
	}
}
