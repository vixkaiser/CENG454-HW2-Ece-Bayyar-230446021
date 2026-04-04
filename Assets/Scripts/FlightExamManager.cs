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
        if (statusText != null)
        {
            statusText.text = "";
        }
    }
}
