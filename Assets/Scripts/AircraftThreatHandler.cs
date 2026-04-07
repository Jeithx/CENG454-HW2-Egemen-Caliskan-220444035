using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Missile"))
        {
            if (hitAudioSource != null)
            {
                hitAudioSource.Play();
            }

            transform.position = respawnPoint.position;
            transform.rotation = Quaternion.identity;
            
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
