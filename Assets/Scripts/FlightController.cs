// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author:Egemen Çalışkan | Student ID: 220444035

using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;   // degrees/second
    [SerializeField] private float yawSpeed   = 45f;   // degrees/second
    [SerializeField] private float rollSpeed  = 45f;   // degrees/second
    [SerializeField] private float thrustSpeed = 5f;    // units/second

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // Pitch: Arrow Up/Down
        float pitch = Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right, pitch);

        // Yaw: Arrow Left/Right
        float yaw = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw);

        // Roll: Q / E keys
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward, rollSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.forward, -rollSpeed * Time.deltaTime);
        }
    }

    private void HandleThrust()
    {
        // Thrust: Spacebar
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}
