using UnityEngine;
using System.Collections;

public enum TILE_TYPE
{
	TILE_NONE = 0,	// Air
	TILE_FLOOR_1,	// Top part of tile
	TILE_FLOOR_2,	// Supporting tile for floor_1
	NUM_TILE		// Total number of tile types
};

public class Tile : MonoBehaviour
{
	// Public Fields
	public TILE_TYPE Type{get{return type;}}

	// Variables
	private TILE_TYPE type;

	#region Event Functions

	// Use this for initialization
	void Start ()
	{
		type = TILE_TYPE.TILE_NONE;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	#endregion

	#region Member Functions

	public void Set(TILE_TYPE type)
	{
		this.type = type;
	}

	#endregion
}
