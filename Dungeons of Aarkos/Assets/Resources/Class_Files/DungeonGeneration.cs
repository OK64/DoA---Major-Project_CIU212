using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
	private int roomCount = 0;
	private GameObject[] roomArray;
	private GameObject room1;
	private GameObject floor1;
	public GameObject exitPortal;

	private GameObject player;

	void Start ()
	{
		room1 = new GameObject();
		room1.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Dungeons/Rooms/Dungeon_Wall_1");
		room1.AddComponent<PixelDetectable>().sourceTex = Resources.Load<Texture2D>("Sprites/Dungeons/Rooms/Dungeon_Wall_1");

		floor1 = new GameObject();
		floor1.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Dungeons/Rooms/Dungeon_Floor_1");
		floor1.transform.parent = room1.transform;
		floor1.transform.localPosition = new Vector3(0, 0, 1);
		
		player = Resources.Load<GameObject>("Prefabs/Player");
		player.tag = "Player";
		player = Instantiate(player, transform.position, transform.rotation).gameObject;
		player.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y, -1);

		UnityEngine.Camera.main.GetComponent<CameraControl>().player = player;
		UnityEngine.Camera.main.GetComponent<CameraControl>().init();

		//exitPortal = new GameObject();
		exitPortal = Instantiate(new GameObject(), transform.position, transform.rotation).gameObject;
		exitPortal.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Dungeons/Basic_Dungeon");
		exitPortal.AddComponent<DungeonPortal>().warpDestination = "Scene";

		_GenerateDungeon();
	}

	void Update ()
	{
		//Utils._DepthPerception(this.gameObject);
	}

	public void _GenerateDungeon()
	{
		roomArray = new GameObject[10];
		roomArray[roomCount] = room1;
		roomCount++;

		Vector2 bounds = new Vector2(room1.GetComponent<SpriteRenderer>().sprite.bounds.size.x, room1.GetComponent<SpriteRenderer>().sprite.bounds.size.y);
		int passLimit = 0;
		float[] arr = new float[2];//new object
		while(roomCount < 10 && passLimit < 100)
		{
			arr[0] = roomArray[roomCount-1].transform.position.x;
			arr[1] = roomArray[roomCount-1].transform.position.y;
			int[] validSpaces = new int[4];
			int count = 4;
			int spacesAvailable = 0;
			while(count > 0)
			{
				float[] sPos =  new float[2];
				sPos[0] = arr[0];
				sPos[1] = arr[1];
				switch(count)
				{
					case 1: sPos[1] -= bounds.y;
						break;
					case 2: sPos[0] += bounds.x;
						break;
					case 3: sPos[1] += bounds.y;
						break;
					case 4: sPos[0] -= bounds.x;
						break;
				}

				bool flag = false;
				for(int i = 0; i < roomCount; i++)
				{
					if (roomArray[i].transform.position.x == sPos[0] && roomArray[i].transform.position.y == sPos[1])
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
					case 1: arr[1] -= bounds.y;
						break;
					case 2: arr[0] += bounds.x;
						break;
					case 3: arr[1] += bounds.y;
						break;
					case 4: arr[0] -= bounds.x;
						break;
				}
				GameObject room = Instantiate(room1, transform.position, transform.rotation).gameObject;
				room.transform.position = new Vector3(arr[0], arr[1], 0);
				roomArray[roomCount] = room;
				roomCount++;
			}
			passLimit++;
		}
	}
}
