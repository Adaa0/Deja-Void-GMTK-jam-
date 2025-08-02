using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;             // Takip edilecek karakter
    public Vector3 offset = new Vector3(0f, 2f, -4f); // Kamera hedefe göre pozisyon farkı
    public float sensitivity = 3f;       // Mouse hassasiyeti
    public float rotationSmoothTime = 0.1f;

    public float minY = -30f;
    public float maxY = 60f;

    private float yaw;   // Yatay dönüş
    private float pitch; // Dikey dönüş
    private Vector3 currentRotation;
    private Vector3 rotationSmoothVelocity;

    void LateUpdate()
    {
        // Mouse input
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, minY, maxY);

        // Smooth dönüş
        Vector3 targetRotation = new Vector3(pitch, yaw);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        // Kamera pozisyonu
        Vector3 desiredPosition = target.position + Quaternion.Euler(currentRotation) * offset;

        // Opsiyonel: Kamera raycast ile duvarlara girmesin
        // RaycastHit hit;
        // if (Physics.Linecast(target.position, desiredPosition, out hit))
        // {
        //     desiredPosition = hit.point;
        // }

        transform.position = desiredPosition;
    }
}
