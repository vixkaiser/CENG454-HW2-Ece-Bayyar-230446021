using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        if (missilePrefab == null || launchPoint == null)
        {
            Debug.Log("Missile prefab or launch point is missing");
            return null;
        }

        Debug.Log("Missile launching triggered");
        Debug.Log("Launch point position: " + launchPoint.position);

        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);
        
        Missile missileScript = activeMissile.GetComponent<Missile>();
        if (missileScript != null)
        {
            missileScript.SetTarget(target);
        }

        Debug.Log("Spawned object: " + activeMissile.name);

        return activeMissile;
    }

    public void DestroyActiveMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}
