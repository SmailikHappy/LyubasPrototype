using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_defaultMesh;

    [SerializeField]
    private GameObject m_brokenMesh;

    private bool m_isBroken;
    public bool IsBroken => m_isBroken;

    public void Grabbed()
    {
        GameHandler.Instance.WeaponPickup();
    }

    public void Break()
    {
        m_defaultMesh.SetActive(false);
        m_brokenMesh.SetActive(true);

        foreach (var collider in GetComponentsInChildren<Collider>())
        {
            collider.enabled = false;
        }

        m_isBroken = true;
    }
}
