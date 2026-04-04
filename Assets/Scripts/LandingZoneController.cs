using UnityEngine;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && examManager != null)
        {
            if (examManager.CanCompleteMission())
            {
                if (examManager != null)
                {
                    Debug.Log("Mission Complete");

                    // update HUD
                    examManager.ShowMissionComplete();
                }
            }
        }
    }
}