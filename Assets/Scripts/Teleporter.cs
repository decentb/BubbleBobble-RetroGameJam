﻿using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    public float teleportOffset = 0.05f;

    private GameObject otherTeleporter;

	// Use this for initialization
	void Start()
    {
        if (name == "Bottom Teleporter")
        {
            otherTeleporter = GameObject.Find("Top Teleporter");
        }
        else
        {
            otherTeleporter = GameObject.Find("Bottom Teleporter");
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Vector3 colliderPosition = collider.transform.root.position;
        colliderPosition.y = otherTeleporter.transform.position.y + teleportOffset;
        collider.transform.root.position = colliderPosition;
    }
	
	// Update is called once per frame
	void Update()
    {
	
	}
}
