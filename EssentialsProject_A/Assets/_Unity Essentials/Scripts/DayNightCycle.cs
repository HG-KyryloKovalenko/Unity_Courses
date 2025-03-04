using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Length of the day in seconds
    [Tooltip("Duration of a full day cycle in seconds.")]
    public float dayDurationInSeconds = 120f;

    // Update is called once per frame
    void Update()
    {
        if (dayDurationInSeconds <= 0f)
        {
            Debug.LogWarning("Day duration must be greater than 0!");
            return;
        }

        // Calculate rotation speed based on the duration of the day
        float rotationSpeed = 360f / dayDurationInSeconds;

        // Rotate the light around the X-axis to simulate the sun's movement
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
