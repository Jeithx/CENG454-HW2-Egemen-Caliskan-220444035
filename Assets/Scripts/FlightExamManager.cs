using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    [SerializeField] private AudioSource successAudio;

    // private bool hasTakenOff = false; // Currently unused
    private bool threatCleared = false;
    private bool missionComplete = false;

    public void EnterDangerZone()
    {
        statusText.text = "Entered a Dangerous Zone!";
    }

    public void ExitDangerZone()
    {
        statusText.text = "";
        threatCleared = true;
    }

    public void CompleteMission()
    {
        if (threatCleared && !missionComplete)
        {
            missionComplete = true;
            statusText.text = "Mission Complete!";
            if (successAudio != null) successAudio.Play();
        }
    }
}
