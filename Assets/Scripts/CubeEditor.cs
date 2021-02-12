﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{

    [SerializeField][Range(5, 20)] float gridSize = 10f;

    TextMesh textMesh;

    void Start()
    {

    }

    void Update()
    {

        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;

    }
}