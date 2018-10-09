using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public Vector3 cameraOffset;
    public Transform cameraHolder;
    public float clampValue;

    float yRotationValue;
    float xRotationValue;
    Quaternion cameraRotation;

    Vector3 velocity;
    Transform player;
    Camera cam;
    Vector3 offset;

    private void Start()
    {
        cam = Camera.main;
        player = GameObject.Find("Player").transform;

        offset = new Vector3(player.position.x + cameraOffset.x, player.position.y + cameraOffset.y, player.position.z + cameraOffset.z);
        transform.SetParent(null);
    }

    private void LateUpdate()
    {
        Look();
    }


    public void Look()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * horizontalSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360.0f)
            angle += 360.0f;
        if (angle > 360.0f)
            angle -= 360.0f;
        return Mathf.Clamp(angle, min, max);
    }
}
