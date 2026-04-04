using UnityEngine;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Landing touched by: " + collision.name + " | Tag: " + collision.tag);
        if (collision.CompareTag("TailPoint") && examManager != null)
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