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
		_DistanceDetection(2);
		Utils._DepthPerception(this.gameObject);
	}

	public void _DistanceDetection(int dist)
	{
		GameObject player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
		
		float dX = player.transform.position.x - this.transform.position.x;
		float dY = player.transform.position.y - this.transform.position.y;
		if(dX < 0)
			dX *= -1;
		if(dY < 0)
			dY *= -1;
		
		float diff = ((int)(Mathf.Sqrt(Mathf.Pow(dX, 2) + Mathf.Pow(dY, 2))*10));

		if(diff <= dist)
		{
			Debug.Log("In_Range: " + diff);
		}
	}
}
