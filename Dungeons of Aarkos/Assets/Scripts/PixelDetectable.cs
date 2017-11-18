using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelDetectable:MonoBehaviour
{
	public Texture2D sourceTex;
	public Vector2[] pixelCoords;
	//public GameObject pref;

	void Start()
	{
		pixelCoords = Utils._PixelCoords(sourceTex);
		Debug.Log("started");
		/*Vector2[] asd = Utils._PixelsToWorld(this);
		foreach(Vector2 pos in asd)
		{
			pref = Instantiate(pref, transform.position, transform.rotation);
			//pref.transform.position = new Vector3(pos.x/100 - 1.25f, pos.y/100 - 1.25f, 0);
			pref.transform.position = new Vector3(pos.x, pos.y, 0);
		}*/
	}
}
