using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;
    
    public void EnterDangerZone()
    {
        if (statusText != null)
        {
            statusText.text = "Entered a Dangerous Zone!";
        }
    }

    public void ExitDangerZone()
    {
        threatCleared = true;

        if (statusText != null)
        {
            statusText.text = "";
        }
    }

    public bool CanCompleteMission()
    {
        return threatCleared && !missionComplete;
    }

    public void ShowMissionComplete()
{
    if (statusText != null)
    {
        statusText.text = "Mission Complete!";
    }

    missionComplete = true;
}
}
