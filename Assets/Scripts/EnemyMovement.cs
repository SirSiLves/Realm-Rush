﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    void Start()
    {
        StartCoroutine(FollowPath());
    }



    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f); // execute async rest of the foreach
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
