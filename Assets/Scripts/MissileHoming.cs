using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    private Transform target;

    [SerializeField] private float speed = 22f;
    [SerializeField] private float turnSpeed = 3f;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        Debug.Log("Missile target set to: " + (target != null ? target.name : "NULL"));
    }

    void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );

        transform.position += transform.forward * speed * Time.deltaTime;
    }
}