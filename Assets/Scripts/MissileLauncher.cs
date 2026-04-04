using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        Debug.Log("Missile launching triggered");

        return null;
    }

    public void DestroyActiveMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
        }
    }
}
