using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Utils : MonoBehaviour
{
	public static void _DepthPerception(GameObject obj)
	{
		GameObject player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
		float dY = player.transform.position.y - obj.transform.position.y;
		if(dY > 0)
		{
			obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, player.gameObject.transform.position.z -0.5f);
		}else {
			obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, player.gameObject.transform.position.z +0.5f);
		}
	}

	public static Vector2[] _PixelCoords(Texture2D texture)
	{
		//Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite.);
		//int[][] coordArray = {};
		Vector2[] pixelCoords = new Vector2[1];
		Vector2[] DS = pixelCoords;
		int index = 0;
		Color[] pix = texture.GetPixels(0, 0, texture.width, texture.height);
		//Debug.Log("Dimension Scale: *"+Mathf.Sqrt(pix.Length));
		for(int i = 0; i < pix.Length; i++)
		{
			if(pix[i][3] == 1)
			{
				//coordArray[index++][0] = (int)(((i/(Mathf.Sqrt(pix.Length))) - (int)(i/(Mathf.Sqrt(pix.Length))))*(Mathf.Sqrt(pix.Length)));
				//coordArray[index++][1] = (int)(i/(Mathf.Sqrt(pix.Length)));
				DS = pixelCoords;
				pixelCoords = new Vector2[index+1];
				int count = 0;
				while(count < DS.Length)
				{
					pixelCoords[count] = DS[count];
					count++;
				}
				pixelCoords[index++] = new Vector2(((i/(Mathf.Sqrt(pix.Length))) - (int)(i/(Mathf.Sqrt(pix.Length))))*(Mathf.Sqrt(pix.Length)), (int)(i/(Mathf.Sqrt(pix.Length))));
			}
		}

		/*Debug.Log("Pixel Count: "+pixelCoords.Length);
		for(int n = 0; n < pixelCoords.Length; n++)
		{
			Debug.Log(pixelCoords[n]);
		}*/

		return pixelCoords;
	}

	public static Vector2[] _PixelsToWorld(PixelDetectable sourceObject)
	{
		//Vector2[] pixelCoords = _PixelCoords(sourceObject.sourceTex);
		Vector2[] pixelCoords = new Vector2[sourceObject.pixelCoords.Length];
		for(int i = 0; i < pixelCoords.Length; i++)
		{
			pixelCoords[i][0] = sourceObject.transform.position.x;
			pixelCoords[i][1] = sourceObject.transform.position.y;
			pixelCoords[i][0] += sourceObject.pixelCoords[i][0]/100;
			pixelCoords[i][1] += sourceObject.pixelCoords[i][1]/100;
			pixelCoords[i][0] -= (sourceObject.sourceTex.width*0.01f)*0.5f;
			pixelCoords[i][1] -= (sourceObject.sourceTex.height*0.01f)*0.5f;
			//pixelCoords[i] = sourceObject.transform.TransformPoint(pixelCoords[i]);
			pixelCoords[i][0] = (float)((int)(pixelCoords[i][0]*100))/100;
			pixelCoords[i][1] = (float)((int)(pixelCoords[i][1]*100))/100;
		}
		return pixelCoords;
	}

	public static bool _PixelDetection(PixelDetectable objectA, PixelDetectable objectB)
	{
		Vector2[] pixelCoordsA = _PixelsToWorld(objectA);
		Vector2[] pixelCoordsB = _PixelsToWorld(objectB);
		foreach(Vector2 coordsA in pixelCoordsA)
		{
			foreach(Vector2 coordsB in pixelCoordsB)
			{
				if(coordsA.x == coordsB.x && coordsA.y == coordsB.y)
				{
					return true;
				}
			}
		}

		return false;
	}

	public static float _DistanceDetection(GameObject objectA, GameObject objectB)
	{		
		float dX = objectA.transform.position.x - objectB.transform.position.x;
		float dY = objectA.transform.position.y - objectB.transform.position.y;
		if(dX < 0)
			dX *= -1;
		if(dY < 0)
			dY *= -1;
		
		float diff = ((int)(Mathf.Sqrt(Mathf.Pow(dX, 2) + Mathf.Pow(dY, 2))*10));

		return diff;
	}

	public static GameObject _GetClosestInstance(GameObject targetObject, Object[] objectList)
	{
		int index = 0;
		if(objectList.Length > 1) {
			while(index < objectList.Length) {
				float dist1 = _DistanceDetection(targetObject, (GameObject)objectList[index]);
				float dist2 = _DistanceDetection(targetObject, (GameObject)objectList[index+1]);
				if(dist1 > dist2) {
					GameObject DS = (GameObject)objectList[index];
					objectList[index] = objectList[index+1];
					objectList[index+1] = DS;
					index = 0;
				}
				index++;
			}
		} else if(objectList.Length == 0) {
			return null;
		}
		Debug.Log(objectList[0].GetType());
		return GameObject.Find(objectList[0].name);
	}
}
