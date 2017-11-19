using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyArea : MonoBehaviour
{
	void Start ()
	{
		
	}
	
	void Update()
	{
		Utils._DepthPerception(this.gameObject);
		if(Utils._DistanceDetection(gameObject, GameObject.FindObjectOfType<PlayerMovement>().gameObject) < 3)
		{
			//Debug.Log("In_Range");
		}
	}
}
