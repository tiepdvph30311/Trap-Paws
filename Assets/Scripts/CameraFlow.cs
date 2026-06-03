using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform background;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        if (background != null)
        {
            background.position = new Vector3(smoothedPosition.x, background.position.y, background.position.z);
        }
    }
}
