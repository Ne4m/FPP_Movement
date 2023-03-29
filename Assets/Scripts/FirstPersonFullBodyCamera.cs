using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonFullBodyCamera : MonoBehaviour
{
    public float lookSpeed = 5f;
    public float cameraDistance = 3f; // Distance between player and camera
    public float cameraOffsetY = 0f;
    public Transform cameraTransform; // Reference to the camera transform

    private float _yaw = 0f;
    private float _pitch = 0f;

    void Update()
    {
        // Get raw input for movement and look
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        // Rotate the player based on look input
        _yaw += mouseX * lookSpeed;
        _pitch -= mouseY * lookSpeed;
        transform.eulerAngles = new Vector3(0f, _yaw, 0f);

        // Calculate the position of the camera based on the offset
        Vector3 cameraPos = transform.position - transform.forward * cameraDistance;
        cameraTransform.position = cameraPos;
        cameraTransform.position = new Vector3(cameraTransform.position.x, cameraOffsetY, cameraTransform.position.z);

        // Rotate the camera based on look input
        _pitch = Mathf.Clamp(_pitch, -90f, 90f);
        cameraTransform.eulerAngles = new Vector3(_pitch, _yaw, 0f);
    }
}
