using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //[SerializeField] Color exploredColor = Color.gray;

    // public ok as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlacable = true;

    [SerializeField] Tower towerPrefab;

    // Vector2Int gridPos;

    const int gridSize = 10;

    void Start()
    {
        Physics.queriesHitTriggers = true;
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            if (isPlacable)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlacable = false;
            }
            else
            {
                // block
            }
        }

    }

    //void Update()
    //{

    //    PathFinder pathfinder = gameObject.GetComponentInParent<PathFinder>();
    //    if (pathfinder.GetStartPoint() == this) { return;  }
    //    else if (pathfinder.GetEndPoint() == this) { return; }

    //    if (isExplored)
    //    {
    //        this.SetTopColor(exploredColor);
    //    }

    //}

    //public void SetTopColor(Color color)
    //{
    //    MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
    //    topMeshRenderer.material.color = color;
    //}
}
