using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField]
    private int m_health = 3;

    [SerializeField]
    private TextMesh m_healthText;

    void Awake()
    {
        m_healthText.text = m_health.ToString();
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Base took damage: " + damage);
        m_health -= damage;
        m_healthText.text = m_health.ToString();
        if (m_health <= 0)
        {
            GameHandler.Instance.GameOver();
        }
    }
}
