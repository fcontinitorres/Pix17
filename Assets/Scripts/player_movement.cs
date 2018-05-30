using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    [SerializeField]
    float angle;

    public int mov_speed = 25;
    public int pitch_speed = 25;

    public float pitch_limit_max = 0;
    public float pitch_limit_min = 0;

    private float input_Vertical;
    private float input_Horizontal;

    private float PitchAngle;
    private float RollAngle;

    private Rigidbody player;

    private enum STATE
    {
        pitch_up,
        pitch_down,
        pitch_neutral,
        yaw_right,
        yaw_left,
        yaw_neutral,
        neutral
    }


    private void Start()
    {
        player = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        input_Vertical = Input.GetAxis("Vertical");
        input_Horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        //Pitch();
    }

    private void Move()
    {
        Vector3 mov = new Vector3(input_Horizontal, input_Vertical, 0);
        mov = mov.normalized * mov_speed * Time.fixedDeltaTime;
        transform.position += mov;
    }

    private void MovePos()
    {
        Vector3 mov = new Vector3(input_Horizontal, input_Vertical, 0);
        mov = mov.normalized * mov_speed * Time.fixedDeltaTime;
        player.MovePosition(transform.position + mov);

    }

    private void Pitch()
    {
        float ang = input_Vertical * pitch_speed * Time.fixedDeltaTime;
        float angle = Vector3.Angle(Vector3.forward, transform.forward);

        Quaternion rot = Quaternion.Euler((ang * -1), 0f, 0f);

        Debug.Log(angle);

        //if (angle > 25) rot = rot - test;

        player.MoveRotation(player.rotation * rot);

    }
}
