using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Public variables to control the axis and speed of rotation
    public Vector3 rotationAxis = Vector3.up; // Default axis is the Y-axis
    public float rotationSpeed = 10f; // Default rotation speed

    void Update()
    {
        // Calculate rotation based on axis, speed, and time
        float angle = rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationAxis * angle, Space.Self);
    }
}