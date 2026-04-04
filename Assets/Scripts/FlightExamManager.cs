using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    private bool hasTakenOff = false;
    private bool wasHitByMissile = false;
    private bool threatCleared = false;
    private bool missionComplete = false;
    
    void Start()
    {
        if (statusText != null)
        {
            statusText.text = "";
        }

        if (missionText != null)
        {
            missionText.text = "Take off";
        }
    }
    
    public void EnterDangerZone()
    {
        wasHitByMissile = false;

        if (statusText != null)
        {
            statusText.text = "Entered a Dangerous Zone!";
        }

        if (missionText != null)
        {
            missionText.text = "Escape the danger zone";
        }
    }

    public void RegisterMissileHit()
    {
        wasHitByMissile = true;

        if (statusText != null)
        {
            statusText.text = "Hit by a missile!";
        }

        if (missionText != null)
        {
            missionText.text = "Take Off";
        }
    }

    public void ExitDangerZone()
    {
        if (!wasHitByMissile)
        {
            threatCleared = true;

            if (statusText != null)
            {
                statusText.text = "Threat cleared";
            }

            if (missionText != null)
            {
                missionText.text = "Land safely";
            }
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
