using UnityEngine;

public class OrbitingCarCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform target;            // The car Transform to follow
    public float distance = 6.0f;       // Distance behind the car
    public float height = 2.0f;         // Height above the car
    public float followSpeed = 10.0f;   // Speed to catch up to the car
    public float rotationDamping = 5.0f; // Smooth rotation damping
    public float orbitAngle = 15f;      // Maximum orbit angle when turning
    public float orbitSpeed = 2f;       // Smoothness of the orbit effect

    private float currentOrbitOffset = 0f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Get horizontal input for orbit effect
        float horizontalInput = Input.GetAxis("Horizontal");

        // Smoothly interpolate the orbit offset based on input
        float targetOrbitOffset = horizontalInput * orbitAngle;
        currentOrbitOffset = Mathf.Lerp(currentOrbitOffset, targetOrbitOffset, orbitSpeed * Time.deltaTime);

        // Calculate the camera's position behind the car with the orbit offset
        Quaternion orbitRotation = Quaternion.Euler(0, currentOrbitOffset, 0);
        Vector3 offsetPosition = orbitRotation * -target.forward * distance + Vector3.up * height;

        Vector3 targetPosition = target.position + offsetPosition;

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Smoothly rotate to look at the car
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationDamping * Time.deltaTime);
    }
}
