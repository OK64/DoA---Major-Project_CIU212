using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
	private int roomCount = 0;
	private GameObject[] roomArray;
	private Vector2[] coordArray;
	private GameObject room1;
	private GameObject floor1;
	public GameObject exitPortal;

	private GameObject player;

	void Start ()
	{
		room1 = new GameObject();
		room1.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Dungeons/Rooms/Dungeon_Wall_1");
		room1.AddComponent<PixelDetectable>().sourceTex = Resources.Load<Texture2D>("Sprites/Dungeons/Rooms/Dungeon_Wall_1");
		room1.SetActive(false);

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
		coordArray = new Vector2[10];
		coordArray[roomCount++] = new Vector2(0, 0);

		Vector2 bounds = new Vector2(room1.GetComponent<SpriteRenderer>().sprite.bounds.size.x, room1.GetComponent<SpriteRenderer>().sprite.bounds.size.y);
		int passLimit = 0;
		float[] arr = new float[2];//new object
		while(roomCount < 10 && passLimit < 100)
		{
			arr[0] = coordArray[roomCount-1].x;
			arr[1] = coordArray[roomCount-1].y;
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
					if(coordArray[i].x == sPos[0] && coordArray[i].y == sPos[1])
					{
						flag = true;
					}
				}
				if(flag == false)
				{
					validSpaces[spacesAvailable] = count;
					spacesAvailable++;
				}
				count--;
			}
			if(spacesAvailable > 0)
			{
				int randomDirection = (int)(Random.Range(0, spacesAvailable));
				switch(validSpaces[randomDirection])
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
				//GameObject room = Instantiate(room1, transform.position, transform.rotation).gameObject;
				//room.transform.position = new Vector3(arr[0], arr[1], 0);
				coordArray[roomCount] = new Vector2(arr[0], arr[1]);
				roomCount++;
			}
			passLimit++;
		}
		_GenerateRooms();
	}

	public void _GenerateRooms()
	{
		for(int i = 0; i < coordArray.Length; i++)
		{
			//UE_LOG(MyLog, Warning, TEXT("Vector Array x%d, y%d"), coordArray[i][0], coordArray[i][1]);

			string spritePath;
			string colliderPath;
			spritePath = "Sprites/Dungeons/Rooms/Closed_Wall_1";
			colliderPath = "Prefabs/Wall Colliders/Closed_Wall_Collider";
			float rotation = 0;
			if(i == 0)
			{
				//USE CLOSED BLOCK AT START
				float diffX = coordArray[i][0] - coordArray[i + 1][0];
				float diffY = coordArray[i][1] - coordArray[i + 1][1];
				rotation = (Mathf.Atan2(diffY, diffX)*(180/Mathf.PI))+90;
			}else if(i < 9){
				float diffX = coordArray[i][0] - coordArray[i - 1][0];
				float diffY = coordArray[i][1] - coordArray[i - 1][1];

				rotation = (Mathf.Atan2(diffY, diffX)*(180/Mathf.PI))+90;
				if(coordArray[i-1][0] != coordArray[i+1][0] && coordArray[i-1][1] != coordArray[i+1][1])
				{
					spritePath = "Sprites/Dungeons/Rooms/90deg_Wall_1";
					colliderPath = "Prefabs/Wall Colliders/90deg_Wall_Collider";
					bool prev = false;
					bool after = false;
					if (coordArray[i - 1][0] == coordArray[i][0])
					{
						if (coordArray[i - 1][1] > coordArray[i][1])
						{
							prev = true;
						}else{
							prev = false;
						}

						if (coordArray[i + 1][0] > coordArray[i][0])
						{
							after = true;
						} else {
							after = false;
						}

						if(prev && after)
						{
							rotation = 0;
						}else if(!prev && !after){
							rotation = 180;
						}else if(prev && !after){
							rotation = 90;
						}else{
							rotation = 270;
						}

					}else if (coordArray[i + 1][0] == coordArray[i][0])
					{
						if (coordArray[i + 1][1] > coordArray[i][1])
						{
							after = true;
						} else {
							after = false;
						}

						if (coordArray[i - 1][0] > coordArray[i][0])
						{
							prev = true;
						} else {
							prev = false;
						}

						if(prev && after)
						{
							rotation = 0;
						}else if(!prev && !after){
							rotation = 180;
						}else if(prev && !after){
							rotation = 270;
						}else{
							rotation = 90;
						}
					}
				}else if(coordArray[i - 1][0] == coordArray[i+1][0])
				{
					spritePath = "Sprites/Dungeons/Rooms/Linear_Wall_1";
					colliderPath = "Prefabs/Wall Colliders/Linear_Wall_Collider";
				}else if(coordArray[i - 1][1] == coordArray[i+1][1])
				{
					spritePath = "Sprites/Dungeons/Rooms/Linear_Wall_1";
					colliderPath = "Prefabs/Wall Colliders/Linear_Wall_Collider";
				}
			}else{
				//INSERT CLOSED BLOCK AT END
				float diffX = coordArray[i][0] - coordArray[i-1][0];
				float diffY = coordArray[i][1] - coordArray[i-1][1];
				rotation = (Mathf.Atan2(diffY, diffX)*(180/Mathf.PI))+90;
			}
			
			//room1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(spritePath);
			//room1.GetComponent<PixelDetectable>().sourceTex = Resources.Load<Texture2D>(spritePath);
			
			GameObject room = Instantiate(new GameObject(), transform.position, transform.rotation);
			room.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(spritePath);
			room.AddComponent<PixelDetectable>().sourceTex = Resources.Load<Texture2D>(spritePath);
			room.transform.position = new Vector3(coordArray[i][0], coordArray[i][1], 0);
			room.transform.eulerAngles = new Vector3(0, 0, rotation);

			GameObject collider = Instantiate(Resources.Load(colliderPath) as GameObject, room.transform.position, room.transform.rotation);

			GameObject floor = new GameObject();
			floor.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Dungeons/Rooms/Dungeon_Floor_1");
			floor.transform.parent = room.transform;
			floor.transform.localPosition = new Vector3(0, 0, 1);

			if(i+1 == coordArray.Length)
			{
				GameObject dummy = Instantiate(Resources.Load<GameObject>("Prefabs/Dummy"), room.transform.position, transform.rotation);
				//dummy.transform.parent = this.gameObject.transform.parent;
			}
		}
	}
}
