using UnityEngine;


public class ShipSpawner : MonoBehaviour
{
    [SerializeField] private ShipType m_ShipTypesToSpawn;

    void Start()
    {
        GameHandler.Instance.AddShipSpawner(this);
    }

    public void SpawnShip()
    {
        if (m_ShipTypesToSpawn == 0)
        {
            Debug.Log("No Ship Type selected for spawning.");
            return;
        }

        int i = 0;
        while (true)
        {
            i = Random.Range(0, GameHandler.Instance.ShipTypesHolder.ShipTypeCount);

            if (m_ShipTypesToSpawn.HasFlag((ShipType)(1 << i)))
                break; // Exit the loop
        }

        GameObject shipPrefab = GameHandler.Instance.ShipTypesHolder.GetShipPrefab((ShipType)(1 << i));
        if (shipPrefab != null)
        {
            Instantiate(shipPrefab, transform.position, Quaternion.identity);
        }
    }
}
