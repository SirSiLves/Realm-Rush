﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor = Color.gray;

    // public ok as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;


    // Vector2Int gridPos;

    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }


    void Update()
    {

        PathFinder pathfinder = gameObject.GetComponentInParent<PathFinder>();
        if (pathfinder.getStartPoint() == this) { return;  }
        else if (pathfinder.getEndPoint() == this) { return; }

        if (isExplored)
        {
            this.SetTopColor(exploredColor);
        }

    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
