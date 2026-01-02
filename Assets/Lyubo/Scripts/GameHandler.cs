using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private float m_timer = 300f;

    private bool m_gameOver = false;
    public bool IsGameOver { get { return m_gameOver; } }

    [Header("Weapon Settings")]
    [SerializeField]
    private WeaponTypes m_weaponTypesHolder;
    public WeaponTypes WeaponTypesHolder { get { return m_weaponTypesHolder; } }

    private List<WeaponSpawner> m_weaponSpawners = new List<WeaponSpawner>();

    [Header("Ship Settings")]
    [SerializeField]
    private ShipTypes m_shipTypesHolder;
    public ShipTypes ShipTypesHolder { get { return m_shipTypesHolder; } }

    private List<ShipSpawner> m_shipSpawners = new List<ShipSpawner>();

    [SerializeField]
    private float m_shipSpawnDelay = 5f;

    private float m_shipSpawnTimer = 0f;

    [Header("Base Settings")]
    [SerializeField]
    private GameObject m_base;
    public GameObject Base { get { return m_base; } }

    [Header("Game Settings")]
    private float m_gameDuration;

    [SerializeField]
    private float m_minBeginShipSpawnDelay = 2f;
    
    [SerializeField]
    private float m_maxBeginShipSpawnDelay = 8f;

    [SerializeField]
    private float m_minEndShipSpawnDelay = 0.5f;

    [SerializeField]
    private float m_maxEndShipSpawnDelay = 2f;

    private WeaponScript m_pickedUpWeapon;
    private WeaponSpawner m_lastPickedWeaponSpawner;

    private static GameHandler m_instance;
    public static GameHandler Instance { get { return m_instance; } }

    void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        m_gameDuration = m_timer;
    }

    public void AddShipSpawner(ShipSpawner a_spawner)
    {
        m_shipSpawners.Add(a_spawner);
    }

    public void AddWeaponSpawner(WeaponSpawner a_spawner)
    {
        m_weaponSpawners.Add(a_spawner);
    }


    // Update is called once per frame
    void Update()
    {
        if (m_gameOver) return;

        m_timer -= Time.deltaTime;
        m_shipSpawnTimer += Time.deltaTime;

        if (m_timer <= 0)
        {
            GameWon();
        }

        if (m_shipSpawnTimer >= m_shipSpawnDelay)
        {
            SpawnShip();
            m_shipSpawnTimer = 0f;
            float maxSpawnDelay = Mathf.Lerp(m_maxBeginShipSpawnDelay, m_maxEndShipSpawnDelay, 1 - (m_timer / m_gameDuration));
            float minSpawnDelay = Mathf.Lerp(m_minBeginShipSpawnDelay, m_minEndShipSpawnDelay, 1 - (m_timer / m_gameDuration));

            m_shipSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            Debug.Log($"Next ship spawn in {m_shipSpawnDelay} seconds. With max {maxSpawnDelay} and min {minSpawnDelay}");
        }
    }

    public void WeaponPickup()
    {
        
    }

    private void SpawnShip()
    {
        int i = Random.Range(0, m_shipSpawners.Count);
        m_shipSpawners[i].SpawnShip();
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        m_gameOver = true;
    }

    public void GameWon()
    {
        Debug.Log("Game Won!");
        m_gameOver = true;
    }
}
