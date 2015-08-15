using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
	public enum TILE_TYPE
	{
		TILE_NONE = 0,	// Air
		TILE_FLOOR_1,	// Top part of tile
		TILE_FLOOR_2,	// Supporting tile for floor_1
		NUM_TILE,		// Total number of tile types
	};

	// Variables
	private TILE_TYPE type;

	#region Event Functions

	// Use this for initialization
	Tile(TILE_TYPE type)
	{
		this->type = type;
	}

	void Start ()
	{
		type = TILE_TYPE.TILE_NONE;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	#endregion
}
