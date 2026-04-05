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
            missionText.text = "Objective: Take off";
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
            missionText.text = "Objective: Escape the danger zone";
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
                missionText.text = "Objective: Land safely";
            }

            Invoke(nameof(ClearStatusText), 2f);
        }
    }

    public void RegisterTakeOff()
    {
        hasTakenOff = true;

        if (missionText != null)
        {
            missionText.text = "Objective: Gain altitude";
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
            missionText.text = "Objective: Take off";
        }

        Invoke(nameof(ClearStatusText), 2f);
    }

    private void ClearStatusText()
    {
        if (statusText != null && !missionComplete)
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

    if (missionText != null)
    {
        missionText.text = "Success";
    }

    missionComplete = true;
}
}
