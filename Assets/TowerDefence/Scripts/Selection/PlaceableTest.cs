﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTest : MonoBehaviour {

    public bool isAvailable = true;
    public Transform pivotPoint;

    /// <summary>
    /// Returns the pivot point attached to tile
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPivotPoint()
    {
        if (pivotPoint == null)
            return transform.position;

        return pivotPoint.position;

    }

	
}
