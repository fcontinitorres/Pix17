﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour {

    public Transform player;
    //Vector3 pos;

    // Use this for initialization
    void Start()
    {
        //pos = transform.position;

        
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = player.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 20);

        //Vector3 temp = transform.position;
        //temp.x = pos.x;
        //temp.y = pos.y;
        //transform.position = temp;

        //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
