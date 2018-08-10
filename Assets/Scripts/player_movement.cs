﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    //[SerializeField]
    //float angle;

    public int mov_speed = 25;
    public float maneuver_speed = 5.0f;
    public float max_angle_pitch = 25f;
    public float max_angle_roll = 25f;
    public float max_angle_yaw = 15f;

    private float input_Vertical;
    private float input_Horizontal;

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {

        input_Vertical = Input.GetAxis("Vertical");
        input_Horizontal = Input.GetAxis("Horizontal");

        MoveVertAxis();
        MoveHorAxis();

        maneuverControls();
    }

    private void MoveVertAxis()
    {
        Vector3 direction = new Vector3(0, input_Vertical, 0);
        
        transform.position += direction * mov_speed * Time.fixedDeltaTime;
    }

    private void MoveHorAxis()
    {
        Vector3 direction = new Vector3(input_Horizontal, 0, 0);

        transform.position += direction * mov_speed * Time.fixedDeltaTime;
    }



    private void maneuverControls()
    {
        Quaternion target = Quaternion.Euler((input_Vertical * -1 * max_angle_pitch), (input_Horizontal * max_angle_roll), (input_Horizontal * -1 * max_angle_yaw));

        transform.rotation = Quaternion.Slerp(transform.rotation, target, maneuver_speed * Time.deltaTime);
    }
}
