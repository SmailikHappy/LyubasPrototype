using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public void Grabbed()
    {
        GameHandler.Instance.WeaponPickup();
    }
}
