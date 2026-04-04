using System.Collections;
using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Trigger entered");

        if (collision.CompareTag("Player"))
        {
            examManager.EnterDangerZone();

            activeCountdown = StartCoroutine(StartMissileCountdown());
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Trigger exited");
        
        if (collision.CompareTag("Player"))
        {
            examManager.ExitDangerZone();

            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }
        }
    }

    private IEnumerator StartMissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);

        Debug.Log("Missile should launch now");
    }
}
