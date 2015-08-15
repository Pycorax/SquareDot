using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Render : MonoBehaviour {

	private List<GameObject> renderMap;

    public GameObject placeholderTile;

	private GameObject[] tileList = new GameObject[(int)TILE_TYPE.NUM_TILE];
    private TileMap levelMap;

	#region Event Functions

	// Use this for initialization
	void Start ()
	{
	    for (int i = 0; i < (int) TILE_TYPE.NUM_TILE; ++i)
	    {
	        tileList[i] = placeholderTile;
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
        RenderTileMap(levelMap);
	}

	#endregion

	#region Member Functions

	public void InitRenderMap(TileMap map)
	{
		for (int i = 0; i < map.NumOfTile_ScreenWidth * map.NumOfTile_ScreenHeight; ++i) // Init renderMap with default value and active as false
		{
			renderMap.Add(new GameObject());
			renderMap[i].SetActive(false);
		}

	    levelMap = map;
	}

	public void RenderTileMap(TileMap map)
	{
		Vector3 scrollTileOffset = new Vector3(map.ScrollOffset_X % map.TileSize, map.ScrollOffset_Y % map.TileSize);
		Vector3 startPos = new Vector3( (-map.ScreenWidth*0.5f) - scrollTileOffset.x , (-map.ScreenHeight*0.5f) - scrollTileOffset.y ); // Botto right
		for (int row = 0; row < map.NumOfTile_ScreenHeight; ++row)			// Number of rows
		{
			for (int col = 0; col < map.NumOfTile_ScreenWidth + 1; ++col)	// Number of columns (+1 for ScrollOffset)
			{
				// World origin in middle (Negative half size to Positive half size)
				switch (map.Map[Mathf.CeilToInt(scrollTileOffset.y) + row][Mathf.CeilToInt(scrollTileOffset.x) + col].Type)
				{
				case TILE_TYPE.TILE_NONE:
					{
						renderMap[Convert.ToInt32((row * map.NumOfTile_ScreenWidth) + col)].SetActive(false);
					}
					break;
				case TILE_TYPE.TILE_FLOOR_1:
					{
						renderMap[Convert.ToInt32((row * map.NumOfTile_ScreenWidth) + col)] = tileList[Convert.ToInt32(TILE_TYPE.TILE_FLOOR_1)];
						renderMap[Convert.ToInt32((row * map.NumOfTile_ScreenWidth) + col)].SetActive(true);
						renderMap[Convert.ToInt32((row * map.NumOfTile_ScreenWidth) + col)].transform.Translate(startPos.x + (col * map.TileSize), startPos.y + (row * map.TileSize), 0);
					}
					break;
				case TILE_TYPE.TILE_FLOOR_2:
					{
						renderMap[Convert.ToInt32((row * map.NumOfTile_ScreenWidth) + col)] = tileList[Convert.ToInt32(TILE_TYPE.TILE_FLOOR_2)];
						renderMap[Convert.ToInt32((row * map.NumOfTile_ScreenWidth) + col)].SetActive(true);
						renderMap[Convert.ToInt32((row * map.NumOfTile_ScreenWidth) + col)].transform.Translate(startPos.x + (col * map.TileSize), startPos.y + (row * map.TileSize), 0);
					}
					break;
				}
			}
		}
	}

	#endregion

}
