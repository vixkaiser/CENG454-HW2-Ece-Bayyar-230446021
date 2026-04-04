using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform target;

    [SerializeField] private float speed = 20f;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
