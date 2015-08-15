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

    // Current Level
    private Map currentMap;        // Reference to the Current Map

    // Renderer
    public Render renderer;

    #region Event Functions

        // Use this for initialization
        void Awake()
        {
            level = startLevel;
            maps = LoadMapList(mapFolderDirectory);
        }

        void Start()
        {
            // Load Level from File
            try
            {
                currentMap = maps[level];
                loadLevel(currentMap);
            }
            catch (NotImplementedException e)
            {
                Debug.Log("Not Implemented Yet!");
            }
        }

        // Update is called once per frame
        void Update()
        {
            try
            {
                if (currentMap.IsCompleted())
                {
                    // Go to next level
                    gotoNextLevel();
                }
            }
            catch (NotImplementedException e)
            {
                Debug.Log("Not Implemented Yet!");
            }
        }

        // Update the Renderer
        void LateUpdate()
        {
            //TODO: Run the Renderer class         
        }

    #endregion

    #region Member Functions

        private List<Map> LoadMapList(string folderDir)
        {
            List<Map> mapList = new List<Map>();

            // Find the Map Files
            DirectoryInfo d = new DirectoryInfo(folderDir);
            FileInfo[] filelList = d.GetFiles(Map.MAP_FILE_EXTENSION);

            // Load all the Maps
            foreach (FileInfo file in filelList)
            {
                string filePath = folderDir + "/" + file.Name;

                Debug.Log(filePath);
                // Load the map
                Map map = Map.LoadMap(filePath);
                // Add the map into the list
                mapList.Add(map);
            }

            return mapList;
        }

        private void loadLevel(Map map)
        {
            cleanLevel();
            
            // Initialize the Renderer
            renderer.InitRenderMap(maps[level].LevelTileMap);
        }

        private void cleanLevel()
        {
            //throw new NotImplementedException();
        }

        private void gotoNextLevel()
        {
            level = Mathf.Clamp(++level, 0, maps.Count());
            loadLevel(maps[level]);
        }

        private void gotoPrevLevel()
        {
            level = Mathf.Clamp(--level, 0, maps.Count());
            loadLevel(maps[level]);
        }

    #endregion
}
