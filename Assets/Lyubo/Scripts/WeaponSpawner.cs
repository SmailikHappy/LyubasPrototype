using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private WeaponType m_WeaponTypesToSpawn;
    [SerializeField] public float DistanceFromSpawnerToSpawnNewObject = 0.5f;

    private WeaponScript m_lastSpawnedWeapon;

    void Start()
    {
        GameHandler.Instance.AddWeaponSpawner(this);
        SpawnWeapon();
    }

    void Update()
    {
        float distance = Vector3.Distance(m_lastSpawnedWeapon.transform.position, transform.position);
        Debug.Log(distance.ToString("#.00"));
        if (distance > DistanceFromSpawnerToSpawnNewObject)
        {
            SpawnWeapon();
        }
    }

    public void SpawnWeapon()
    {
        if (m_WeaponTypesToSpawn == 0)
        {
            Debug.Log("No Ship Type selected for spawning.");
            return;
        }

        int i = 0;
        while (true)
        {
            i = Random.Range(0, GameHandler.Instance.WeaponTypesHolder.WeaponTypeCount);

            if (m_WeaponTypesToSpawn.HasFlag((WeaponType)(1 << i)))
                break; // Exit the loop
        }

        GameObject weaponPrefab = GameHandler.Instance.WeaponTypesHolder.GetWeaponPrefab((WeaponType)(1 << i));
        if (weaponPrefab != null)
        {
            m_lastSpawnedWeapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity).GetComponentInChildren<WeaponScript>();
        }
    }
}
