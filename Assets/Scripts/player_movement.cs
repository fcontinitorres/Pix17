using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    //[SerializeField]
    //float angle;

    public int mov_speed = 25;
    public int pitch_speed = 25;
    public int yaw_speed = 25;

    public float pitch_limit_max = 0;
    public float pitch_limit_min = 0;

    private float input_Vertical;
    private float input_Horizontal;

    private float PitchAngle;
    private float RollAngle;

    private STATE statePitch;
    private STATE stateYaw;

    //private Rigidbody player;

    private enum STATE
    {
        pitch_max,
        pitch_min,
        pitch_neutral,
        yaw_max,
        yaw_min,
        yaw_neutral,
    }


    private void Start()
    {
        //player = GetComponent<Rigidbody>();
        statePitch = STATE.pitch_neutral;
        stateYaw = STATE.yaw_neutral;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {

        input_Vertical = Input.GetAxis("Vertical");
        input_Horizontal = Input.GetAxis("Horizontal");

        //MoveVertAxis();
        //MoveHorAxis();

        if (statePitch == STATE.pitch_neutral)
        {
            Pitch();
        }
        else if (statePitch == STATE.pitch_max)
        {
            if (input_Vertical < 0)
            {
                Pitch();
            }
        }
        else if (statePitch == STATE.pitch_min)
        {
            if (input_Vertical > 0)
            {
                Pitch();
            }
        }


        if (stateYaw == STATE.yaw_neutral)
        {
            Yaw();
        }
        else if (stateYaw == STATE.yaw_max)
        {
            if (input_Horizontal < 0)
            {
                Yaw();
            }
        }
        else if (stateYaw == STATE.yaw_min)
        {
            if (input_Horizontal > 0)
            {
                Yaw();
            }
        }
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

    private void Pitch()
    {
        float ang = input_Vertical * pitch_speed * Time.fixedDeltaTime;
        float angle = Vector3.SignedAngle(Vector3.forward, transform.forward, transform.right);

        Quaternion rot = Quaternion.Euler((ang * -1), 0f, 0f);

        Debug.Log("Pitch: " + angle);

        if (angle >= 25f) statePitch = STATE.pitch_min;
        else if (angle <= -25f) statePitch = STATE.pitch_max;
        else statePitch = STATE.pitch_neutral;

        //player.MoveRotation(player.rotation * rot);
        transform.rotation *= rot;
    }

    private void Yaw()
    {
        float ang = input_Horizontal * yaw_speed * Time.fixedDeltaTime;
        float angle = Vector3.SignedAngle(Vector3.forward, transform.forward, transform.up);

        Quaternion rot = Quaternion.Euler(0f, ang, 0f);

        Debug.Log("Yaw: " + angle);

        if (angle >= 25f) stateYaw = STATE.yaw_max;
        else if (angle <= -25f) stateYaw = STATE.yaw_min;
        else stateYaw = STATE.yaw_neutral;

        //player.MoveRotation(player.rotation * rot);
        transform.rotation *= rot;
    }
}
