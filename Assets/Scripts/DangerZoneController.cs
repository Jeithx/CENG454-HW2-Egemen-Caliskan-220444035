using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;
    [SerializeField] private AudioSource warningAudio;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            examManager.EnterDangerZone();
            if (warningAudio != null) warningAudio.Play();
            activeCountdown = StartCoroutine(LaunchAfterDelay(collision.transform));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }
            missileLauncher.DestroyActiveMissile();
            if (warningAudio != null) warningAudio.Stop();
            examManager.ExitDangerZone();
        }
    }

    private IEnumerator LaunchAfterDelay(Transform target)
    {
        yield return new WaitForSeconds(missileDelay);
        missileLauncher.Launch(target);
    }
}
