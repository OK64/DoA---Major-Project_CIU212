using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
	private int roomCount = 0;
	private int[][] roomArray;

	void Start ()
	{
		
	}

	void Update ()
	{
		
	}

	public void _GenerateCoordinates()
	{
		//create first room here and addChild()
		roomArray[roomCount][0] = 0;
		roomArray[roomCount][1] = 0;
		roomCount++;

		int[] arr = {0, 0};//new object
		while(roomCount < 10)
		{
			arr[0] = roomArray[roomCount-1][0];
			arr[1] = roomArray[roomCount-1][1];
			int[] validSpaces = {};
			int count = 4;
			int spacesAvailable = 0;
			while(count > 0)
			{
				int[] sPos = {arr[0], arr[1]};
				switch(count)
				{
					case 1: sPos[1] -= 100;
						break;
					case 2: sPos[0] += 100;
						break;
					case 3: sPos[1] += 100;
						break;
					case 4: sPos[0] -= 100;
						break;
				}

				bool flag = false;
				for(int i = 0; i < roomCount; i++)
				{
					if (roomArray[roomCount - 1][0] == sPos[0] && roomArray[roomCount - 1][1] == sPos[1])
					{
						flag = true;
					}
				}
				if (flag == false)
				{
					validSpaces[spacesAvailable] = count;
					spacesAvailable ++;
				}
				count--;
			}
			if(spacesAvailable > 0)
			{
				int randomDirection = (int)(Random.Range(0, spacesAvailable));
				switch (validSpaces[randomDirection])
				{
					case 1: arr[1] -= 100;
						break;
					case 2: arr[0] += 100;
						break;
					case 3: arr[1] += 100;
						break;
					case 4: arr[0] -= 100;
						break;
				}

				roomArray[roomCount][0] = arr[0];
				roomArray[roomCount][1] = arr[1];
				//roomCount++;
			}
			roomCount ++;
		}
	}
}
