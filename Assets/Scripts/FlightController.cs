// FlightController.cs
// CENG 454 - HW1: Sky-High Prototype
// Author: [Ece Bayyar] | Student ID: [230446021]

using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] float pitchSpeed = 45f; //degrees/second
    [SerializeField] float yawSpeed = 45f; //degrees/second
    [SerializeField] float rollSpeed = 45f; //degrees/second
    [SerializeField] float thrustSpeed = 5f; //units/second

    private Rigidbody rb;
    private bool hasTakenOff = false;
    private float startY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleThrust();

        if (!hasTakenOff && transform.position.y > startY + 2f)
        {
            hasTakenOff = true;

            FlightExamManager examManager = FindFirstObjectByType<FlightExamManager>();
            if (examManager != null)
            {
                examManager.RegisterTakeOff();
            }
        }
    }

    private void HandleRotation()
    {
        // Pitch
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right * pitchSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(-Vector3.right * pitchSpeed * Time.deltaTime);
        }
        
        // Yaw
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up * yawSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * yawSpeed * Time.deltaTime);
        }

        // Roll
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(-Vector3.forward * rollSpeed * Time.deltaTime);
        }
    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }

    public void ResetTakeoffState()
    {
        hasTakenOff = false;
        startY = transform.position.y;
    }
}
