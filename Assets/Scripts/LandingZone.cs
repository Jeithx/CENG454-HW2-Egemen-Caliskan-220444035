using UnityEngine;

public class LandingZone : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            examManager.CompleteMission();
        }
    }
}
