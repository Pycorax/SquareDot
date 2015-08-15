using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour 
{
    // TODO: Add the variable that holds the Map
    // TODO: Add a List of Enemies
    public const string MAP_FILE_EXTENSION = "*.map";

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public static Map LoadMap(string mapFilePath)
    {
        throw new NotImplementedException();

        return new Map();
    }
}
