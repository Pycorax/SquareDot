﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TileMap : MonoBehaviour
{
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

	#region Event Functions

	// Use this for initialization
	void Start ()
	{
		map = null;
		mapWidth = mapHeight = 0.f;
		numOfTile_MapWidth = numOfTile_MapHeight = 0;
		screenWidth = screenHeight = 0.f;
		numOfTile_ScreenWidth = numOfTile_ScreenHeight = 0;
		tileSize = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	#endregion

	#region Member Functions

	void LoadMap(string filepath, float mapWidth, float mapHeight, float screenWidth, float screenHeight, float tileSize)
	{
		// Assign map variables
		this->mapWidth = mapWidth;
		this->mapHeight = mapHeight;
		this->numOfTile_MapWidth = mapWidth / tileSize;
		this->numOfTile_MapHeight = mapHeight / tileSize;

		// Assign screen variables
		this->screenWidth = screenWidth;
		this->screenHeight = screenHeight;
		this->numOfTile_ScreenWidth = screenWidth / tileSize;
		this->numOfTile_ScreenHeight = screenHeight / tileSize;

		this->tileSize = tileSize;

		if (LoadFile (filepath, screenWidth, screenHeight))
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
		uint rowCounter = 0, colCounter = 0;
		int numOfScreen_Width = Mathf.CeilToInt(this->mapWidth / screenWidth);
		int numOfScreen_Height = Mathf.CeilToInt(this->mapHeight / screenHeight);
		string line;	// Line of text from file
		string[] token;	// Individual token from line
		StreamReader file = new StreamReader(File.OpenRead(filepath)); // Open file
		while (!file.EndOfStream)
		{
			line = file.ReadLine(); // Read line from csv file
			string[] tokens = line.Split(','); // Split col into array of strings
			if (line.StartsWith("//")) // Commented line check for length error
			{
				if (tokens.Length != this->numOfTile_MapWidth)
				{
					return false;
				}
			}
			else // Add to map
			{
				foreach(string element in tokens)
				{
					map[rowCounter][colCounter++] = new Tile( (Tile.TILE_TYPE)element );
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
