using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class LevelController : MonoBehaviour
{
    // Levels
    [Tooltip("The level to start with")]
    public int startLevel;
    [Tooltip("Directory of the Map Folder")]
    public string mapFolderDirectory;
    private int level = 0;
    private List<Map> maps;

    // Use this for initialization
    void Awake()
    {
        level = startLevel;
        maps = LoadMapList(mapFolderDirectory);
    }

    void Start () 
    {
	    // TODO: Load Level from File
	}
	
	// Update is called once per frame
	void Update () 
    {
	    // TODO: If winning condition, then go to next
	}

    List<Map> LoadMapList(string folderDir)
    {
        List<Map> mapList = new List<Map>();

        // Find the Map Files
        DirectoryInfo d = new DirectoryInfo(folderDir);
        FileInfo[] filelList = d.GetFiles(Map.MAP_FILE_EXTENSION);

        // Load all the Maps
        foreach (FileInfo file in filelList)
        {
            Debug.Log(file.Name);
            // Load the map
            //Map map = Map.LoadMap(file.Name);
            // Add the map into the list
           // mapList.Add(map);
        }

        return mapList;
    }
}
