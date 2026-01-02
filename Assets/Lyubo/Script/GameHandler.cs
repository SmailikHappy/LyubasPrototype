using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private float m_timer = 300f;

    private bool m_gameOver = false;

    [Header("Weapon Settings")]
    [SerializeField]
    private GameObject m_weaponPrefab;

    [SerializeField]
    private Transform m_weaponSpawnPoint;

    [Header("Ship Settings")]
    [SerializeField]
    private GameObject m_shipPrefab;

    [SerializeField]
    private Transform m_shipSpawnPoint;

    [SerializeField]
    private float m_shipSpawnDelay = 5f;

    private float m_shipSpawnTimer = 0f;

    [Header("Base Settings")]
    [SerializeField]
    private GameObject m_base;
    public GameObject Base { get { return m_base; } }

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
    }

    void Start()
    {
        WeaponPickup();
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }

    public void WeaponPickup()
    {
        Instantiate(m_weaponPrefab, m_weaponSpawnPoint.position, m_weaponSpawnPoint.rotation);
    }

    private void SpawnShip()
    {
        Instantiate(m_shipPrefab, m_shipSpawnPoint.position, m_shipSpawnPoint.rotation);
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
