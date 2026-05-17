using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Day/Night Settings")]
    [Tooltip("How many real-time seconds a full in-game day takes.")]
    public float dayDurationInSeconds = 120f;

    [Tooltip("Axis the light rotates around.")]
    public Vector3 rotationAxis = Vector3.right;

    private float rotationSpeed;

    void Start()
    {
        UpdateRotationSpeed();
    }

    void Update()
    {
        // Prevent division by zero
        if (dayDurationInSeconds <= 0f)
            return;

        // Recalculate in case value changes in Inspector during play
        UpdateRotationSpeed();

        // Rotate the light smoothly
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.World);
    }

    void UpdateRotationSpeed()
    {
        // 360 degrees over the full day duration
        rotationSpeed = 360f / dayDurationInSeconds;
    }
}