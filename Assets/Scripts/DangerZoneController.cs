using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float missileDelay = 5f;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Trigger entered");

        if (collision.CompareTag("Player"))
        {
            examManager.EnterDangerZone();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Trigger exited");
        
        if (collision.CompareTag("Player"))
        {
            examManager.ExitDangerZone();
        }
    }
}
