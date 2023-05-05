using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 100.0f;
    public float height = 100.0f;
    public float mouseSensitivity = 100.0f;

    private float currentAngleX = 0.0f;
    private float currentAngleY = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        currentAngleX += mouseX;
        currentAngleY += mouseY;

        currentAngleY = Mathf.Clamp(currentAngleY, -89.0f, 89.0f);

        Quaternion rotation = Quaternion.Euler(currentAngleY, currentAngleX, 0.0f);
        Vector3 position = rotation * new Vector3(0.0f, height, -distance) + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}

