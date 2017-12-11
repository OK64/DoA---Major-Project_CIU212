using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponClass:MonoBehaviour//EntityCLASS inheritence yet to be determined.
{
	public int damage;
	public float fireRate;
	public Sprite bulletSprite;
	private float fireTimer;

	void Awake()
	{
		fireTimer = 0;
	}

	void Update()
	{
		if(fireTimer > 0)
			fireTimer -= Time.deltaTime*fireRate;
	}

	public void _WeaponLogic()
	{
		while(fireTimer <= 0)
		{
			float setRotation = 0;
			setRotation = (Mathf.Atan2(Input.mousePosition.y - Screen.height/2, Input.mousePosition.x - Screen.width/2)*180/Mathf.PI)+90;
			Quaternion rotation = Quaternion.Euler(0, 0, setRotation);
			
			GameObject bullet = new GameObject();
			bullet.AddComponent<SpriteRenderer>().sprite = bulletSprite;
			//Color[] color = bulletSprite.texture.GetPixels((int)bulletSprite.textureRect.x, (int)bulletSprite.textureRect.y, (int)bulletSprite.textureRect.width, (int)bulletSprite.textureRect.height);
			//Texture2D texture = new Texture2D((int)bulletSprite.rect.width, (int)bulletSprite.rect.height); texture.SetPixels(color);
			bullet.AddComponent<Projectiles>().sourceTex = bulletSprite.texture;
			bullet.GetComponent<Projectiles>().damage = damage;
			bullet.GetComponent<Projectiles>().moveSpeed = 0.015f;
			bullet.transform.position = GameObject.FindObjectOfType<PlayerMovement>().transform.position;
			bullet.transform.rotation = rotation;
			fireTimer += 1;
		}
	}
}
