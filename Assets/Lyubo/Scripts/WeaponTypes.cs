using UnityEngine;

[System.Flags]
public enum WeaponType
{
    Sword = 1 << 0,
    Axe = 1 << 1
};

[CreateAssetMenu(fileName = "WeaponTypes", menuName = "Scriptable Objects/WeaponTypes")]
public class WeaponTypes : ScriptableObject
{
    public int WeaponTypeCount => System.Enum.GetValues(typeof(WeaponType)).Length;

    [SerializeField] private GameObject m_swordPrefab = null;
    [SerializeField] private GameObject m_axePrefab = null;

    public GameObject GetWeaponPrefab(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Sword:
                return m_swordPrefab;
            case WeaponType.Axe:
                return m_axePrefab;
            default:
                Debug.LogWarning($"No prefab found for weapon type: {weaponType}");
                return null;
        }
    }
}