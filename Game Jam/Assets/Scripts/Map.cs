﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class Map : MonoBehaviour 
{
    // TODO: Add the variable that holds the Map
    // TODO: Add a List of Enemies
    public const string MAP_FILE_EXTENSION = "*.map";

    #region Event Functions

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    #endregion

    #region Member Functions

        public bool IsCompleted()
        {
            throw new NotImplementedException();

            return false;
        }

    #endregion

    #region Static Functions

        public static Map LoadMap(string mapFilePath)
        {
            throw new NotImplementedException();

            return new Map();
        }

    #endregion
}
