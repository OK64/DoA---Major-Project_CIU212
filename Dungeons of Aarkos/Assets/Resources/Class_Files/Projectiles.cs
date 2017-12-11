using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles:PixelDetectable
{
	public int damage;
	public float moveSpeed;
	
	void Start()
	{
		transform.Translate(new Vector3(0,-0.05f,0));
		Utils._DepthPerception(this.gameObject);
		Destroy(gameObject, 1);
		
		pixelCoords = Utils._PixelCoords(sourceTex);
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.Translate(new Vector3(0,-moveSpeed,0));
		Utils._DepthPerception(this.gameObject);
		//gameObject.transform.position += new Vector3(Mathf.Cos(transform.rotation.z)*0.01f, Mathf.Sin(transform.rotation.z)*0.01f, 0);

		//GameObject[] list = GameObject.FindGameObjectsWithTag("Pixel Detected");
		/*foreach(GameObject obj in list)
		{
			Ray a = new Ray(gameObject.transform.position, new Vector3(0, 0, 1));
			if(Physics2D.Raycast(gameObject.transform.position, new Vector3(0, 0, 1), 1))
			{
				Destroy(gameObject);
			}
		}*/
		

		//Commented out as it is causes large fps drops
		/*PixelDetectable[] pixList = GameObject.FindObjectsOfType<PixelDetectable>();
		foreach(PixelDetectable obj in pixList)
		{
			if(obj != this && obj.name != this.name && Utils._PixelDetection(this, obj))
			{
				Destroy(this.gameObject);
			}
		}*/

		if(Physics2D.Raycast(gameObject.transform.position, new Vector2(0, 0)) && Physics2D.Raycast(gameObject.transform.position, new Vector2(0, 0)).collider.gameObject != GameObject.FindObjectOfType<PlayerMovement>().gameObject)
		{
			if(GameObject.FindObjectOfType<Dummy>() != null && Physics2D.Raycast(gameObject.transform.position, new Vector2(0, 0)).collider.gameObject == GameObject.FindObjectOfType<Dummy>().gameObject)
			{
				GameObject.FindObjectOfType<Dummy>().damageHue += 1;
			}
			Destroy(gameObject);
		}

		/*foreach(GameObject obj in list)
		{
			if(obj.GetComponent<SpriteRenderer>().sprite.
		}*/
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.GetComponent<PlayerMovement>() != true)
		{
			Destroy(gameObject);
		}
	}
}
