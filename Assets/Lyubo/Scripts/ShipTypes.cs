using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum ShipType
{
    Fast = 1 << 0,
    Mid = 1 << 1,
    Slow = 1 << 2
};

[CreateAssetMenu(fileName = "ShipTypes", menuName = "Scriptable Objects/ShipTypes")]
public class ShipTypes : ScriptableObject
{
    public int ShipTypeCount => System.Enum.GetValues(typeof(ShipType)).Length;

    [SerializeField] private GameObject m_fastShipPrefab = null;
    [SerializeField] private GameObject m_midShipPrefab = null;
    [SerializeField] private GameObject m_slowShipPrefab = null;

    public GameObject GetShipPrefab(ShipType shipType)
    {
        switch (shipType)
        {
            case ShipType.Fast:
                return m_fastShipPrefab;
            case ShipType.Mid:
                return m_midShipPrefab;
            case ShipType.Slow:
                return m_slowShipPrefab;
            default:
                Debug.LogWarning($"No prefab found for ship type: {shipType}");
                return null;
        }
    }
}