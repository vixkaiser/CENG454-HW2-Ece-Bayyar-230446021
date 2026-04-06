using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource missileLaunchAudio;
    [SerializeField] private AudioClip missileLaunchClip;

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
        Debug.Log("Target passed to launcher: " + (target != null ? target.name : "NULL"));

        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

        if (missileLaunchAudio != null && missileLaunchClip != null)
        {
            missileLaunchAudio.PlayOneShot(missileLaunchClip);
        }
        
        MissileHoming missileScript = activeMissile.GetComponent<MissileHoming>();
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
