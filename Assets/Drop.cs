using UnityEngine;

public class Drop : MonoBehaviour
{
    public float dropSpeed = 5f;
    private bool isDropping = false;

    void Update()
    {
        // X button on left controller
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            isDropping = true;
        }

        if (isDropping)
        {
            Vector3 pos = transform.position;

            // Move downward smoothly
            pos.y = Mathf.MoveTowards(pos.y, 0f, dropSpeed * Time.deltaTime);
            transform.position = pos;

            // Stop when we reach y = 0
            if (Mathf.Approximately(pos.y, 0f))
            {
                isDropping = false;
            }
        }
    }
}