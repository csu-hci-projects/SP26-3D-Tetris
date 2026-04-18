using UnityEngine;

public class SnapRotate : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float inputCooldown = 0.3f;

    private float lastInputTime;

    void Update()
    {
        if (Time.time - lastInputTime < inputCooldown)
            return;

        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        // Horizontal (Y-axis rotation)
        if (input.x > 0.8f)
        {
            Rotate(Vector3.up);
        }
        else if (input.x < -0.8f)
        {
            Rotate(Vector3.down);
        }

        // Vertical (X-axis rotation)
        if (input.y > 0.8f)
        {
            Rotate(Vector3.right);
        }
        else if (input.y < -0.8f)
        {
            Rotate(Vector3.left);
        }
    }

    void Rotate(Vector3 axis)
    {
        transform.Rotate(axis, rotationAngle, Space.World);
        lastInputTime = Time.time;
    }
}