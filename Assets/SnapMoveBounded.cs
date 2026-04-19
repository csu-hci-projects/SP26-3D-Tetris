using UnityEngine;

public class SnapMoveBounded : MonoBehaviour
{
    public float moveStep = 1.0f;          // how far it moves each time
    public float inputCooldown = 0.25f;    // delay between moves

    public Vector2 xBounds = new Vector2(-5f, 5f); // left/right limits
    public Vector2 zBounds = new Vector2(-5f, 5f); // forward/back limits

    private float lastMoveTime;

    void Update()
    {
        if (Time.time - lastMoveTime < inputCooldown)
            return;

        Vector2 input = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Vector3 move = Vector3.zero;

        // Left / Right (X axis)
        if (input.x > 0.8f)
        {
            move = Vector3.right * moveStep;
        }
        else if (input.x < -0.8f)
        {
            move = Vector3.left * moveStep;
        }

        // Forward / Back (Z axis)
        if (input.y > 0.8f)
        {
            move = Vector3.forward * moveStep;
        }
        else if (input.y < -0.8f)
        {
            move = Vector3.back * moveStep;
        }

        if (move != Vector3.zero)
        {
            Vector3 newPos = transform.position + move;

            // Clamp within bounds
            newPos.x = Mathf.Clamp(newPos.x, xBounds.x, xBounds.y);
            newPos.z = Mathf.Clamp(newPos.z, zBounds.x, zBounds.y);

            transform.position = newPos;
            lastMoveTime = Time.time;
        }
    }
}