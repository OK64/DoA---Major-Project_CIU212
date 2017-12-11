using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
	public float damageHue;
	private bool broken;

	void Start()
	{
		broken = false;
	}
	
	void Update()
	{
		Utils._DepthPerception(this.gameObject);
		if(!broken)
		{
			if(damageHue > 0)
			{
				damageHue -= Time.deltaTime;
			}
			GetComponent<SpriteRenderer>().color = new Color(1, 1-damageHue*0.2f, 1-damageHue*0.2f);
			if(damageHue > 5)
			{
				damageHue = 5;
				broken = true;
				GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/DummyBroken");
				GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
				//Destroy(gameObject);
			}
		}

		if(broken)
		{
			GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.5f*Time.deltaTime);
			if(GetComponent<SpriteRenderer>().color.a <= 0)
			{
				GameObject.FindObjectOfType<DungeonGeneration>().exitPortal.transform.position = this.gameObject.transform.position;
				Destroy(gameObject);
				/*GameObject exitPortal = Instantiate(new GameObject(), transform.position, transform.rotation).gameObject;
				exitPortal.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Dungeons/Basic_Dungeon");
				exitPortal.AddComponent<DungeonPortal>().warpDestination = "Scene";*/
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.GetComponent<Projectiles>())
		{
			damageHue += 1;
		}
	}
}
