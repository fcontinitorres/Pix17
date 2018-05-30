﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_test : MonoBehaviour {

    public float movementSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, (vertical * -1f), 0f);

        Vector3 finalDirection = new Vector3(horizontal, (vertical * -1f), 1f);

        transform.position += direction * movementSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDirection), Mathf.Deg2Rad * 50f);
    }
}
