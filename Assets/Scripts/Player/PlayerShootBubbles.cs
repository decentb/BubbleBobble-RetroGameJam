﻿using UnityEngine;
using System.Collections;

public class PlayerShootBubbles : MonoBehaviour {

    public Transform bubblePrefab;
    public float timeBetweenShots = 0.02f;
    private float timeUntilNextShot = 0;

    public Animator animator;

	// Use this for initialization
	void Start()
    {
	
	}

    // Create a bubble object at the character
    private void ShootBubble()
    {
        if (bubblePrefab)
        {
            Transform bubbleObject = Instantiate(bubblePrefab, transform.position, Quaternion.identity) as Transform;
            bubbleObject.name = bubblePrefab.name;
            Bubble bubble = bubbleObject.GetComponent<Bubble>();
            Vector3 direction = new Vector3(_movement.IsFacingLeft()?-1.0f:1.0f, 0.0f, 0.0f);
            bubble.Initialize(direction);
        }

        if (animator)
        {
            animator.SetTrigger("Shoot");
        }
    }
	
	// Update is called once per frame
	void Update()
    {
	    if (Input.GetButtonDown("Fire1") && timeUntilNextShot <= 0)
        {
            ShootBubble();
            timeUntilNextShot = timeBetweenShots;
        }
        if (timeUntilNextShot > 0)
        {
            timeUntilNextShot -= Time.deltaTime;
        }
	}

    [SerializeField]
    private PlayerMovement _movement;
}
