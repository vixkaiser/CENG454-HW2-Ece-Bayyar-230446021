using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;

    private bool canBeHit = true;
    private FlightController flightController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        flightController = GetComponent<FlightController>();
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Missile") && canBeHit)
        {
            canBeHit = false;

            if (examManager != null)
            {
                examManager.RegisterMissileHit();
            }
            
            Destroy(collision.gameObject);

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            if (respawnPoint != null)
            {
                transform.position = respawnPoint.position;
                transform.rotation = respawnPoint.rotation;
            }

            if (flightController != null)
            {
                flightController.ResetTakeoffState();
            }

            Invoke(nameof(EnableHit), 0.5f);
        }
    }

    private void EnableHit()
    {
        canBeHit = true;
    }
}