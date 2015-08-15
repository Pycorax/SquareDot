using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class TileMap : MonoBehaviour
{
	// Public Fields
	public List<List<Tile>> Map{get{return map;}}
	public float TileSize{get{return TileSize;}}
	public float MapWidth{get{return mapWidth;}}
	public float MapHeight{get{return mapHeight;}}
	public uint NumOfTile_MapWidth{get{return numOfTile_MapWidth;}}
	public uint NumOfTile_MapHeight{get{return numOfTile_MapHeight;}}
	
	// Screen variables
	public float ScreenWidth{get{return screenWidth;}}
	public float ScreenHeight{get{return screenHeight;}}
	public uint NumOfTile_ScreenWidth{get{return numOfTile_ScreenWidth;}}
	public uint NumOfTile_ScreenHeight{get{return numOfTile_ScreenHeight;}}
	public float ScrollOffset_X{get{return scrollOffset_X;}}
	public float ScrollOffset_Y{get{return scrollOffset_Y;}}

	// Variables
	private List<List<Tile>> map;
	private float tileSize;

	// Map variables
	private float mapWidth;
	private float mapHeight;
	private uint numOfTile_MapWidth;
	private uint numOfTile_MapHeight;

	// Screen variables
	private float screenWidth;
	private float screenHeight;
	private uint numOfTile_ScreenWidth;
	private uint numOfTile_ScreenHeight;
	private float scrollOffset_X;
	private float scrollOffset_Y;

	#region Event Functions

	void Awake ()
	{
		map = null;
		mapWidth = mapHeight = 0.0f;
		numOfTile_MapWidth = numOfTile_MapHeight = 0;
		screenWidth = screenHeight = 0.0f;
		numOfTile_ScreenWidth = numOfTile_ScreenHeight = 0;
		tileSize = 0;
		scrollOffset_X = scrollOffset_Y = 0.0f;
	}

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	#endregion

	#region Member Functions

	public void LoadMap(string filepath, float mapWidth, float mapHeight, float screenWidth, float screenHeight, float tileSize)
	{
		// Assign map variables
		this.mapWidth = mapWidth;
		this.mapHeight = mapHeight;
		this.numOfTile_MapWidth = Convert.ToUInt32(Mathf.CeilToInt(mapWidth / tileSize));
		this.numOfTile_MapHeight = Convert.ToUInt32(Mathf.CeilToInt(mapHeight / tileSize));

		// Assign screen variables
		this.screenWidth = screenWidth;
		this.screenHeight = screenHeight;
		this.numOfTile_ScreenWidth = Convert.ToUInt32(Mathf.CeilToInt(screenWidth / tileSize));
		this.numOfTile_ScreenHeight = Convert.ToUInt32(Mathf.CeilToInt(screenHeight / tileSize));

		this.tileSize = tileSize;

		if (LoadFile (filepath))
		{
			Debug.Log (filepath + " has been loaded successfully!");
		}
		else
		{
			Debug.Log("Impossible to open " + filepath);
		}
	}

	bool LoadFile(string filepath)
	{
		int rowCounter = 0, colCounter = 0;
		string line;	// Line of text from file
		string[] token;	// Individual token from line
		StreamReader file = new StreamReader(File.OpenRead(filepath)); // Open file
		while (!file.EndOfStream)
		{
			line = file.ReadLine(); // Read line from csv file
			string[] tokens = line.Split(','); // Split col into array of strings
			if (line.StartsWith("//")) // Commented line check for length error
			{
				if (tokens.Length != this.numOfTile_MapWidth || tokens.Length != this.numOfTile_MapWidth - 1) // If length == numOfTile_MapWidth, no decimal with aspect ratio
				{
					return false;
				}
			}
			else // Add to map
			{
				foreach(string element in tokens)
				{
					Tile newTile = new Tile();
					newTile.Set((TILE_TYPE)Convert.ToUInt32(element));
					map[rowCounter][colCounter++] = newTile;
				}
				colCounter = 0;	// Reset columns
				++rowCounter;	// Next row
			}
		}
		file.Close(); // Close file
		return true;
	}

	#endregion
}
